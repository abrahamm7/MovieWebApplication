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
        IConfiguration Configuration;

        public void SetMovie(Result Movie)
        {
            try
            {
                var Connection = Configuration.GetConnectionString("ConToDb").ToString();
                var connectdb = new SqlConnection(Connection);
                var command = new SqlCommand("dbo.SetMovie", connectdb);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", Movie.Title);
                command.Parameters.AddWithValue("@releasedate", Movie.Release_Date);
                command.Parameters.AddWithValue("@poster_path", Movie.Poster_Path);
                command.Parameters.AddWithValue("@vote", Movie.Vote_Average);
                command.Parameters.AddWithValue("@descrip", Movie.Overview);
                connectdb.Open();
                command.ExecuteNonQuery();
                connectdb.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en insert: {ex.Message}");
            }

        }
    }
}
