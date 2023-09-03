using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Data
{
    public class WebApplicationAuthContext : DbContext
    {
        public WebApplicationAuthContext (DbContextOptions<WebApplicationAuthContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationAuth.Models.Categorie> Categorie { get; set; }

        public DbSet<WebApplicationAuth.Models.Produit> Produit { get; set; }
    }
}
