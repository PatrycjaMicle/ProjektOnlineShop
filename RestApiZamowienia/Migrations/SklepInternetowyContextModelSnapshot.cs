﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiZamowienia.Models.Context;

#nullable disable

namespace RestApiZamowienia.Migrations
{
    [DbContext(typeof(SklepInternetowyContext))]
    partial class SklepInternetowyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestApiZamowienia.Models.Adre", b =>
                {
                    b.Property<int>("IdAdresu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdresu"));

                    b.Property<bool?>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("KiedyDodano")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyEdytowano")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyUsunieto")
                        .HasColumnType("datetime");

                    b.Property<string>("KodPocztowy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Kraj")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("KtoDodal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoEdytowal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoUsunal")
                        .HasColumnType("int");

                    b.Property<string>("Miejscowosc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NrBudynku")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NrLokalu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ulica")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAdresu");

                    b.HasIndex("KtoDodal");

                    b.HasIndex("KtoEdytowal");

                    b.HasIndex("KtoUsunal");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.ElementKoszyka", b =>
                {
                    b.Property<int>("IdElementuKoszyka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdElementuKoszyka"));

                    b.Property<DateTime?>("DataUtworzenia")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdTowaru")
                        .HasColumnType("int");

                    b.Property<int?>("IdUzytkownika")
                        .HasColumnType("int");

                    b.Property<decimal?>("Ilosc")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdElementuKoszyka");

                    b.HasIndex("IdTowaru");

                    b.HasIndex("IdUzytkownika");

                    b.ToTable("ElementKoszyka");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Kategorium", b =>
                {
                    b.Property<int>("IdKategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKategorii"));

                    b.Property<bool?>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("KiedyDodano")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyEdytowano")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyUsunieto")
                        .HasColumnType("datetime");

                    b.Property<int?>("KtoDodal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoEdytowal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoUsunal")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdKategorii");

                    b.HasIndex("KtoDodal");

                    b.HasIndex("KtoEdytowal");

                    b.HasIndex("KtoUsunal");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.MetodaPlatnosci", b =>
                {
                    b.Property<int>("IdMetodyPlatnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMetodyPlatnosci"));

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMetodyPlatnosci");

                    b.ToTable("MetodaPlatnosci");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.RolaUzytkownika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RolaUzytkownika");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Towar", b =>
                {
                    b.Property<int>("IdTowaru")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTowaru"));

                    b.Property<bool?>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Cena")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("IdKategorii")
                        .HasColumnType("int");

                    b.Property<DateTime?>("KiedyDodano")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyUsunieto")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KiedyZmodyfikowano")
                        .HasColumnType("datetime");

                    b.Property<string>("Kod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("KtoDodal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoUsunal")
                        .HasColumnType("int");

                    b.Property<int?>("KtoZmodyfikowal")
                        .HasColumnType("int");

                    b.Property<bool?>("NaStanie")
                        .HasColumnType("bit");

                    b.Property<string>("Nazwa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZdjecieUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTowaru");

                    b.HasIndex("IdKategorii");

                    b.HasIndex("KtoDodal");

                    b.HasIndex("KtoUsunal");

                    b.HasIndex("KtoZmodyfikowal");

                    b.ToTable("Towar");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.TowarZamowienium", b =>
                {
                    b.Property<int>("IdTowaruZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTowaruZamowienia"));

                    b.Property<bool?>("Aktywny")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Cena")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("IdZamowienia")
                        .HasColumnType("int");

                    b.Property<decimal?>("Ilosc")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("NazwaTowaru")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTowaruZamowienia");

                    b.HasIndex("IdZamowienia");

                    b.ToTable("TowarZamowienia");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Uzytkownik", b =>
                {
                    b.Property<int>("IdUzytkownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUzytkownika"));

                    b.Property<DateTime?>("DataDodania")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imie")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nazwisko")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RolaUzytkownikaId")
                        .HasColumnType("int");

                    b.Property<string>("ZahaszowaneHaslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUzytkownika");

                    b.HasIndex("RolaUzytkownikaId");

                    b.ToTable("Uzytkownik");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Zamowienie", b =>
                {
                    b.Property<int>("IdZamowienia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZamowienia"));

                    b.Property<DateTime?>("DataZamowienia")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdMetodyPlatnosci")
                        .HasColumnType("int");

                    b.Property<int?>("IdUzytkownika")
                        .HasColumnType("int");

                    b.Property<decimal?>("Suma")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("TerminDostawy")
                        .HasColumnType("datetime");

                    b.HasKey("IdZamowienia");

                    b.HasIndex("IdMetodyPlatnosci");

                    b.HasIndex("IdUzytkownika");

                    b.ToTable("Zamowienie");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Adre", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoDodalNavigation")
                        .WithMany("AdreKtoDodalNavigations")
                        .HasForeignKey("KtoDodal")
                        .HasConstraintName("FK_Adres_Uzytkownik");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoEdytowalNavigation")
                        .WithMany("AdreKtoEdytowalNavigations")
                        .HasForeignKey("KtoEdytowal")
                        .HasConstraintName("FK_Adres_Uzytkownik1");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoUsunalNavigation")
                        .WithMany("AdreKtoUsunalNavigations")
                        .HasForeignKey("KtoUsunal")
                        .HasConstraintName("FK_Adres_Uzytkownik2");

                    b.Navigation("KtoDodalNavigation");

                    b.Navigation("KtoEdytowalNavigation");

                    b.Navigation("KtoUsunalNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.ElementKoszyka", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.Towar", "IdTowaruNavigation")
                        .WithMany("ElementKoszykas")
                        .HasForeignKey("IdTowaru")
                        .HasConstraintName("FK_ElementKoszyka_Towar");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "IdUzytkownikaNavigation")
                        .WithMany("ElementKoszykas")
                        .HasForeignKey("IdUzytkownika")
                        .HasConstraintName("FK_ElementKoszyka_Uzytkownik");

                    b.Navigation("IdTowaruNavigation");

                    b.Navigation("IdUzytkownikaNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Kategorium", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoDodalNavigation")
                        .WithMany("KategoriumKtoDodalNavigations")
                        .HasForeignKey("KtoDodal")
                        .HasConstraintName("FK_Kategoria_Uzytkownik");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoEdytowalNavigation")
                        .WithMany("KategoriumKtoEdytowalNavigations")
                        .HasForeignKey("KtoEdytowal")
                        .HasConstraintName("FK_Kategoria_Uzytkownik1");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoUsunalNavigation")
                        .WithMany("KategoriumKtoUsunalNavigations")
                        .HasForeignKey("KtoUsunal")
                        .HasConstraintName("FK_Kategoria_Uzytkownik2");

                    b.Navigation("KtoDodalNavigation");

                    b.Navigation("KtoEdytowalNavigation");

                    b.Navigation("KtoUsunalNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Towar", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.Kategorium", "IdKategoriiNavigation")
                        .WithMany("Towars")
                        .HasForeignKey("IdKategorii")
                        .HasConstraintName("FK_Towar_Kategoria");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoDodalNavigation")
                        .WithMany("TowarKtoDodalNavigations")
                        .HasForeignKey("KtoDodal")
                        .HasConstraintName("FK_Towar_Uzytkownik");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoUsunalNavigation")
                        .WithMany("TowarKtoUsunalNavigations")
                        .HasForeignKey("KtoUsunal")
                        .HasConstraintName("FK_Towar_Uzytkownik1");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "KtoZmodyfikowalNavigation")
                        .WithMany("TowarKtoZmodyfikowalNavigations")
                        .HasForeignKey("KtoZmodyfikowal")
                        .HasConstraintName("FK_Towar_Uzytkownik2");

                    b.Navigation("IdKategoriiNavigation");

                    b.Navigation("KtoDodalNavigation");

                    b.Navigation("KtoUsunalNavigation");

                    b.Navigation("KtoZmodyfikowalNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.TowarZamowienium", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.Zamowienie", "IdZamowieniaNavigation")
                        .WithMany("TowarZamowienia")
                        .HasForeignKey("IdZamowienia")
                        .HasConstraintName("FK_TowarZamowienia_Zamowienie");

                    b.Navigation("IdZamowieniaNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Uzytkownik", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.RolaUzytkownika", "RolaUzytkownikaIdNavigation")
                        .WithMany("Uzytkowniks")
                        .HasForeignKey("RolaUzytkownikaId")
                        .HasConstraintName("FK_Uzytokwnik_RolaUzytkownika");

                    b.Navigation("RolaUzytkownikaIdNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Zamowienie", b =>
                {
                    b.HasOne("RestApiZamowienia.Models.MetodaPlatnosci", "IdMetodyPlatnosciNavigation")
                        .WithMany("Zamowienies")
                        .HasForeignKey("IdMetodyPlatnosci")
                        .HasConstraintName("FK_Zamowienie_MetodaPlatnosci");

                    b.HasOne("RestApiZamowienia.Models.Uzytkownik", "IdUzytkownikaNavigation")
                        .WithMany("Zamowienies")
                        .HasForeignKey("IdUzytkownika")
                        .HasConstraintName("FK_Zamowienie_Uzytkownik");

                    b.Navigation("IdMetodyPlatnosciNavigation");

                    b.Navigation("IdUzytkownikaNavigation");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Kategorium", b =>
                {
                    b.Navigation("Towars");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.MetodaPlatnosci", b =>
                {
                    b.Navigation("Zamowienies");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.RolaUzytkownika", b =>
                {
                    b.Navigation("Uzytkowniks");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Towar", b =>
                {
                    b.Navigation("ElementKoszykas");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Uzytkownik", b =>
                {
                    b.Navigation("AdreKtoDodalNavigations");

                    b.Navigation("AdreKtoEdytowalNavigations");

                    b.Navigation("AdreKtoUsunalNavigations");

                    b.Navigation("ElementKoszykas");

                    b.Navigation("KategoriumKtoDodalNavigations");

                    b.Navigation("KategoriumKtoEdytowalNavigations");

                    b.Navigation("KategoriumKtoUsunalNavigations");

                    b.Navigation("TowarKtoDodalNavigations");

                    b.Navigation("TowarKtoUsunalNavigations");

                    b.Navigation("TowarKtoZmodyfikowalNavigations");

                    b.Navigation("Zamowienies");
                });

            modelBuilder.Entity("RestApiZamowienia.Models.Zamowienie", b =>
                {
                    b.Navigation("TowarZamowienia");
                });
#pragma warning restore 612, 618
        }
    }
}
