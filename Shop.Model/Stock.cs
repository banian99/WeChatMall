namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [Key]
        public int Stid { get; set; }

        public int? Stnum { get; set; }

        [StringLength(50)]
        public string StPid { get; set; }

        public int? StBillid { get; set; }

        public DateTime? Sttime { get; set; }

        public virtual product product { get; set; }
    }
}
