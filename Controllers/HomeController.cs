using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        /**
          * GET: /Home/Index
          */
        public IActionResult Index()
        {
            ViewData["message_short"] = "Welcome to my simple E-commerce app";
            return View();
        }
    }
}
