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

        public async Task<IActionResult> Detail(MovieDetailDto movie)
        {
            var model = await cmdb.GetMovie(movie.ImdbId);
            var model2 = await omdb.GetMovieViewModel(model);

            return View(model2);
        }
    }
}
