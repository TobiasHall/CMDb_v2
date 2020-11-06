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
        public List<MovieDetailDto> Movies { get; set; }
        public List<MovieDetailDto> TopThreeMovies { get; set; }
        public List<MovieDetailDto> FourToRest { get; set; }

        public MovieViewModel(List<MovieDetailDto> movies)
        {
            this.Movies = movies;
            SetHomePageLists(movies);
            

        }

        private void SetHomePageLists(List<MovieDetailDto> movies) 
        {
            TopThreeMovies = new List<MovieDetailDto>();
            FourToRest = new List<MovieDetailDto>();
            for (int i = 0; i < movies.Count; i++)
            {
                if (i < 3)
                {
                    this.TopThreeMovies.Add(movies[i]);
                }
                else
                {
                    this.FourToRest.Add(movies[i]);
                }
            }
        }
    }
}
