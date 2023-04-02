using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IDS328L.Models;

public partial class FinalProjectContext : DbContext
{
    public FinalProjectContext()
    {
    }

    public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaActividad> PersonaActividads { get; set; }

    public virtual DbSet<PersonaActividadView> PersonaActividadViews { get; set; }

    public virtual DbSet<ViewActividad> ViewActividads { get; set; }

    public virtual DbSet<ViewPersona> ViewPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:FinalProject");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaActividad>(entity =>
        {
            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.PersonaActividads).HasConstraintName("FK_Persona_Actividad_Actividad");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.PersonaActividads).HasConstraintName("FK_Persona_Actividad_Persona");
        });

        modelBuilder.Entity<PersonaActividadView>(entity =>
        {
            entity.ToView("Persona_ActividadView");
        });

        modelBuilder.Entity<ViewActividad>(entity =>
        {
            entity.ToView("View_Actividad");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ViewPersona>(entity =>
        {
            entity.ToView("View_Persona");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
