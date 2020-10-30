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
    public class MovieController : Controller
    {
        private ICmdb cmdb;
        private IOmdb omdb;

        public MovieController(ICmdb cmdbRepo, IOmdb omdb)
        {
            this.cmdb = cmdbRepo;
            this.omdb = omdb;
        }

        public async Task<IActionResult> Index()
        {
            var cmdbMovies = await cmdb.GetToplistByPopularitAndCount();
            var model = await omdb.GetMovieViewModelIEnum(cmdbMovies);


            return View(model);
        }
        [HttpGet("Movie/Detail")]
        public async Task<IActionResult> Detail(string id)
        {
            var model = await cmdb.GetMovie(id);
            var model2 = await omdb.GetDetailPageViewModel(model);

            return View(model2);
        }
        [HttpGet("Movie/Search")]
        public async Task<IActionResult> Search(string id)
        {
            var model2 = await cmdb.GetMovie(id);

            if (model2 == null)
            {
                var model = await omdb.GetMovieById(id);
                return View("detail", model);
            }
            else
            { 
                var model3 = await omdb.GetDetailPageViewModel(model2);
                return View("detail", model3);
            }
        }

    }
}
