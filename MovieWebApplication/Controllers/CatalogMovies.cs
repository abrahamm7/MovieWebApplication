using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebApplication.Controllers
{
    public class CatalogMovies : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
