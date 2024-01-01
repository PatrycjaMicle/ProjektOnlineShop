using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<MetodaPlatnosci> MetodaPlatnoscis { get; set; }

    public virtual DbSet<Towar> Towars { get; set; }

    public virtual DbSet<TowarZamowienium> TowarZamowienia { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkowniks { get; set; }
    public virtual DbSet<RolaUzytkownika> RolaUzytkownika { get; set; }

    public virtual DbSet<Zamowienie> Zamowienies { get; set; }
    
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
            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.ElementKoszykas).HasConstraintName("FK_ElementKoszyka_Uzytkownik");

            entity.HasOne(d => d.IdTowaruNavigation).WithMany(p => p.ElementKoszykas).HasConstraintName("FK_ElementKoszyka_Towar");
        });

        modelBuilder.Entity<Kategorium>(entity =>
        {
            entity.HasOne(d => d.KtoDodalNavigation).WithMany(p => p.KategoriumKtoDodalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik");

            entity.HasOne(d => d.KtoEdytowalNavigation).WithMany(p => p.KategoriumKtoEdytowalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik1");

            entity.HasOne(d => d.KtoUsunalNavigation).WithMany(p => p.KategoriumKtoUsunalNavigations).HasConstraintName("FK_Kategoria_Uzytkownik2");
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
            entity.HasOne(d => d.IdZamowieniaNavigation).WithMany(p => p.TowarZamowienia).HasConstraintName("FK_TowarZamowienia_Zamowienie");
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasOne(d => d.RolaUzytkownikaIdNavigation).WithMany(p => p.Uzytkowniks).HasConstraintName("FK_Uzytokwnik_RolaUzytkownika");
        });

        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_Uzytkownik");

            entity.HasOne(d => d.IdMetodyPlatnosciNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_MetodaPlatnosci");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
