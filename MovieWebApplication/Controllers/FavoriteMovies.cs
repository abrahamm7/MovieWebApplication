using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Constants;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using Refit;

namespace MovieWebApplication.Controllers
{
    public class FavoriteMovies : Controller
    {
        public IActionResult Index()
        {
            var ListMovies = GetFavoriteMovies();
            return View(ListMovies);
        }

        public async Task<List<Result>> GetFavoriteMovies()
        {
            try
            {
                var request = RestService.For<IGetFavoriteMovies>(Links.FavoriteMoviesUrl);
                var response = await request.GetFavorites();
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }

    }
}
