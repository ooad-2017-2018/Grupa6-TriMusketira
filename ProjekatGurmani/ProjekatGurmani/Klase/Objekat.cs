using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani.Klase
{
    class Objekat:Korisnik
    {
        public int id { get; set; }
        public Jelovnik jela { get; set; }

        public Objekat(string ime, string prezime, string adresa, string telefon, string username, string email, string grad, string password, int id, Jelovnik jela)
               : base(ime, prezime, adresa, telefon, username, password, email, grad)
        {
            this.id = id;
            this.jela = jela;

        }
        public Objekat() { }

    
    }
}
