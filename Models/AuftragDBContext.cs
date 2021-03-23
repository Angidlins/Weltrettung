using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WeltrettungAuftrag.Models
{
    public partial class AuftragDBContext : DbContext
    {
        public AuftragDBContext()
        {
        }

        public AuftragDBContext(DbContextOptions<AuftragDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aggressor> Aggressors { get; set; }
        public virtual DbSet<Held> Helds { get; set; }
        public virtual DbSet<Kampf> Kampfs { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AuftragDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aggressor>(entity =>
            {
                entity.ToTable("Aggressor");

                entity.Property(e => e.AggressorId).HasColumnName("aggressor_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Spezialitaet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("spezialitaet");

                entity.Property(e => e.Spitzname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("spitzname");
            });

            modelBuilder.Entity<Held>(entity =>
            {
                entity.ToTable("Held");

                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Faehigkeit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("faehigkeit");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nachname");

                entity.Property(e => e.Volljaehrig).HasColumnName("volljaehrig");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vorname");
            });

            modelBuilder.Entity<Kampf>(entity =>
            {
                entity.ToTable("Kampf");

                entity.Property(e => e.KampfId).HasColumnName("kampf_id");

                entity.Property(e => e.AggressorId).HasColumnName("aggressor_id");

                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.Property(e => e.Kampfbezeichnung)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kampfbezeichnung");

                entity.HasOne(d => d.Aggressor)
                    .WithMany(p => p.Kampfs)
                    .HasForeignKey(d => d.AggressorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_aggressor_id");

                entity.HasOne(d => d.Held)
                    .WithMany(p => p.Kampfs)
                    .HasForeignKey(d => d.HeldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_held_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
