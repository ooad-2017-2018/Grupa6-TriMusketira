namespace ProjekatGurmaniWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StavkeNarudzbe")]
    public partial class StavkeNarudzbe
    {
        public int id { get; set; }

        public int idNarudzbe { get; set; }

        public int idJela { get; set; }

        public bool? deleted { get; set; }
    }
}
