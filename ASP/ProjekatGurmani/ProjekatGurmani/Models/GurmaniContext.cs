using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class GurmaniContext : DbContext
    {
        public GurmaniContext() : base("AzureConnection") //AzureConnection je naziv connection stringa u Web.config-u
        {
        }
        //dodavanjem klasa iz modela kao DbSet iste će biti mapirane u bazu podataka
        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<StavkeNarudzbe> stavkeNarudzba { get; set; }
        public DbSet<Objekat> Objekti { get; set; }
        public DbSet<Jelo> Jela { get; set; }
        //Ova funkcija se koristi da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}