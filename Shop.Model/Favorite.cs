namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Favorite")]
    public partial class Favorite
    {
        [Key]
        public int Fid { get; set; }

        [StringLength(50)]
        public string FavPid { get; set; }

        public int? FavCid { get; set; }

        public DateTime? Ftime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual product product { get; set; }
    }
}
