using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketApi.Models;
using SuperMarketApi.Models.Enum;

namespace SuperMarketApi.Controllers
{
    public class OrdersControllerExt : Controller
    {
        public static void DispatchComplete(POSDbContext db, int orderId, int orderType,int companyId)
        {
            Order order = db.Orders.Where(O => O.Id == orderId && O.CompanyId == companyId).FirstOrDefault();

            List<OrderProduct> orderProdList = db.OrderProducts.Where(t => t.OrderId == orderId).ToList();
            bool isComplete = true;
            bool isOpen = true;
            for (int i = 0; i < orderProdList.Count; i++)
            {
                OrderProduct orderProd = orderProdList[i];
                if (orderProd.Status < (int)OrderProductStatus.Closed && orderProd.OpenQuantity > 0)
                    isComplete = false;
                if (orderProd.DispatchedQuantity != null)
                    isOpen = false;
            }
            if (isComplete)
                order.DispatchStatus = (int)OrderDispatchStatus.Closed;
            else if (!isOpen)
                order.DispatchStatus = (int)OrderDispatchStatus.Partial;
            else
                order.DispatchStatus = (int)OrderDispatchStatus.Open;

            InternalOrderStatus(db, orderId, companyId);
          //  else if (orderType == (int)OrderType.Purchase) VendorOrderStatus(db, orderId);
          //  else if (orderType == (int)OrderType.Sales) SalesOrderStatus(db, orderId);
            db.Entry(order).State = EntityState.Modified;
        }
        public static void InternalOrderStatus(POSDbContext db, int orderId,int companyId)
        {
            Order order = db.Orders.Where(O => O.Id == orderId && O.CompanyId == companyId).FirstOrDefault();

            if (order.DispatchStatus == (int)OrderDispatchStatus.Open && order.CancelStatus != (int)OrderCancelStatus.Closed
                 && (order.WipStatus == null || order.WipStatus == "APPR"))
            {
                order.OrderStatus = (int)OrderStatusEnum.Open;
            }
            else if (order.DispatchStatus != (int)OrderDispatchStatus.Open && order.ReceiveStatus != (int)OrderReceiveStatus.Closed)
            {
                order.OrderStatus = (int)OrderStatusEnum.OpenInProgress;
            }
            else if (order.ReceiveStatus == (int)OrderReceiveStatus.Closed)
            {
                order.OrderStatus = (int)OrderStatusEnum.Completed;
            }
            else if (order.WipStatus != null && order.WipStatus != "APPR")
            {
                order.OrderStatus = (int)OrderStatusEnum.Draft;
            }
            else if (order.CancelStatus == (int)OrderCancelStatus.Closed)
            {
                order.OrderStatus = (int)OrderStatusEnum.Cancelled;
            }
        }
    }
}
