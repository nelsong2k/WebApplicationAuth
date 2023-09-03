using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly WebApplicationAuthContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(WebApplicationAuthContext context, IWebHostEnvironment webHostEnvironment)
        {
            
            _context = context;

            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            // Liste des catégories par ordre alphabétique, en incluant les produits associés
            ViewBag.listeCategorie = _context.Categorie.Include(c => c.Produit).ToList().OrderBy(r => r.LIBELLE_CATEGORIE); // Charger les produits associés

            return View();
        }

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
