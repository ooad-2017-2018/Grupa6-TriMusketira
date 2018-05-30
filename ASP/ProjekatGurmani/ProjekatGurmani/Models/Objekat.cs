using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class Objekat : Korisnik
    {
        public int id { get; set; }
        [Display(Name = "Naziv objekta")]
        public String naziv { get; set; }
        public List<int> jela { get; set; }

        public Objekat(int id, string ime, string prezime, string adresa, string telefon, string username, string password, string email, string grad, string naziv)
               : base(ime, prezime, adresa, telefon, username, password, email, grad)
        {
            this.id = id;
            this.naziv = naziv;
            this.jela = new List<int>();

        }
        public Objekat() { }


    }
}