using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebApplication.Controllers
{
    public class DetailMovie : Controller
    {
        public IActionResult DetailMoviePage()
        {
            return View();
        }
    }
}
