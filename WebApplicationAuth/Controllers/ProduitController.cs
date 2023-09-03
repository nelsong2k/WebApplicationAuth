using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Data;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Controllers
{
    public class ProduitController : Controller
    {
        private readonly WebApplicationAuthContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProduitController(WebApplicationAuthContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;

            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Produit
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult AjoutProduit()
        {
            try
            {

                ViewBag.listeCategorie = _context.Categorie.ToList();

                ViewBag.listeProduit = _context.Produit.ToList();

                return View();
            }
            catch (Exception e)
            {

                return NotFound(e);
            }


        }


        [HttpPost]
        public IActionResult AjoutProduit(Produit produits, int CODE_CATEGORIE, IFormFile imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Fichier", fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            imageFile.CopyTo(fileStream);
                        }

                        produits.IMAGE_PRODUIT = fileName;
                        produits.URL_IMAGE_PRODUIT = "/Fichier/" + fileName;
                    }

                    produits.DATE_SAISIE = DateTime.Now;
                    Categorie categories = _context.Categorie.Find(CODE_CATEGORIE);
                    produits.Categorie = categories;
                    _context.Produit.Add(produits);
                    _context.SaveChanges();

                }

                return RedirectToAction("AjoutProduit");
            }
            catch (Exception)
            {
                return NotFound();
            }

        }


        public IActionResult SupprimerProduit(int id)
        {
            try
            {
                Produit produits = _context.Produit.Find(id); //recherche du produit
                if (produits != null)
                {
                    _context.Produit.Remove(produits); //supprimer le produit
                    _context.SaveChanges(); //enregistrer le resultat
                }
                return RedirectToAction("AjoutProduit");

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        public IActionResult ModifierProduit(int id, int CODE_CATEGORIE)
        {
            try
            {
                ViewBag.listeCategorie = _context.Categorie.ToList();
                ViewBag.listeProduit = _context.Produit.ToList();
                Produit produits = _context.Produit.Find(id); //recherche du produit
                Categorie categories = _context.Categorie.Find(CODE_CATEGORIE);
                if (produits != null)
                {
                    return View("AjoutProduit", produits);
                }
                return RedirectToAction("AjoutProduit");

            }
            catch (Exception e)
            {
                return NotFound();
            }
        }


        
        [HttpPost]
        public IActionResult ModifierProduit(Produit produits, int CODE_CATEGORIE, IFormFile ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produits.DATE_SAISIE = DateTime.Now;

                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        // L'utilisateur a téléchargé une nouvelle image, traitez-la et mettez à jour le chemin
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Fichier", uniqueFileName);

                        using (var fileStream = new FileStream(imagePath, FileMode.Create))
                        {
                            ImageFile.CopyTo(fileStream);
                        }


                        produits.IMAGE_PRODUIT = uniqueFileName;
                        produits.URL_IMAGE_PRODUIT = "/Fichier/" + uniqueFileName;
                    }

                    Categorie categories = _context.Categorie.Find(CODE_CATEGORIE);
                    produits.Categorie = categories;

                    _context.Entry(produits).State = EntityState.Modified; // Modification du produit
                    _context.SaveChanges();
                }
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
