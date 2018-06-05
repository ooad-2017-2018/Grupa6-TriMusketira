using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.ViewModel
{
	public class VMNarudzba
	{
		public NarudzbaHrane narudzba { get; set; }
		public List<NarudzbaHrane> NarudzbaKupca(Kupac k)
		{
			DBNarudzba DB = new DBNarudzba();
			DB.ucitajNarudzbe();
			List<NarudzbaHrane> narudzbe = DB.Narudzbe;
			List<NarudzbaHrane> dk = new List<NarudzbaHrane>();
			for (int i = 0; i < narudzbe.Count; i++)
			{
				if (narudzbe[i].idKupca == k.id)
				{
					dk.Add(narudzbe[i]);
				}
			}
			return dk;
		}
		public void prikazdetaljaNarudzbe(NarudzbaHrane narudzba)
		{

		}
	}
}
