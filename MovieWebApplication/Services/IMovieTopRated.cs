using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Models
{
    public interface IMovieTopRated
    {
        [Get("/3/movie/top_rated?api_key=93677fcde6181c9d54d22f3161f5c998")]
        Task <MovieTopRated> GetMovieTopRated();
    }
}
