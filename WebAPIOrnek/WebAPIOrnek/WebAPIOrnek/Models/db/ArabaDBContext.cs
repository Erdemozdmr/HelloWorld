using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIOrnek.Models.db
{
    public partial class ArabaDBContext : DbContext
    {
        public ArabaDBContext()
        {
        }

        public ArabaDBContext(DbContextOptions<ArabaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblmarka> Tblmarkas { get; set; } = null!;
        public virtual DbSet<Tblmodel> Tblmodels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FA4MCJE;Database=ArabaDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tblmarka>(entity =>
            {
                entity.HasKey(e => e.Markaid);

                entity.ToTable("TBLMARKA");

                entity.Property(e => e.Markaid)
                    .ValueGeneratedNever()
                    .HasColumnName("MARKAID");

                entity.Property(e => e.Markaname)
                    .HasMaxLength(100)
                    .HasColumnName("MARKANAME");
            });

            modelBuilder.Entity<Tblmodel>(entity =>
            {
                entity.HasKey(e => e.Modelid);

                entity.ToTable("TBLMODEL");

                entity.Property(e => e.Modelid)
                    .ValueGeneratedNever()
                    .HasColumnName("MODELID");

                entity.Property(e => e.Markaid).HasColumnName("MARKAID");

                entity.Property(e => e.Modelname)
                    .HasMaxLength(100)
                    .HasColumnName("MODELNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
