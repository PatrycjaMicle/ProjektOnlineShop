using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestApiZamowienia.Models;

namespace RestApiZamowienia.Models.Context;

public partial class SklepInternetowyContext : DbContext
{
    public SklepInternetowyContext()
    {
    }

    public SklepInternetowyContext(DbContextOptions<SklepInternetowyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adre> Adres { get; set; }

    public virtual DbSet<ElementKoszyka> ElementKoszykas { get; set; }

    public virtual DbSet<Kategorium> Kategoria { get; set; }

    public virtual DbSet<Klient> Klients { get; set; }

    public virtual DbSet<MetodaPlatnosci> MetodaPlatnoscis { get; set; }

    public virtual DbSet<SesjaKoszyka> SesjaKoszykas { get; set; }

    public virtual DbSet<Towar> Towars { get; set; }

    public virtual DbSet<TowarZamowienium> TowarZamowienia { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkowniks { get; set; }
    public virtual DbSet<RolaUzytkownika> RolaUzytkownika { get; set; }

    public virtual DbSet<Zamowienie> Zamowienies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-78T85JN\\SQLEXPRESS;TrustServerCertificate=True;Integrated Security=True;Database=ProjektAplikacjeMobilneSklep");
                                                            //DESKTOP-78T85JN\SQLEXPRESS nie usuwac haha!

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adre>(entity =>
        {
            entity.HasOne(d => d.KtoDodalNavigation).WithMany(p => p.AdreKtoDodalNavigations).HasConstraintName("FK_Adres_Uzytkownik");

            entity.HasOne(d => d.KtoEdytowalNavigation).WithMany(p => p.AdreKtoEdytowalNavigations).HasConstraintName("FK_Adres_Uzytkownik1");

            entity.HasOne(d => d.KtoUsunalNavigation).WithMany(p => p.AdreKtoUsunalNavigations).HasConstraintName("FK_Adres_Uzytkownik2");
        });

        modelBuilder.Entity<ElementKoszyka>(entity =>
        {
            entity.HasOne(d => d.IdSesjiKoszykaNavigation).WithMany(p => p.ElementKoszykas).HasConstraintName("FK_ElementKoszyka_SesjaKoszyka");

            entity.HasOne(d => d.IdTowaruNavigation).WithMany(p => p.ElementKoszykas).HasConstraintName("FK_ElementKoszyka_Towar");
        });

        modelBuilder.Entity<Kategorium>(entity =>
        {
            entity.HasOne(d => d.KtoDodalNavigation).WithMany(p => p.KategoriumKtoDodalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik");

            entity.HasOne(d => d.KtoEdytowalNavigation).WithMany(p => p.KategoriumKtoEdytowalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik1");

            entity.HasOne(d => d.KtoUsunalNavigation).WithMany(p => p.KategoriumKtoUsunalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik2");
        });

        modelBuilder.Entity<Klient>(entity =>
        {
            entity.HasOne(d => d.IdAdresuNavigation).WithMany(p => p.Klients).HasConstraintName("FK_Klient_Adres");

            entity.HasOne(d => d.KtoDodalNavigation).WithMany(p => p.KlientKtoDodalNavigations).HasConstraintName("FK_Klient_Uzytkownik");

            entity.HasOne(d => d.KtoUsunalNavigation).WithMany(p => p.KlientKtoUsunalNavigations).HasConstraintName("FK_Klient_Uzytkownik2");

            entity.HasOne(d => d.KtoZmodyfikowalNavigation).WithMany(p => p.KlientKtoZmodyfikowalNavigations).HasConstraintName("FK_Klient_Uzytkownik1");
        });

        modelBuilder.Entity<SesjaKoszyka>(entity =>
        {
            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.SesjaKoszykas).HasConstraintName("FK_SesjaKoszyka_Klient");
        });

        modelBuilder.Entity<Towar>(entity =>
        {
            entity.HasOne(d => d.IdKategoriiNavigation).WithMany(p => p.Towars).HasConstraintName("FK_Towar_Kategoria");

            entity.HasOne(d => d.KtoDodalNavigation).WithMany(p => p.TowarKtoDodalNavigations).HasConstraintName("FK_Towar_Uzytkownik");

            entity.HasOne(d => d.KtoUsunalNavigation).WithMany(p => p.TowarKtoUsunalNavigations).HasConstraintName("FK_Towar_Uzytkownik1");

            entity.HasOne(d => d.KtoZmodyfikowalNavigation).WithMany(p => p.TowarKtoZmodyfikowalNavigations).HasConstraintName("FK_Towar_Uzytkownik2");
        });

        modelBuilder.Entity<TowarZamowienium>(entity =>
        {
            entity.HasOne(d => d.IdTowaruNavigation).WithMany(p => p.TowarZamowienia).HasConstraintName("FK_TowarZamowienia_Towar");

            entity.HasOne(d => d.IdZamowieniaNavigation).WithMany(p => p.TowarZamowienia).HasConstraintName("FK_TowarZamowienia_Zamowienie");
        });

        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_Klient");

            entity.HasOne(d => d.IdMetodyPlatnosciNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_MetodaPlatnosci");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
