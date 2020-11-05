using CMDb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class DetailPageViewModel
    {
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public string Director { get; set; }
        public string Runtime { get; set; }
        public string Released { get; set; }
        public string Language { get; set; }
        public string ImdbId { get; set; }
        public IEnumerable<OmdbMovieRatingDto> Ratings { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public string Year { get; set; }


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
            this.Genre = movieDetailDto.Genre;
            this.Writer = movieDetailDto.Writer;
            this.Director = movieDetailDto.Director;
            this.Runtime = movieDetailDto.Runtime;
            this.Released = movieDetailDto.Released;
            this.Language = movieDetailDto.Language;
            this.Actors = movieDetailDto.Actors;
        }
    }
}
