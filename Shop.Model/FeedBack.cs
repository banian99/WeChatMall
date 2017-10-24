namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        [Key]
        public int FeId { get; set; }

        public int? FeCid { get; set; }

        [StringLength(500)]
        public string FeContent { get; set; }

        public DateTime? Fetime { get; set; }

        [StringLength(20)]
        public string Fetel { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
