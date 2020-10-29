using CMDb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Models.ViewModels
{
    public class SearchPageViewModel
    {
        public IEnumerable<OmdbMovieDto> Searches { get; set; }

        public SearchPageViewModel(SearchDetailDto searchDetailDto)
        {
            this.Searches = searchDetailDto.Search;
            
        }


    }
}
