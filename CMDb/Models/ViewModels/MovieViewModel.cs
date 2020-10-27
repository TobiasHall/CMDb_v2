using CMDb.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieViewModel
    {
        //public string Title { get; set; }
        //public string Year { get; set; }
        //public string Plot { get; set; }
        //public string Poster { get; set; }
        //public IEnumerable<OmdbMovieRatingDto> Ratings { get; set; }
        
        //public string ImdbId { get; set; }        
        //public int NumberOfLikes { get; set; }
        //public int NumberOfDislikes { get; set; }
        //public string Genre { get; set; }



        public List<MovieDetailDto> Movies { get; set; }
        public List<MovieDetailDto> TopFourToT { get; set; }


        public MovieViewModel(List<MovieDetailDto> movies)
        {
            this.Movies = movies;           
        }        
    }
}
