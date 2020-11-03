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
        Task<CmdbMovieDto> GetMovieFromCmdb(string id);
        Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount(int count);
        Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount(int count);
    }
}
