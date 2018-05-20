using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klase
{
    public class Narudzba
    {
        public int idNarudzbe { get; set; }
        public List<Jelo> jela { get; set; }

        public Narudzba (int id, List<Jelo> jela)
        {
            this.idNarudzbe = id;
            this.jela = jela;
        }

        public Narudzba() { }
    }
}
