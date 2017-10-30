namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notice")]
    public partial class Notice
    {
        [Key]
        public int Nid { get; set; }

        public int? NPostUid { get; set; }

        [StringLength(100)]
        public string NTitle { get; set; }

        [StringLength(500)]
        public string NContent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime NTime { get; set; }
    }
}
