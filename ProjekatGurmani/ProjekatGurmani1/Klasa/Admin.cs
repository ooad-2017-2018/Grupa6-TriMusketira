using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.Klasa
{
	public class Admin
	{
		public String username { get; set; }
		public String password { get; }

		public Admin() {
			username = "admin";
			password = "admin";
		}
	}
}
