using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using ProjekatGurmani1.ViewModel;

namespace ProjekatGurmani1.Modeli
{
    public class NarudzbaHrane
    {
		private const  int besplatno = 6;
        public int idNarudzbe { get; set; }
        public Kupac kupac { get; set; }
		public int idKupca { get; set; }
		public List<Jelo> jela { get; set; }

        public NarudzbaHrane(int id, int idd)
        {
            this.idNarudzbe = id;
			this.idKupca = idd;
            this.jela = new List<Jelo>();
        }

        public NarudzbaHrane() { }
		public double cijenaNarudzbe()
		{
			VMKupac Kupac = new VMKupac();
			List<Kupac> kupci = Kupac.UčitavanjeKupaca();
			int br=0;
			double cijena = 0;
			Kupac kupac;
			foreach (Kupac k in kupci)
				if (k.id.Equals(idKupca)) br = k.brojNaruzdbi;
			if (br == besplatno) return 0;
			foreach (Jelo j in jela)
				cijena += j.cijena;
			return cijena;
		}
    }
}
