using CMDb.Data;
using CMDb.Models.DTO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Mock
{
    public class CmdbMockRepo : ICmdb
    {
        string basePath;
        public CmdbMockRepo(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Mock\\MockData\\";
        }

        private T GetTestData<T>(string testFile)
        {
            string path = $"{basePath}{testFile}";
            string data = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }
       public async Task<IEnumerable<CmdbMovieDto>> GetTopThreeMoviesByRating()
        {
            string testFile = "toplist.js";
            var result = GetTestData<IEnumerable<CmdbMovieDto>>(testFile);
            await Task.Delay(0);
            return result;
        }




    }
}
