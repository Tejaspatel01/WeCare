namespace WeCare.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Complain> Complains { get; set; }
        public virtual DbSet<DonateItem> DonateItems { get; set; }
        public virtual DbSet<DonateMoney> DonateMoneys { get; set; }
        public virtual DbSet<Help> Helps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complain>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Complain>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Complain>()
                .Property(e => e.Complain1)
                .IsUnicode(false);

            modelBuilder.Entity<Complain>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Complain>()
                .Property(e => e.PoliceStationAdd)
                .IsUnicode(false);

            modelBuilder.Entity<DonateItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DonateItem>()
                .Property(e => e.DonatedItem)
                .IsUnicode(false);

            modelBuilder.Entity<DonateItem>()
                .Property(e => e.ModeOfDelivery)
                .IsUnicode(false);

            modelBuilder.Entity<DonateMoney>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DonateMoney>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<DonateMoney>()
                .Property(e => e.Mode)
                .IsUnicode(false);

            modelBuilder.Entity<Help>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Help>()
                .Property(e => e.HelpType)
                .IsUnicode(false);

            modelBuilder.Entity<Help>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
