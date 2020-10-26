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
    public class OmdbMockRepo : IOmdb
    {
        string basePath;
        public OmdbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Mock\\MockData\\";
        }

        public async Task<DetailPageViewModel> GetDetailPage(MovieDetailDto movieDetailDto)
        {
            return new DetailPageViewModel(movieDetailDto);
        }

        public async Task<OmdbMovieDto> GetMovie(string testFile=null)
        {
            testFile = testFile ?? "joker.js";
            var result = FileHandler.GetTestData<OmdbMovieDto>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }       


        //Denna avnänds inte???
        //public async Task<IEnumerable<OmdbMovieDto>> GetMovies(IEnumerable<CmdbMovieDto> toplist)
        //{
        //    List<OmdbMovieDto> movies = new List<OmdbMovieDto>();
        //    foreach (var movie in toplist)
        //    {
        //        string testFile = "movies.js";
        //        var result = GetTestData<CmdbMovieDto>(testFile);
        //        await Task.Delay(0);
        //        //movies.Add();

        //    }

        //    //return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);

        //    return movies;
        //}

        public async Task<MovieViewModel> GetMovieViewModel(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        {
            List<MovieDetailDto> movies;

            var listOfMovies = FileHandler.GetTestData<List<MovieDetailDto>>(basePath + "MovieInfo.js");
            movies = listOfMovies;
            await Task.Delay(0);
            return new MovieViewModel(movies);
            
        }


        //Denna behövs inte nu på grund av FileHandler.getTestData
        //private T GetTestData<T>(string testFile)
        //{
        //    string path = $"{basePath}{testFile}";
        //    string data = File.ReadAllText(path);
        //    var result = JsonConvert.DeserializeObject<T>(data);
        //    return result;
        //}
    }
}
