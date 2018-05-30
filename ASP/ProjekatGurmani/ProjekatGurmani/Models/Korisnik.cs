using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class Korisnik
    {
        [Display(Name = "Ime")]
        public string ime { get; set; }
        [Display(Name = "Prezime")]
        public string prezime { get; set; }
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Display(Name = "Br. telefona")]
        public string telefon { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Grad")]
        public string grad { get; set; }


        public Korisnik()
        {
            this.ime = "";
            this.prezime = "";
            this.adresa = "";
            this.telefon = "";
            this.username = "";
            this.password = null;
            this.grad = null;

        }

        public Korisnik(string ime, string prezime, string adresa, string tel, string username, string password, string email, string grad)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.telefon = tel;
            this.username = username;
            this.password = password;
            this.email = email;
            this.grad = grad;
        }


    }
}