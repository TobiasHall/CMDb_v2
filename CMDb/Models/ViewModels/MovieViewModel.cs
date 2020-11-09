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

        public List<MovieDetailDto> MoviesOrderByYear { get; set; }
        public List<MovieDetailDto> MoviesOrderByTitle { get; set; }
        public List<MovieDetailDto> MoviesOrderByLikes { get; set; }
        public List<MovieDetailDto> MoviesOrderByDislikes { get; set; }

        public MovieViewModel(List<MovieDetailDto> movies)
        {
            this.Movies = movies;
            SetHomePageLists(movies);
            OrderListBy(movies);
            

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
        private void OrderListBy(List<MovieDetailDto> movies) 
        {
            MoviesOrderByYear = movies.OrderBy(o => o.Year).ToList();
            MoviesOrderByTitle = movies.OrderBy(o => o.Title).ToList();
            MoviesOrderByLikes = movies.OrderBy(o => o.NumberOfLikes).Reverse().ToList();
            MoviesOrderByDislikes = movies.OrderBy(o => o.NumberOfDislikes).Reverse().ToList();
        }
    }
}
