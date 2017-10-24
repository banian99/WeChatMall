namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userInfo")]
    public partial class userInfo
    {
        [Key]
        public int Userid { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Upassword { get; set; }

        [StringLength(500)]
        public string Uphoto { get; set; }

        public DateTime? Ucreatetime { get; set; }
    }
}
