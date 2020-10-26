using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Data
{
    public interface ICmdb
    {
        Task<CmdbMovieDto> GetMovie(string id);
        Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount();
        Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount();
    }
}
