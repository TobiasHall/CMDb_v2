using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb.Data;
using CMDb.Models.DTO;
using CMDb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMDb.Controllers
{

    public class HomeController : Controller
    {
        private IOmdb omdb;
        private ICmdb cmdb;

        public HomeController(IOmdb openMovieDatabase, ICmdb cmdb)
        {
            this.omdb = openMovieDatabase;
            this.cmdb = cmdb;
        }

        public async Task<IActionResult> Index()
        {
            var toplist = await cmdb.GetToplistWithRatingAndCount();
            var model = await omdb.GetMovieViewModelIEnum(toplist);
            
            return View(model);
        }
        [HttpGet("Home/Test")]
        public async Task<IActionResult> Test(string id)
        {
            var test = await cmdb.GetDisLike(id);

            return View(test);
        }
        [HttpGet("Home/Search")]
        public async Task<IActionResult> Search(string id) 
        {

            var test = await omdb.GetMovieSearch(id);
            return View(test);
        }
    }
}