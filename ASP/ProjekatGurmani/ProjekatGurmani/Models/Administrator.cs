using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekatGurmani.Models
{
    public class Administrator
    {
        public int ID { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public Administrator(int id, String ime, String prez, String user, String pass)
        {
            ID = id;
            Ime = ime;
            Prezime = prez;
            Username = user;
            Password = pass;
        }
    }
}