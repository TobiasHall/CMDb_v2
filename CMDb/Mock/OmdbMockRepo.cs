using CMDb.Data;
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
    public class OmdbMockRepo : IOmdb
    {
        string basePath;
        public OmdbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Mock\\MockData\\";
        }

        public async Task<OmdbMovieDto> GetMovie(string testFile=null)
        {
            testFile = testFile ?? "joker.js";
            var result = GetTestData<OmdbMovieDto>(testFile);
            await Task.Delay(0);
            return result;
        }       

        public Task<IEnumerable<OmdbMovieDto>> GetMovies(IEnumerable<CmdbMovieDto> toplist)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieViewModel> GetMovieViewModel(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        {
            List<MovieDetailDto> movies;

            var listOfMovies = GetTestData<List<MovieDetailDto>>("MovieInfo.js");
            movies = listOfMovies;
            await Task.Delay(0);
            return new MovieViewModel(movies);
            
        }

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
