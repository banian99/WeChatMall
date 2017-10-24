namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductReview")]
    public partial class ProductReview
    {
        [Key]
        public int ProId { get; set; }

        public int? ProCid { get; set; }

        [StringLength(50)]
        public string ProPid { get; set; }

        [StringLength(500)]
        public string ProContent { get; set; }

        [StringLength(20)]
        public string ProStart { get; set; }

        [StringLength(500)]
        public string ProImages { get; set; }

        public DateTime? Protime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual product product { get; set; }
    }
}
