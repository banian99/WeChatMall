namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            Favorite = new HashSet<Favorite>();
            OrderBillChi = new HashSet<OrderBillChi>();
            ProductReview = new HashSet<ProductReview>();
            ShopCart = new HashSet<ShopCart>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        [StringLength(50)]
        public string PCode { get; set; }

        [StringLength(50)]
        public string ProductSortId { get; set; }

        public int? PostUid { get; set; }

        [StringLength(50)]
        public string PName { get; set; }

        [StringLength(100)]
        public string PDescribe { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(500)]
        public string PContent { get; set; }

        [StringLength(500)]
        public string PImages { get; set; }

        [StringLength(20)]
        public string PIsPackage { get; set; }

        public DateTime? PTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite> Favorite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBillChi> OrderBillChi { get; set; }

        public virtual ProductSort ProductSort { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductReview> ProductReview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCart> ShopCart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
