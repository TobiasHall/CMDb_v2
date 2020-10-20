using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.DTO
{
    public class MoviesDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public IEnumerable<RatingsDto> Rating { get; set; }

    }
}
