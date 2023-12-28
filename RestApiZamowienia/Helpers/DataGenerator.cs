using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Helpers;

public static class DataGenerator
{
    public static void Seed(this SklepInternetowyContext context)
    {
        var role = new List<RolaUzytkownika>()
        {
            new() { Name = "User" },
            new() { Name = "Admin" }
        };
        
        var metodyPlatnosci = new List<MetodaPlatnosci>()
        {
            new() { Nazwa = "Card" },
            new() { Nazwa = "Bank transfer" },
            new() { Nazwa = "Cash" },
            new() { Nazwa = "Blik" },
        };

        var uzytkownicy = new List<Uzytkownik>()
        {
            new()
            {
                Imie = "Wojtek",
                Nazwisko = "Massalski",
                Email = "wojtek@wojtek.pl",
                DataDodania = DateTime.Now,
                ZahaszowaneHaslo =
                    "AQAAAAEAACcQAAAAEL833z8TI6NrIjfH68OCKyxLMDb5IG2p3kBA0gJrnulyACHC740KXEr5BTRCnVGEVQ==",
                RolaUzytkownikaId = 1
            },
            new()
            {
                Imie = "Pati",
                Nazwisko = "Micle",
                Email = "pati@pati.pl",
                DataDodania = DateTime.Now,
                ZahaszowaneHaslo =
                    "AQAAAAEAACcQAAAAEIBz1KfvJO05/LhspV400sgGn648H/9qHw28ZZarmDCr6PV+zgIBYhilhzr0MXDaCg==",
                RolaUzytkownikaId = 2
            },
            new()
            {
                Imie = "Slawek",
                Nazwisko = "Nazwisko",
                Email = "slawek@slawek.pl",
                DataDodania = DateTime.Now,
                ZahaszowaneHaslo =
                    "AQAAAAEAACcQAAAAEEO140a0yRK1jnFLD92dOAHeMa3uYRS6IyndorUkiWdduy/p4gXGQadjuGqwcwHJmg==",
                RolaUzytkownikaId = 1
            },
        };

        var adresy = new List<Adre>()
        {
            new()
            {
                Kraj = "Polska",
                Miejscowosc = "Krakow",
                Ulica = "Prosta",
                KodPocztowy = "33-300",
                NrBudynku = "10",
                NrLokalu = "5",
                KtoDodal = 1
            },
            new()
            {
                Kraj = "Polska",
                Miejscowosc = "Wroclaw",
                Ulica = "Krzywa",
                KodPocztowy = "53-300",
                NrBudynku = "30",
                NrLokalu = "5",
                KtoDodal = 2
            },
        };
        
        var zamowienia = new List<Zamowienie>()
        {
            new()
            {
                DataZamowienia = DateTime.Now,
                TerminDostawy = DateTime.Now.Add(TimeSpan.FromDays(7)),
                IdMetodyPlatnosci = 1,
            },
            new()
            {
                DataZamowienia = DateTime.Now,
                TerminDostawy = DateTime.Now.Add(TimeSpan.FromDays(7)),
                IdMetodyPlatnosci = 2,
            }
        };

        var kategorie = new List<Kategorium>()
        {
            new()
            {
                Nazwa = "Kartony",
                KtoDodal = 2,
                KiedyDodano = DateTime.Now,
            },
            new()
            {
                Nazwa = "Czesci",
                KtoDodal = 2,
                KiedyDodano = DateTime.Now,
            }
        };

       

        var towary = new List<Towar>()
        {
            // TODO Pati dodaj towary i kategorie prosze
             new()
             {
                 Nazwa = "Opna",
                 Kod = "111",
                 Cena = 111,
                 // ZdjecieUrl = ,
                 Opis = "opis",
                 KiedyDodano = DateTime.Now,
                 NaStanie = true,
             },
             new()
             {
                 Nazwa = "Kierownica",
                 Kod = "111",
                 Cena = 111,
                 // ZdjecieUrl = ,
                 Opis = "opis",
                 KiedyDodano = DateTime.Now,
                 NaStanie = true,
             }
        };

        var towaryZamowienia = new List<TowarZamowienium>()
        {
            new()
            {
                IdTowaru = 1,
                IdZamowienia = 1,
                Ilosc = 2
            },
            new()
            {
                IdTowaru = 2,
                IdZamowienia = 2,
                Ilosc = 3
            },
        };
        
        context.AddRange(towary);
        context.SaveChanges();
        context.AddRange(role);
        context.SaveChanges();
        context.AddRange(metodyPlatnosci);
        context.SaveChanges();
        context.AddRange(uzytkownicy);
        context.SaveChanges();
        context.SaveChanges();
        context.AddRange(adresy);
        context.SaveChanges();
        context.AddRange(zamowienia);
        context.SaveChanges();
        context.AddRange(kategorie);
        context.SaveChanges();
        context.AddRange(towaryZamowienia);
        context.SaveChanges();
        context.SaveChanges();
    }
}