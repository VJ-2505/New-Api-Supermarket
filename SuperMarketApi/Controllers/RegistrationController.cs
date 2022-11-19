using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperMarketApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Web.Http.Cors;

namespace SuperMarketApi.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
       


    }
}
