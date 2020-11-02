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
            if (model == null)
            {
                var model2 = await omdb.GetMovieById(id);
                return View(model2);
            }
            else
            {
                var model3 = await omdb.GetDetailPageViewModel(model);
                return View(model3);
            }
        }
    }
}
