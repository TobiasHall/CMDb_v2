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
        Task<IEnumerable<OmdbMovieDto>> GetMovies(IEnumerable<CmdbMovieDto> toplist);
        Task<MovieViewModel> GetMovieViewModel(IEnumerable<CmdbMovieDto> cmdbDtoMovies);
    }
}
