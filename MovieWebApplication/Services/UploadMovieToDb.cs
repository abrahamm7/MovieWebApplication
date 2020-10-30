using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class UploadMovieToDb : IUploadMovie
    {
        IDapper Dapper;

        public UploadMovieToDb(IDapper dapper)
        {
            Dapper = dapper;

        }
        public async void SetMovie(Result Movie)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@title",Movie.Title, DbType.String);
                parameters.Add("@releasedate", Movie.Release_Date, DbType.String);
                parameters.Add("@poster_path", Movie.Poster_Path, DbType.String);
                parameters.Add("@vote", Movie.Vote_Average, DbType.String);
                parameters.Add("@descrip", Movie.Overview, DbType.String);
                var resultoperation = await Task.FromResult(Dapper.Insert<int>("dbo.SetMovie",parameters,commandType: CommandType.StoredProcedure));               
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en insert: {ex.Message}");
            }

        }
    }
}
