using CMDb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieRatingsViewModel
    {
        public string MovieSite { get; set; }
        public string Rating { get; set; }
        //public MovieRatingsViewModel(MoviesDto moviesDto)
        //{
        //    Rating = moviesDto.Rating[0];
        //}
    }
}
