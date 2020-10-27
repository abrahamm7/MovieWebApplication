using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWebApplication.Models
{
    public class Result
    {
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public bool Video { get; set; }
        public string Poster_Path { get; set; }
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public IList<int> GenreIds { get; set; }
        public string Title { get; set; }
        public double Vote_Average { get; set; }
        public string Overview { get; set; }
        public string Release_Date { get; set; }
    }

    public class MovieTopRated
    {
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public List<Result> Results { get; set; }
    }
}
