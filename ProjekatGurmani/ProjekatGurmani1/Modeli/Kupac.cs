using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Modeli
{
    public class Kupac : Korisnik
    {
        public int id { get; set; }
        public List<int> narudzbe { get; set; }

        public Kupac(int id, string ime, string prezime, string adresa, string telefon, string username, string password, string email, string grad)
               : base(ime, prezime, adresa, telefon, username, password, email, grad)
        {
            this.id = id;
            this.narudzbe = new List<int>();

        }
        public Kupac() { }

    }

}