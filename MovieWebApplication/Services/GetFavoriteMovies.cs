using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class GetFavoriteMovies : IGetFavoriteMovies
    {
        IDapper Dapper;
       
        public GetFavoriteMovies(IDapper dapper)
        {
            Dapper = dapper;
          
        }

        public List<MovieTopRated> GetFavorites()
        {
            try
            {
                var GetAllMovies =  Dapper.GetAll<MovieTopRated>("dbo.GetFavoriteMovies", null, commandType: CommandType.StoredProcedure).ToList();
               
                return GetAllMovies;
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                return null;
            }
            
        }
    }
}
