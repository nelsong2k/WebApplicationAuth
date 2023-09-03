using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAuth.Models
{
    public class Produit
    {
        [Key]
        public int CODE_PRODUIT { get; set; }
        public string LIBELLE_PRODUIT { get; set; }
        public string DESCRIPTION_PRODUIT { get; set; }
        public string IMAGE_PRODUIT { get; set; }
        public string URL_IMAGE_PRODUIT { get; set; }
        public DateTime DATE_SAISIE { get; set; }

        //public int CODE_CATEGORIE { get; set; } // Clé étrangère pour la relation avec Catégorie
        public Categorie Categorie { get; set; } // Propriété de navigation vers la catégorie
    }
}
