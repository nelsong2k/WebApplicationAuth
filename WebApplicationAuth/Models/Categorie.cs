using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationAuth.Models
{
    public class Categorie
    {
        [Key]
        public int CODE_CATEGORIE { get; set; }
        public string LIBELLE_CATEGORIE { get; set; }
        public DateTime DATE_SAISIE { get; set; }

        public ICollection<Produit> Produit { get; set; }
    }
}
