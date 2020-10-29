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
        
        public async Task<OmdbMovieDto> GetMovie(string testFile=null)
        {
            testFile = testFile ?? "joker.json";
            var result = FileHandler.GetTestData<OmdbMovieDto>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<DetailPageViewModel> GetMovieById(string title)
        {            
            string testfile = "joker.json";
            var result = FileHandler.GetTestData<MovieDetailDto>(basePath + testfile);
            await Task.Delay(0);
            return new DetailPageViewModel(result);
        }


        public async Task<DetailPageViewModel> GetDetailPageViewModel(CmdbMovieDto cmdbDtoMovies)
        {
            string testFile = "DetailPageVM.json";
            var result = FileHandler.GetTestData<MovieDetailDto>(basePath + testFile);
            await Task.Delay(0);
            return new DetailPageViewModel(result);
        }

        public async Task<MovieViewModel> GetMovieViewModelIEnum(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        {
            List<MovieDetailDto> movies;

            var listOfMovies = FileHandler.GetTestData<List<MovieDetailDto>>(basePath + "MovieInfo.json");
            movies = listOfMovies;
            await Task.Delay(0);
            return new MovieViewModel(movies);
            
        }

        Task<SearchPageViewModel> GetMovieSearch(string titel)
        {
            throw new NotImplementedException();
        }

        Task<SearchPageViewModel> IOmdb.GetMovieSearch(string titel)
        {
            throw new NotImplementedException();
        }
    }
}
