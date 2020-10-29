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
        public async Task<IActionResult> Detail(string imdbId)
        {//TODO:Lös så att det blir snyggare här, så att båda detail kan ta in en sträng
            //Gå det att lösa med att ha en bool som inparameter också
            var model = await cmdb.GetMovie(imdbId);
            var model2 = await omdb.GetDetailPageViewModel(model);

            return View(model2);
        }
        [HttpGet("Movie/Search")]
        public async Task<IActionResult> Search(string titel)
        {
            ModelState.Clear();
            var model = await omdb.GetMovieByTitel(titel);

            return View("detail", model);
        }

    }
}
