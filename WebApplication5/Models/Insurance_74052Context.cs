using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Working.Models
{
    public partial class Insurance_74052Context : DbContext
    {
        public Insurance_74052Context()
        {
        }

        public Insurance_74052Context(DbContextOptions<Insurance_74052Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=Insurance_74052;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("insurance");

                entity.Property(e => e.Insuranceid).HasColumnName("insuranceid");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.History)
                    .HasColumnName("history")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Instatus)
                    .HasColumnName("instatus")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Insurancefor)
                    .HasColumnName("insurancefor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__insurance__empid__29572725");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.ToTable("login");

                entity.Property(e => e.Empid).HasColumnName("empid");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
