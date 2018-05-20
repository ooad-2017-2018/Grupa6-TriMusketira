using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Modeli
{
    public class Jelo
    {
        public string nazivJela { get; set; }
        public int idJela { get; set; }
        public string vrsta { get; set; }
        public int cijena { get; set; }
        public int idObjekta { get; set; }

        public Jelo(int id, string nazivJela, string vrsta, int cijena, int idObjekta)
        {
            this.idJela = id;
            this.nazivJela = nazivJela;
            this.vrsta = vrsta;
            this.cijena = cijena;
            this.idObjekta = idObjekta;
        }

        public Jelo() { }
    }
}
