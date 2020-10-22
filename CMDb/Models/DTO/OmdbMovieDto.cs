using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.DTO
{
    public class OmdbMovieDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public IEnumerable<OmdbMovieRatingDto> Ratings { get; set; }

    }
}
