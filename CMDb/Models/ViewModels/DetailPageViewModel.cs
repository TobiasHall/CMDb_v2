using CMDb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class DetailPageViewModel
    {
        public string ImdbId { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public IEnumerable<OmdbMovieRatingDto> Ratings { get; set; }

        public DetailPageViewModel(MovieDetailDto movieDetailDto)
        {
            this.ImdbId = movieDetailDto.ImdbId;
            this.NumberOfLikes = movieDetailDto.NumberOfLikes;
            this.NumberOfDislikes = movieDetailDto.NumberOfDislikes;
            this.Plot = movieDetailDto.Plot;
            this.Title = movieDetailDto.Title;
            this.Year = movieDetailDto.Year;
            this.Poster = movieDetailDto.Poster;
            this.Ratings = movieDetailDto.Ratings;
        }
    }
}
