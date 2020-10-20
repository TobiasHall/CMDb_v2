using CMDb.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Data
{
    public interface IOpenMovieDatabase
    {
        Task<MoviesDto> GetMovie();
        
    }
}
