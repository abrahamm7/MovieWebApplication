using MovieWebApplication.Constants;
using MovieWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class MovieTopRatedService: IMovieTopRated
    {
        public async Task<MovieTopRated> GetMovieTopRated()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(Links.TopRatedMovies);
                return JsonConvert.DeserializeObject<MovieTopRated>(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
        }
    }
}
