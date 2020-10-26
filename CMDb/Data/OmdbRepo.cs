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
        //IConfiguration configuration;
        private string baseUrl;
        private string key;
        IApiClient apiClient;
        public OmdbRepo(IConfiguration configuration, IApiClient apiClient)
        {
            baseUrl = configuration.GetValue<string>("OpenMovieDatabaseApi:BaseUrl");
            key = configuration.GetValue<string>("OpenMovieDatabaseApi:Key");
            this.apiClient = apiClient;

            //this.configuration = configuration;
        }
        public async Task<OmdbMovieDto> GetMovie(string imdbId)
        {

                return await apiClient.GetAsync<OmdbMovieDto>($"{baseUrl}{key}{imdbId}");
        }

        //Denna avnänds inte???
        //public async Task<IEnumerable<OmdbMovieDto>> GetMovies(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        //{

        //    using (HttpClient client = new HttpClient())
        //    {
        //        List<OmdbMovieDto> movies = new List<OmdbMovieDto>();
        //        foreach (var movie in cmdbDtoMovies)
        //        {
        //            string movieId = $"?i={movie.ImdbId}";
        //            string endpoint = $"{baseUrl}{movieId}{key}";
        //            var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
        //            response.EnsureSuccessStatusCode();
        //            var data = await response.Content.ReadAsStringAsync();
        //            var result = JsonConvert.DeserializeObject<OmdbMovieDto>(data);
        //            movies.Add(result);

        //        }

        //        //return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);

        //        return movies;
        //    }
        //}
        public async Task<MovieViewModel> GetMovieViewModel(IEnumerable<CmdbMovieDto> cmdbDtoMovies)
        {

            using (HttpClient client = new HttpClient())
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
        }


        //är detta en task eller bara en metod DetailPageViewModel getDetailPage()?
        public async Task<DetailPageViewModel> GetDetailPage(MovieDetailDto movieDetailDto)
        {
            return new DetailPageViewModel(movieDetailDto);
        }

    }
}
