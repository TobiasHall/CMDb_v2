using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.DTO
{
    public class SearchDetailDto
    {
        public IEnumerable<OmdbMovieDto> Search { get; set; }
        public int TotalResult { get; set; }
        public bool Response { get; set; }
    }
}
