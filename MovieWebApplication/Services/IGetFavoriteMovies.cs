using MovieWebApplication.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public interface IGetFavoriteMovies
    {
        [Get("/api/Movies")]
        Task <List<Result>> GetFavorites();
    }
}
