using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMDb.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMDb.Controllers
{
    public class MovieController : Controller
    {
        private ICmdb cmdb;

        public MovieController(ICmdb cmdbRepo)
        {
            this.cmdb = cmdbRepo;
        }

        public async Task<IActionResult> Index()
        {
            var model = await cmdb.GetToplist();
            
            return View(model);
        }
    }
}
