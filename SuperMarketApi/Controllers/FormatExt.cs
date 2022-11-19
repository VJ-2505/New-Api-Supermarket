using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using System.Transactions;

namespace SuperMarketApi.Controllers
{
    public static class FormatExt
    {
        public static DateTime GetDateSave(string datetime)
        {
            DateTime date = Convert.ToDateTime(DateTime.ParseExact(datetime, "dd-MM-yyyy", null));
            return date;
        }
        public static string GetTimeWithMilliSec(DateTime? dateTime)
        {
            string time = null;
            if (dateTime != null) time = ((DateTime)dateTime).TimeOfDay.ToString().Substring(0, 12);
            return time;
        }
        public static DateTime GetDateTimeSave(string datetime, string time)
        {
            DateTime dateTime = new DateTime();
            DateTime currentDateNTime = DateTime.Now;

            if (string.IsNullOrEmpty(datetime))
            {
                dateTime = currentDateNTime;
            }
            else
            {
                if (string.IsNullOrEmpty(time))
                {
                    string currentTime = FormatExt.GetTimeWithMilliSec(currentDateNTime).Substring(0, 12);
                    dateTime = DateTime.ParseExact
                        (datetime + " " + currentTime, "dd-MM-yyyy HH:mm:ss.fff", null);
                }
                else
                {
                    dateTime = DateTime.ParseExact
                        (datetime + " " + time, "dd-MM-yyyy HH:mm", null);
                }
            }
            return dateTime;
        }
        public static string GetDateView(DateTime? dateTime)
        {
            string date = null;
            if (dateTime != null) date = ((DateTime)dateTime).ToString("dd-MM-yyyy HH:mm", null);
            return date;
        }
        public static string GetTime(DateTime? dateTime)
        {
            string time = null;
            if (dateTime != null) time = ((DateTime)dateTime).TimeOfDay.ToString().Substring(0, 5);
            return time;
        }
    }
}
