using CMDb.Models.DTO;
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


        public CmdbRepo(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("CMDbApi:BaseUrl");
            rating = configuration.GetValue<string>("CMDbApi:ToplistByRating");

            //this.configuration = configuration;
        }
        public async Task<IEnumerable<CmdbMovieDto>> GetTopThreeMoviesByRating()
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}{rating}&count=10";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CmdbMovieDto>>(data);


                return result;
            }

        }
    }
}
