using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tareas.Api.Models;

public partial class TareasContext : DbContext
{
    
    public TareasContext(DbContextOptions<TareasContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Tarea> Tareas { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.ToTable("Tarea");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
