using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Data
{
    public interface IOmdb
    {        
        Task<OmdbMovieDto> GetMovie(string imdbId);

        Task<MovieViewModel> GetMovieViewModelIEnum(IEnumerable<CmdbMovieDto> cmdbDtoMovies);
        Task<DetailPageViewModel> GetDetailPageViewModel(CmdbMovieDto cmdbDtoMovies);
        Task<DetailPageViewModel> GetMovieByTitel(string titel);
        Task<SearchPageViewModel> GetMovieSearch(string titel);
    }
}
