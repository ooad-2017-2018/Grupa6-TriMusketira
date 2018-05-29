using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class Jelo
    {
        public string nazivJela { get; set; }
        public int id { get; set; }
        public string vrsta { get; set; }
        public int cijena { get; set; }
        public int idObjekta { get; set; }

        public Jelo(int id, string nazivJela, string vrsta, int cijena, int idObjekta)
        {
            this.id = id;
            this.nazivJela = nazivJela;
            this.vrsta = vrsta;
            this.cijena = cijena;
            this.idObjekta = idObjekta;
        }

        public Jelo() { }
    }
}