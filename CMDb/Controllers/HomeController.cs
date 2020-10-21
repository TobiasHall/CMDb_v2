using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb.Data;
using CMDb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMDb.Controllers
{

    public class HomeController : Controller
    {
        private IOpenMovieDatabase openMovieDatabase;

        public HomeController(IOpenMovieDatabase openMovieDatabase)
        {
            this.openMovieDatabase = openMovieDatabase;
        }

        public async Task<IActionResult> Index()
        {
            var model = await openMovieDatabase.GetMovie();

            //    var model2 = new MovieRatingsViewModel()
            //    {
            //        MovieSite = model.Rating[0].Rating;
            //};
            //var model2 = new MovieRatingsViewModel(model)

            return View(model);
        }
    }
}