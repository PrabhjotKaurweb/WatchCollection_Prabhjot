using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WatchCollection_Prabhjot.Controllers
{
    public class WatchAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
