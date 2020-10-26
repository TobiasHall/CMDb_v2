using CMDb.Data;
using CMDb.Infrastructure;
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

        //Denna behövs inte längre på grund av FileHandler
        //private T GetTestData<T>(string testFile)
        //{
        //    string path = $"{basePath}{testFile}";
        //    string data = File.ReadAllText(path);
        //    var result = JsonConvert.DeserializeObject<T>(data);
        //    return result;
        //}
       public async Task<IEnumerable<CmdbMovieDto>> GetToplistWithRatingAndCount()
        {
            string testFile = "toplist.js";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }

        public async Task<IEnumerable<CmdbMovieDto>> GetToplistByPopularitAndCount()
        {
            string testFile = "toplist.js";
            var result = FileHandler.GetTestData<IEnumerable<CmdbMovieDto>>(basePath + testFile);
            await Task.Delay(0);
            return result;
        }
    }
}
