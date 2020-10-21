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
    public class MockCmdbRepo : ICmdb
    {
        string basePath;
        public MockCmdbRepo(IWebHostEnvironment webHostEnvironment)
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
       public async Task<IEnumerable<CmdbDto>> GetToplist()
        {
            string testFile = "Toplist.json";
            var result = GetTestData<IEnumerable<CmdbDto>>(testFile);
            await Task.Delay(0);
            return result;
        }




    }
}
