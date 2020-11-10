using MovieWebApplication.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public interface IUploadMovie
    {
        [Post("/api/Movies")]
        public Task SetMovie([Body]Result Movie);
    }
}
