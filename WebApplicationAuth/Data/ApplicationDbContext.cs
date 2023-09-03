using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationAuth.Data.Migrations;
using WebApplicationAuth.Models;

namespace WebApplicationAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categorie> Categorie { get; set; }

        public DbSet<Produit> Produit { get; set; }
    }
}
