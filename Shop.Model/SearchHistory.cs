namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SearchHistory")]
    public partial class SearchHistory
    {
        [Key]
        public int SeId { get; set; }

        public int? SeCid { get; set; }

        [StringLength(50)]
        public string Secontent { get; set; }

        public DateTime? Setime { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
