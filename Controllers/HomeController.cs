using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeltrettungAuftrag.Models;


namespace WeltrettungAuftrag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ViewResult RsvpForm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ViewResult RsvpForm(Held held)
        //{
        //    // TODO: store response from guest
        //    return View();
        //}
    }
}
