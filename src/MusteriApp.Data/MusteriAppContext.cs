using Microsoft.EntityFrameworkCore;
using MusteriApp.Data.Entities;

namespace MusteriApp.Data
{
    public class MusteriAppContext : DbContext
    {
        public MusteriAppContext(DbContextOptions<MusteriAppContext> options)
            : base(options)
        {
        }

        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musteri>()
                .Property(m => m.UNVAN)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
