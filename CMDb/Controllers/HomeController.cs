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
            //var model = await openMovieDatabase.GetMovies(toplist);

            var model = await omdb.GetMovieViewModelIEnum(toplist);
            
            
            //    var model2 = new MovieRatingsViewModel()
            //    {
            //        MovieSite = model.Rating[0].Rating;
            //};
            //var model2 = new MovieRatingsViewModel(model)

            return View(model);
        }
    }
}