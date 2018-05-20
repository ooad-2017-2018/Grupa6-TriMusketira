using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Modeli
{
    public class NarudzbaHrane
    {
        public int idNarudzbe { get; set; }
        public int idKupca { get; set; }
        public List<int> jela { get; set; }

        public NarudzbaHrane(int id, int idKupca)
        {
            this.idNarudzbe = id;
            this.idKupca = idKupca;
            this.jela = new List<int>();
        }

        public NarudzbaHrane() { }
    }
}
