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

       public async Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount(int count)
        {
            string testFile = "toplist.json";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount(int count)
        {
            string testFile = "toplist.json";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<CmdbMovieDto> GetMovieFromCmdb(string id)
        {
            string testFile = "cmdbMovie.json";
            var result = FileHandler.GetTestData<CmdbMovieDto>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }
    }
}
