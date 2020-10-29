using CMDb.Infrastructure;
using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CMDb.Data
{
    public class CmdbRepo : ICmdb
    {
        private string baseUrl;
        private string rating;
        private string popularity;
        private IApiClient apiClient;


        public CmdbRepo(IConfiguration configuration, IApiClient apiClient)
        {
            baseUrl = configuration.GetValue<string>("CMDbApi:BaseUrl");
            rating = configuration.GetValue<string>("CMDbApi:ToplistByRating");
            popularity = configuration.GetValue<string>("CMDbApi:ToplistByPopularity");
            this.apiClient = apiClient;
            //this.configuration = configuration;
        }
        public async Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount()
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}{rating}&count=10";
                

                return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);


                //var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                //var data = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<IEnumerable<CmdbMovieDto>>(data);


                //return result;
            }

        }
        public async Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount()
        {

                string endpoint = $"{baseUrl}{popularity}&count=10";
                return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);

                //var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                //response.EnsureSuccessStatusCode();
                //var data = await response.Content.ReadAsStringAsync();
                //var result = JsonConvert.DeserializeObject<IEnumerable<CmdbMovieDto>>(data);
                //return result;
        }

        public async Task<CmdbMovieDto> GetMovie(string id)
        {
            return  await apiClient.GetAsync<CmdbMovieDto>($"{baseUrl}Movie/{id}");
        }
        public async Task<CmdbMovieDto> GetLike(string imdbId)
        {
            return await apiClient.GetAsync<CmdbMovieDto>($"{baseUrl}Movie/{imdbId}/like");

        }
        public async Task<CmdbMovieDto> GetDisLike(string imdbId)
        {
            return await apiClient.GetAsync<CmdbMovieDto>($"{baseUrl}Movie/{imdbId}/dislike");

        }
    }
}
