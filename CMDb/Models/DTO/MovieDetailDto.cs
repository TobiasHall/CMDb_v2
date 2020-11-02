using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.DTO
{
    public class MovieDetailDto
    {
        public string ImdbId { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public IEnumerable<OmdbMovieRatingDto> Ratings { get; set; }
        public string Genre { get; set; }
        public string Writer { get; set; }
        public string Director { get; set; }
        public string Runtime { get; set; }
        public string Released { get; set; }
        public string Language { get; set; }
        public string Actors { get; set; }

    }
}
