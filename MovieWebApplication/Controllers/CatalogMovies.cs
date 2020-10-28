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
    public class CatalogMovies : Controller
    {
        private IMovieTopRated movieService = new MovieTopRatedService();
       
        public IActionResult Index()
        {
            var ListTopMovies = GetTopMovies();
            return View(ListTopMovies);
        }        

        public async Task<List<Result>> GetTopMovies()
        {
            try
            {                
                RestService.For<IMovieTopRated>(Links.UrlApi);
                var request = await movieService.GetMovieTopRated();
                await GetMoviePoster(request.Results);
                return request.Results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }

        public async Task GetMoviePoster(List<Result> movies)
        {
            foreach (var item in movies)
            {
                var image = string.Format($"https://image.tmdb.org/t/p/w200{item.Poster_Path}");
                item.Poster_Path = image;
            }
        }
    }
}
