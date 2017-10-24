namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillChi")]
    public partial class OrderBillChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Ordcode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Ordpid { get; set; }

        public int? ordCid { get; set; }

        public int? Ordnum { get; set; }

        [Column(TypeName = "money")]
        public decimal? OrdPrice { get; set; }

        public int? OrdisReview { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual product product { get; set; }
    }
}
