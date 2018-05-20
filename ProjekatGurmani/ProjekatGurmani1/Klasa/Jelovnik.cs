using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klase
{
    public class Jelovnik
    {
        public List<Jelo> listaJela { get; set; }


        public Jelovnik (List<Jelo> listaJela)
        {
            this.listaJela = listaJela;
        }

        public Jelovnik() { }
    }
}
