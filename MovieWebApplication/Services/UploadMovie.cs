using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MovieWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Services
{
    public class UploadMovie : IUploadMovie
    {
        IConfiguration Configuration;
        SqlConnection sqlConnection;

        public void SetMovie(Result Movie)
        {
            var Connection = Configuration.GetConnectionString("ConToDb").ToString();            
        }
    }
}
