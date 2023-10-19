using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Scaffolding.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GbpAlmCatLibro> GbpAlmCatLibros { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=gestorBibliotecaPersonal;User Id=postgres;Password=mariomanu7.;SearchPath=gbp_almacen");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GbpAlmCatLibro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("gbp_alm_cat_libros_pkey");

            entity.ToTable("gbp_alm_cat_libros", "gbp_almacen");

            entity.Property(e => e.IdLibro)
                .HasDefaultValueSql("nextval('gbp_alm_cat_libros_id_libro_seq'::regclass)")
                .HasColumnName("id_libro");
            entity.Property(e => e.Autor)
                .HasColumnType("character varying")
                .HasColumnName("autor");
            entity.Property(e => e.Edicion).HasColumnName("edicion");
            entity.Property(e => e.Isbn)
                .HasColumnType("character varying")
                .HasColumnName("isbn");
            entity.Property(e => e.Titulo)
                .HasColumnType("character varying")
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("Libros", "gbp_almacen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
