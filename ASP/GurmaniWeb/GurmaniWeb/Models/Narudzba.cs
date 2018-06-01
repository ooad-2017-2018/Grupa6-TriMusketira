namespace GurmaniWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Narudzba")]
    public partial class Narudzba
    {
        public int id { get; set; }

        public int idKupca { get; set; }

        public bool? deleted { get; set; }
    }
}
