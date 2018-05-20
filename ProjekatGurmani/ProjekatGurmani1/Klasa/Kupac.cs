using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klase
{
    public class Kupac: Korisnik
    {
        public int id { get; set; }
        public List<Narudzba> narudzbe { get; set; }

        public Kupac(string ime, string prezime, string adresa, string telefon, string username, string email, string grad, string password, int id, List<Narudzba> narudzbe)
               : base(ime, prezime, adresa, telefon, username, password, email, grad)
        {
            this.id = id;
            this.narudzbe = narudzbe;
            
        }
        public Kupac() { }

    }

}
