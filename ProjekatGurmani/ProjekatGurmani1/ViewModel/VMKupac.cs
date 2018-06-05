using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.ViewModel
{
	public class VMKupac
	{
		public Kupac kupac { get; set; }

		public bool DaLiJeDostupanUsername(string username)
		{
			DBKupac DB = new DBKupac();
			List<Kupac> kupci = UčitavanjeKupaca();
			if (kupci.FirstOrDefault(x => x.username == username) != null)
			{
				return false;
			}
			return true;
		}
		public List<Kupac> UčitavanjeKupaca()
		{
			DBKupac DB = new DBKupac();
			DB.ucitajKupce();
			return DB.Kupci;
		}
		public void DodajKupca(Kupac k)
		{
			DBKupac DB = new DBKupac();
			DB.unesiKupca(k);
		}
	}

}
