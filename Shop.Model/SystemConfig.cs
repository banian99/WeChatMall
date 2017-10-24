namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [Key]
        public int Syid { get; set; }

        [StringLength(50)]
        public string SyParmname { get; set; }

        [StringLength(50)]
        public string SyParmValue { get; set; }
    }
}
