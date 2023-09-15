using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicMVCApp_PracticeProject.Models;
using MusicMVCApp_PracticeProject.Data;
using System.Diagnostics;

namespace MusicMVCApp_PracticeProject.Controllers
{
    public class HomeController : Controller
    {


        private readonly MusicMVCAppContext _db;

        public HomeController(MusicMVCAppContext db)
        {
            _db = db;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            // Checking if the Artist table exists in the database. 
            return _db.Artist != null ?
                        View(await _db.Artist
                        .Include(a => a.ArtistSongs)
                        .ToListAsync()) :
                        Problem("Entity set 'MusicMVCAppContext.Artist'  is null.");
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}