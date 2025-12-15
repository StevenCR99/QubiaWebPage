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

    public virtual DbSet<EmpresaInfo> EmpresaInfos { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WINLAB-13\\SQLEXPRESS; Database=QubiaDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpresaInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmpresaI__3214EC07CD9AAD25");

            entity.ToTable("EmpresaInfo");

            entity.Property(e => e.Seccion).HasMaxLength(50);
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC0791F0BF29");

            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC07E1AA9A14");

            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.ConocioEmpresa).HasMaxLength(100);
            entity.Property(e => e.Cvruta)
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
