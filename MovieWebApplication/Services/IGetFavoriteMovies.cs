using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public interface IGetFavoriteMovies
    {
        public List<Result> GetFavorites();
    }
}
