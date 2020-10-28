using CMDb.Infrastructure;
using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CMDb.Data
{
    public class OmdbRepo : IOmdb
    {
        private string baseUrl;
        private string key;
        IApiClient apiClient;
        public OmdbRepo(IConfiguration configuration, IApiClient apiClient)
        {
            baseUrl = configuration.GetValue<string>("OpenMovieDatabaseApi:BaseUrl");
            key = configuration.GetValue<string>("OpenMovieDatabaseApi:Key");
            this.apiClient = apiClient;
            
        }
        public async Task<OmdbMovieDto> GetMovie(string imdbId)
        {

                return await apiClient.GetAsync<OmdbMovieDto>($"{baseUrl}{key}{imdbId}");
        }
        public async Task<DetailPageViewModel> GetMovieByTitel(string titel)
        {
            string movieId = $"?s={titel}";
            var result = await apiClient.GetAsync<MovieDetailDto>($"{baseUrl}{movieId}{key}");
            
            return new DetailPageViewModel(result);            
        }

        public async Task<MovieViewModel> GetMovieViewModelIEnum(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        {           
                List<MovieDetailDto> movies = new List<MovieDetailDto>();                
                
                foreach (var movie in cmdbDtoMovies)
                {
                    string movieId = $"?i={movie.ImdbId}";
                    var result = await apiClient.GetAsync<MovieDetailDto>($"{baseUrl}{movieId}{key}");
                    result.NumberOfLikes = movie.NumberOfLikes;
                    result.NumberOfDislikes = movie.NumberOfDislikes;                    
                    movies.Add(result);
                }

                return new MovieViewModel(movies);         
        }

        public async Task<DetailPageViewModel> GetMovieViewModel(CmdbMovieDto cmdbDtoMovies)
        {
            string movieId = $"?i={cmdbDtoMovies.ImdbId}";
            var result = await apiClient.GetAsync<MovieDetailDto>($"{baseUrl}{movieId}{key}");
            result.NumberOfLikes = cmdbDtoMovies.NumberOfLikes;
            result.NumberOfDislikes = cmdbDtoMovies.NumberOfDislikes;

            return new DetailPageViewModel(result);
        }
    }
}
