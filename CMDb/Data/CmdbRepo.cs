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
        }
        public async Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount(int count)
        {
            string endpoint = $"{baseUrl}{rating}&count={count}";
            return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);

        }
        public async Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount(int count)
        {
            string endpoint = $"{baseUrl}{popularity}&count={count}";
            return await apiClient.GetAsync<IEnumerable<CmdbMovieDto>>(endpoint);
        }

        public async Task<CmdbMovieDto> GetMovieFromCmdb(string id)
        {
            return await apiClient.GetAsync<CmdbMovieDto>($"{baseUrl}Movie/{id}");
        }
    }
}
