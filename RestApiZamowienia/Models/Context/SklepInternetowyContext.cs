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

    public virtual DbSet<KodPromocji> KodPromocjis { get; set; }

    public virtual DbSet<Promocja> Promocjas { get; set; }

    public virtual DbSet<Kod> Kods { get; set; }

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

        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.HasOne(d => d.IdUzytkownikaNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_Uzytkownik");
            entity.HasOne(d => d.IdMetodyPlatnosciNavigation).WithMany(p => p.Zamowienies).HasConstraintName("FK_Zamowienie_MetodaPlatnosci");
        });

        //RELACJA WIELE DO WIEL DLA TABEL Kod - Promocja , LACZY SIE W TABELI KodPromocji   (JOINTABLE)
        modelBuilder.Entity<KodPromocji>(entity =>
        {
            entity.HasKey(kp => kp.IdKoduPromocji);

            entity.HasOne(kp => kp.Promocja)
                .WithMany(p => p.KodyPromocji)
                .HasForeignKey(kp => kp.IdPromocji)
                .HasConstraintName("FK_KodPromocji_Promocja");

            entity.HasOne(kp => kp.Kod)
                .WithMany(k => k.KodyPromocji)
                .HasForeignKey(kp => kp.IdKodu)
                .HasConstraintName("FK_KodPromocji_Kod");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
