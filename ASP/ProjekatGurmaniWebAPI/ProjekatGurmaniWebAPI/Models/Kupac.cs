namespace ProjekatGurmaniWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kupac")]
    public partial class Kupac
    {
        public int id { get; set; }

        public string ime { get; set; }

        public string prezime { get; set; }

        public string adresa { get; set; }

        public string telefon { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string grad { get; set; }

        public bool? deleted { get; set; }
    }
}
