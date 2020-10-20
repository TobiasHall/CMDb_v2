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
        public async Task<MoviesDto> GetMovie()
        {
            //TODO: Fixa något
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}?t=joker{key}";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<MoviesDto>(data);


                return result;
            }

        }        
    }
}
