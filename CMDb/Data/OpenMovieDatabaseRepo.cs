using CMDb.Models.DTO;
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
    public class OpenMovieDatabaseRepo : IOpenMovieDatabase
    {
        //IConfiguration configuration;
        private string baseUrl;
        private string key;
        public OpenMovieDatabaseRepo(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("OpenMovieDatabaseApi:BaseUrl");
            key = configuration.GetValue<string>("OpenMovieDatabaseApi:Key");


            //this.configuration = configuration;
        }
        public async Task<MoviesDto> GetMovie(string imdbId)
        {
            
            using (HttpClient client = new HttpClient())
            {
                string movieId = $"?i={imdbId}";
                string endpoint = $"{baseUrl}{key}{movieId}";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MoviesDto>(data);


                return result;
            }
        }
        public async Task<IEnumerable<MoviesDto>> GetMovies(IEnumerable<CmdbDto> cmdbDtoMovies)
        {

            using (HttpClient client = new HttpClient())
            {
                List<MoviesDto> movies = new List<MoviesDto>();
                foreach (var movie in cmdbDtoMovies)
                {
                    string movieId = $"?i={movie.ImdbId}";
                    string endpoint = $"{baseUrl}{movieId}{key}";
                    var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<MoviesDto>(data);
                    movies.Add(result);

                }


                return movies;
            }
        }
    }
}
