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

        public MovieController(ICmdb cmdb, IOmdb omdb)
        {
            this.cmdb = cmdb;
            this.omdb = omdb;
        }

        public async Task<IActionResult> Index()
        {
            var cmdbMovies = await cmdb.GetToplistByPopularitAndCount(12);
            var model = await omdb.GetMovieViewModel(cmdbMovies);

            return View(model);
        }
        [HttpGet("Movie/Detail")]
        public async Task<IActionResult> Detail(string id)
        {
            var cmdbMovie = await cmdb.GetMovieFromCmdb(id);
            if (cmdbMovie == null)
            {
                var detailPageViewModel = await omdb.GetMovieFromOmdb(id);
                return View(detailPageViewModel);
            }
            else
            {
                var detailPageViewModel = await omdb.GetDetailPageViewModel(cmdbMovie);
                return View(detailPageViewModel);
            }
        }
    }
}
