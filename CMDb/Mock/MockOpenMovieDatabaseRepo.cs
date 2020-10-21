using CMDb.Data;
using CMDb.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Mock
{
    public class MockOpenMovieDatabaseRepo : IOpenMovieDatabase
    {
        string basePath;
        public MockOpenMovieDatabaseRepo(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Mock\\MockData\\";
        }
        public async Task<MoviesDto> GetMovie()
        {
            string testFile = "joker.js";
            var result = GetTestData<MoviesDto>(testFile);
            await Task.Delay(0);
            return result;
        }


        //public async Task<MoviesDto> GetMovie2(string movieSite)
        //{
        //    string testFile = "joker.js";
        //    var result = GetTestData<MoviesDto>(testFile);
        //    RatingsDto moviesDto = result.Ratings.Where(x => x.Value.Equals(movieSite)).FirstOrDefault();
        //    return result;
        //}

        /// <summary>
        /// Generisk klass
        /// </summary>
        /// <param name="testFile"></param>
        private T GetTestData<T>(string testFile)
        {
            string path = $"{basePath}{testFile}";
            string data = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }
    }
}
