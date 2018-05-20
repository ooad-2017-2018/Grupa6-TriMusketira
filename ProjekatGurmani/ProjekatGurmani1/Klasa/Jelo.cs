using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klase
{
    public class Jelo
    {
        public string nazivJela { get; set; }
        public int idJela { get; set; }
        public string vrsta { get; set; }
        public int cijena { get; set; }

        public Jelo(int id, string nazivJela, string vrsta, int cijena)
        {
            this.idJela = id;
            this.nazivJela = nazivJela;
            this.vrsta = vrsta;
            this.cijena = cijena;
        }

        public Jelo() { }
    }
}
