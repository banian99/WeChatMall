namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillFat")]
    public partial class OrderBillFat
    {
        [Key]
        [StringLength(50)]
        public string Ocode { get; set; }

        public int? OCid { get; set; }

        [StringLength(50)]
        public string OStatus { get; set; }

        [Column(TypeName = "money")]
        public decimal? OrderPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExpressPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? SumPrice { get; set; }

        public int? Payment { get; set; }

        public int? PostUid { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? PayTime { get; set; }

        public DateTime? PostTime { get; set; }

        public DateTime? ReceTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Payment Payment1 { get; set; }
    }
}
