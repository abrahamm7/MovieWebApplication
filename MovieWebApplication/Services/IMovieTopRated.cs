using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Models
{
    public interface IMovieTopRated
    {
        [Get("/api.themoviedb.org/3/movie/top_rated")]
        Task<MovieTopRated> GetMovieTopRated();
    }
}
