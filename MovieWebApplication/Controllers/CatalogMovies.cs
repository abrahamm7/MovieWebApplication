using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebApplication.Constants;
using MovieWebApplication.Models;
using MovieWebApplication.Services;
using Newtonsoft.Json;
using Refit;

namespace MovieWebApplication.Controllers
{
    public class CatalogMovies : Controller
    {
        private readonly IUploadMovie UploadTitleMovie;

        public CatalogMovies(IUploadMovie sentMovie)
        {           
            UploadTitleMovie = sentMovie;
        }
       
        public IActionResult Index()
        {
            var ListTopMovies = GetTopMovies();
            return View(ListTopMovies);
        }        

       

        [HttpGet]
        public IActionResult DisplayDetails(string title, string overview, string post, string release, double vote)
        {
            try
            {
                var movie = MovieDetails(title, overview, post, release, vote);
                return View(movie);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return View("Index");
            }        
        }

        

        [HttpPost]
        public async Task<IActionResult> UploadMovie(string title, string overview, string post, string release, double vote )
        {
            try
            {
                var MovieToUpload = MovieDetails(title, overview, post, release, vote);
                var sendrequest = RestService.For<IUploadMovie>(Links.FavoriteMoviesUrl);
                await sendrequest.SetMovie(MovieToUpload);
                return RedirectToAction(actionName: "Index", controllerName: "CatalogMovies");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return RedirectToAction(actionName: "Index", controllerName: "CatalogMovies");
            }
        }

        public async Task<List<Result>> GetTopMovies()
        {
            try
            {
                var request = RestService.For<IMovieTopRated>(Links.UrlApi);
                var response = await request.GetMovieTopRated();
                await GetMoviePoster(response.Results);
                return response.Results;
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

        public Result MovieDetails(string title, string overview, string post, string release, double vote)
        {
            Result result = new Result();
            result.Title = title;
            result.Overview = overview;
            result.Poster_Path = post;
            result.Release_Date = release;
            result.Vote_Average = vote;
            return result;
        }
    }
}
