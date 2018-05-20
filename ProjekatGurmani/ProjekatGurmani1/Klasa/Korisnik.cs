using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klase
{
    public class Korisnik
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public string telefon{ get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string grad{ get; set; }


        public Korisnik(){
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
