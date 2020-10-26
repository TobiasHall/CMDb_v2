using CMDb.Data;
using CMDb.Infrastructure;
using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Mock
{
    public class CmdbMockRepo : ICmdb
    {
        string basePath;
        public CmdbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Mock\\MockData\\";
        }

       public async Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount()
        {
            string testFile = "toplist.js";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount()
        {
            string testFile = "toplist.js";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<CmdbMovieDto> GetMovie(string id)
        {
            string testFile = "cmdbMovie.js";
            var result = FileHandler.GetTestData<CmdbMovieDto>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public Task<CmdbMovieDto> GetLike(string imdbId)
        {
            throw new NotImplementedException();
        }

        public Task<CmdbMovieDto> GetDisLike(string imdbId)
        {
            throw new NotImplementedException();
        }
    }
}
