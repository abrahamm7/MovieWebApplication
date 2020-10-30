using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Services;

namespace MovieWebApplication.Controllers
{
    public class FavoriteMovies : Controller
    {
        IGetFavoriteMovies getFavorite;

        public FavoriteMovies(IGetFavoriteMovies getFavoriteMovies)
        {
            getFavorite = getFavoriteMovies;
        }

        public IActionResult Index()
        {
            var ListMovies = getFavorite.GetFavorites();
            return View(ListMovies);
        }
    }
}
