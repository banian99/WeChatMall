namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        [Key]
        public int Bid { get; set; }

        public int? BPostUid { get; set; }

        [StringLength(500)]
        public string BImage { get; set; }

        [StringLength(500)]
        public string BLink { get; set; }

        public DateTime? Btime { get; set; }
    }
}
