using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PratoDoDia.Models
{
    public partial class PRATODIAContext : DbContext
    {
        public PRATODIAContext()
        {
        }

        public PRATODIAContext(DbContextOptions<PRATODIAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Prato> Prato { get; set; }
        public virtual DbSet<Venda> Venda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EBH1MFD\\SQLEXPRESS;Database=PRATODIA;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EEA1CDD02C");

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Genero).IsUnicode(false);

                entity.Property(e => e.NomeCliente).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);
            });

            modelBuilder.Entity<Prato>(entity =>
            {
                entity.HasKey(e => e.IdPrato)
                    .HasName("PK__Prato__34650E3813ABF729");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.DiaPrato).IsUnicode(false);

                entity.Property(e => e.NomePrato).IsUnicode(false);

                entity.Property(e => e.Preco).IsUnicode(false);
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PK__Venda__077BEC280249B643");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Venda__idCliente__4D94879B");

                entity.HasOne(d => d.IdPratoNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.IdPrato)
                    .HasConstraintName("FK__Venda__idPrato__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
