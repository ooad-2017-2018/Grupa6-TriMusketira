namespace ProjekatGurmaniWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jelo")]
    public partial class Jelo
    {
        public int id { get; set; }

        public string nazivJela { get; set; }

        public string vrsta { get; set; }

        public int cijena { get; set; }

        public int idObjekta { get; set; }

        public bool? deleted { get; set; }
    }
}
