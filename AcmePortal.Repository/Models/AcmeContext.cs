using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcmePortal.Repository.Models
{
    public partial class AcmeContext : DbContext
    {
        public AcmeContext()
        {
        }

        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcmeActivity> AcmeActivity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcmeActivity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(256);
            });
        }
    }
}
