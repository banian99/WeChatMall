namespace Shop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeShop : DbContext
    {
        public WeShop()
            : base("name=WeShop")
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChi { get; set; }
        public virtual DbSet<OrderBillFat> OrderBillFat { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<ProductReview> ProductReview { get; set; }
        public virtual DbSet<ProductSort> ProductSort { get; set; }
        public virtual DbSet<SearchHistory> SearchHistory { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<userInfo> userInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Favorite)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.FavCid);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.FeedBack)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.FeCid);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderBillChi)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.ordCid);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.OrderBillFat)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.OCid);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ProductReview)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.ProCid);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.SearchHistory)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.SeCid);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.OrdPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFat>()
                .Property(e => e.OrderPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFat>()
                .Property(e => e.ExpressPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFat>()
                .Property(e => e.SumPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.OrderBillFat)
                .WithOptional(e => e.Payment1)
                .HasForeignKey(e => e.Payment);

            modelBuilder.Entity<product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Favorite)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.FavPid);

            modelBuilder.Entity<product>()
                .HasMany(e => e.OrderBillChi)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Ordpid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.ProductReview)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.ProPid);

            modelBuilder.Entity<product>()
                .HasMany(e => e.ShopCart)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.SPcode);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Stock)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.StPid);

            modelBuilder.Entity<ProductSort>()
                .HasMany(e => e.product)
                .WithOptional(e => e.ProductSort)
                .HasForeignKey(e => e.ProductSortId);
        }
    }
}
