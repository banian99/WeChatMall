namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopCart")]
    public partial class ShopCart
    {
        [Key]
        public int ScartId { get; set; }

        [StringLength(50)]
        public string SPcode { get; set; }

        public int? SNum { get; set; }

        public int? SCid { get; set; }

        public int? Sischeck { get; set; }

        public DateTime? STime { get; set; }

        public virtual product product { get; set; }
    }
}
