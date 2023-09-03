using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Controllers
{
    public class CategorieController : Controller
    {
        private readonly WebApplicationAuthContext _context;

        public CategorieController(WebApplicationAuthContext context)
        {
            _context = context;
        }

        // GET: Categorie
        public IActionResult Index()
        {
            // Récupérez les catégories depuis la base de données et envoyez-les à la vue
            var categories = _context.Categorie.ToList();
            return View(categories);
        }

        public IActionResult AjoutCategorie() 
        {
            try
            {
                ViewBag.listeCategorie = _context.Categorie.ToList(); 
                return View();
            }
            catch (Exception)
            {
                return NotFound(); // Utilisez NotFound() au lieu de HttpNotFound()
            }
        }

        [HttpPost]
        public IActionResult AjoutCategorie(Categorie categories) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categories.DATE_SAISIE = DateTime.Now;
                    _context.Categorie.Add(categories); 
                    _context.SaveChanges(); 
                }
                return RedirectToAction("AjoutCategorie");
            }
            catch (Exception)
            {
                return NotFound(); 
            }
        }

        public IActionResult SupprimerCategorie(int id)
        {
            try
            {
                Categorie categories = _context.Categorie.Find(id); //recherche de la categorie
                if (categories != null)
                {
                    _context.Categorie.Remove(categories); //supprimer la categorie
                    _context.SaveChanges(); //enregistrer le resultat
                }
                return RedirectToAction("AjoutCategorie");

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        public IActionResult ModifierCategorie(int id)
        {
            try
            {
                ViewBag.listeCategorie = _context.Categorie.ToList();
                Categorie categories = _context.Categorie.Find(id); //recherche de la categorie
                if (categories != null)
                {
                    return View("AjoutCategorie", categories);
                }
                return RedirectToAction("AjoutCategorie");

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ModifierCategorie(Categorie categories)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    categories.DATE_SAISIE = DateTime.Now;
                    _context.Entry(categories).State = EntityState.Modified; //modification de la categorie
                    _context.SaveChanges();
                }
                return RedirectToAction("AjoutCategorie");

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
