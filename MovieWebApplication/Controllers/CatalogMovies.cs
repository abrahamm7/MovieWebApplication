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

        [HttpPost]
        public async void UploadMovie(string title, string overview, string post, string release, double vote )
        {
            try
            {
                //using var client = new HttpClient();
                //try
                //{
                    var MovieToUpload = MovieDetails(title, overview, post, release, vote);

                //    var values = new Dictionary<string, string>
                //    {
                //       {"Title", $"{MovieToUpload.Title}" },
                //       {"Overview", $"{MovieToUpload.Overview}" },
                //       {"Poster_Path", $"{MovieToUpload.Poster_Path}" }
                //    };


                //   // var content = new FormUrlEncodedContent(values);

                //    var formatjson = new StringContent(MovieToUpload.Title, Encoding.UTF32, "application/json");

                //    var response = await client.PostAsync("https://localhost:44372/api/Movies", formatjson);

                //    var responseString = await response.Content.ReadAsStringAsync();

                //}
                //catch (Exception ex)
                //{
                //    Debug.WriteLine($"{ex.Message}");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");                
            }
        }
    }
}
