using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.ViewModel
{
	public class VMAdministrator
	{
		public Administrator Admin { get; set; }
		public void ObrisiKupca(String username)
		{
			DBKupac DB = new DBKupac();
			VMKupac v;
			v = new VMKupac();
			List<Kupac> temp = v.UčitavanjeKupaca();
			Kupac k = temp.FirstOrDefault(x => x.username == username);
			if (k != null)
				DB.brisiKupca(k);
		}
		public void ObrisiObjekat(String username)
		{
			DBObjekat DB = new DBObjekat();
			VMObjekat v;
			v = new VMObjekat();
			List<Objekat> temp = v.UčitavanjeObjekata();
			Objekat k = temp.FirstOrDefault(x => x.username == username);
			if (k != null)
				DB.brisiObjekat(k);
		}
		public void PrikaziStatistiku(String username)
		{

		}

		public List<Administrator> UcitavanjeAdministratora()
		{
			DBAdministrator DB = new DBAdministrator();
			DB.ucitajAdministratore();
			return DB.Administratori;
		}
	}
}
