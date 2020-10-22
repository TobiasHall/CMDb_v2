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

        //public async Task<MovieRatingsViewModel> GetMovieRatingsViewModel(string movie=null)
        //{
        //    //Hämta filmer från CMDB
        //    //Hämta infor från omdb
        //    //skicka in dessa in i MovieRatingVM

        //    movie = movie ?? "ett defaultvärde";
        //    string topList = "Toplist.js";
        //    var cmdbMovies = GetTestData<CmdbDto>(topList);
        //    var omdbMovies = GetTestData<CmdbDto>("Movies.json");
        //    await Task.Delay(0);
        //    MovieRatingsViewModel 
        //    return result;
        //}


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
