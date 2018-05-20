using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatGurmani1.Modeli;

namespace ProjekatGurmani1.Modeli
{
    public class StavkeNarudzbe
    {
        public int id { get; set; }
        public int idNarudzbe { get; set; }
        public int idJela { get; set; }
        public StavkeNarudzbe() { }
        public StavkeNarudzbe(int id, int idNarudzbe, int idJela)
        {
            this.id = id;
            this.idNarudzbe = idNarudzbe;
            this.idJela = idJela;
        }
    }
}
