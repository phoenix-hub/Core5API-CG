using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ApiApp.Models
{
    public partial class WideWorldImportersContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<CustomerDto> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Customers", "Website");

                entity.Property(e => e.AlternateContact).HasMaxLength(50);

                entity.Property(e => e.BuyingGroupName).HasMaxLength(50);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.CustomerCategoryName).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryMethod).HasMaxLength(50);

                entity.Property(e => e.DeliveryRun).HasMaxLength(5);

                entity.Property(e => e.FaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PrimaryContact).HasMaxLength(50);

                entity.Property(e => e.RunPosition).HasMaxLength(5);

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("WebsiteURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
