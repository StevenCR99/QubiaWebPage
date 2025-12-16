using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QubiaWebPage.Models;

public partial class QubiaDbContext : DbContext
{
    public QubiaDbContext()
    {
    }

    public QubiaDbContext(DbContextOptions<QubiaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpresaInfo> EmpresaInfo { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        => optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=QubiaDB;Trusted_Connection=True;TrustServerCertificate=True;"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpresaInfo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Seccion).HasMaxLength(50);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.ConocioEmpresa).HasMaxLength(100);
            entity.Property(e => e.CVRuta)
                .HasMaxLength(255)
                .HasColumnName("CVRuta");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.ExpectativaSalarial).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
