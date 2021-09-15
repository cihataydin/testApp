using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestApi.Data;

#nullable disable

namespace TestApi
{
    public partial class TutorialDBContext : DbContext
    {
        public TutorialDBContext()
        {
        }

        public TutorialDBContext(DbContextOptions<TutorialDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sti> Stis { get; set; }
        public virtual DbSet<Stk> Stks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(ConnectionStringConstant.msSqlConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeesId)
                    .HasName("PK__Employee__7D0907B3B992E88C");

                entity.Property(e => e.EmployeesId).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sti>(entity =>
            {
                entity.HasKey(e => new { e.EvrakNo, e.Tarih, e.IslemTur })
                    .HasName("pkSTI");

                entity.ToTable("STI");

                entity.Property(e => e.EvrakNo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Birim)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Fiyat).HasColumnType("numeric(25, 6)");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MalKodu)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Miktar).HasColumnType("numeric(25, 6)");

                entity.Property(e => e.Tutar).HasColumnType("numeric(25, 6)");
            });

            modelBuilder.Entity<Stk>(entity =>
            {
                entity.HasKey(e => e.MalKodu)
                    .HasName("pkSTK");

                entity.ToTable("STK");

                entity.Property(e => e.MalKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MalAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
