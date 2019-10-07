using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookiesAuth.Models;
using Microsoft.AspNetCore.Authorization;
using CookiesAuth.Extensions;
using CookiesAuth.Models.ViewModels;

namespace CookiesAuth.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ErrorViewModel modelError = HttpContext.Session.Get<ErrorViewModel>("CurrentError");
            return View(modelError);
        }
    }
}
