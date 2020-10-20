using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb.Data;
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
            
            return View(model);
        }
    }
}