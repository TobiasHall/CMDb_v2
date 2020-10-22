using CMDb.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class MovieViewModel
    {
        public string ImdbId { get; set; }


        private List<Movie> movies;


        public string SelectedMovie { get; set; }
        public IEnumerable<SelectListItem> Movies 
        {
            get
            {
                if (movies != null)
                {
                    return movies
                        .Select(movie => new SelectListItem()
                        {
                            Text = movie.ImdbId,
                            Value = movie.ImdbId
                        });
                        //.OrderBy();
                }
                return null;
            }
        }
        public MovieViewModel(CmdbMovieDto cmdbMovies, OmdbMovieDto moviesDto)
        {
            ImdbId = cmdbMovies.ImdbId;
        }
    }
}
