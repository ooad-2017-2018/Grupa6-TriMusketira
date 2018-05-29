using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class Narudzba
    {
        public int id { get; set; }
        public int idKupca { get; set; }
        public List<int> jela { get; set; }

        public Narudzba(int id, int idKupca)
        {
            this.id = id;
            this.idKupca = idKupca;
            this.jela = new List<int>();
        }

        public Narudzba() { }
    }
}