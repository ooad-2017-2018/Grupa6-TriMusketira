using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.ViewModel
{
	public class VMObjekat
	{
		public Objekat Objekat { get; set; }

		public bool DaLiJeDostupanUsername(string username)
		{
			DBObjekat DB = new DBObjekat();
			List<Objekat> objekti = UčitavanjeObjekata();
			if (objekti.FirstOrDefault(x => x.username == username) != null)
			{
				return false;
			}
			return true;
		}
		public List<Objekat> UčitavanjeObjekata()
		{
			DBObjekat DB = new DBObjekat();
			DB.ucitajObjekte();
			return DB.Objekti;
		}
		public void DodajObjekat(Objekat k)
		{
			DBObjekat DB = new DBObjekat();
			DB.unesiObjekat(k);
		}
	}
}
