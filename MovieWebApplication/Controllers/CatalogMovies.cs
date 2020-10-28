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
            try
            {
                var ListTopMovies = GetTopMovies();
                return View(ListTopMovies);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return View(null);
            }
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
            try
            {
                foreach (var item in movies)
                {
                    var image = string.Format($"https://image.tmdb.org/t/p/w200{item.Poster_Path}");
                    item.Poster_Path = image;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult DisplayDetails(string title, string overview, string post)
        {
            try
            {
                var movie = MovieDetails(title, overview, post);
                return View(movie);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return View("Index");
            }        
        }

        public Result MovieDetails(string title, string overview, string post)
        {
            Result result = new Result();
            result.Title = title;
            result.Overview = overview;
            result.Poster_Path = post;
            return result;
        }
    }
}
