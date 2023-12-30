using RestApiZamowienia.Models;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Helpers;

public static class DataGenerator
{
    public static void Seed(this SklepInternetowyContext context)
    {
        var role = new List<RolaUzytkownika>
        {
            new() { Name = "User" },
            new() { Name = "Admin" }
        };

        var metodyPlatnosci = new List<MetodaPlatnosci>
        {
            new() { Nazwa = "Card" },
            new() { Nazwa = "Bank transfer" },
            new() { Nazwa = "Cash" },
            new() { Nazwa = "Blik" }
        };

        var uzytkownicy = new List<Uzytkownik>
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
            }
        };

        var adresy = new List<Adre>
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
            }
        };

        var zamowienia = new List<Zamowienie>
        {
        };

        var kategorie = new List<Kategorium>
        {
            new()
            {
                Nazwa = "Hamulce",
                KtoDodal = 2,
                KiedyDodano = DateTime.Now
            },
            new()
            {
                Nazwa = "Opony",
                KtoDodal = 2,
                KiedyDodano = DateTime.Now
            }
        };


        var towary = new List<Towar>
        {
            new()
            {
                Nazwa = "Opona radialna",
                Kod = "O67",
                Cena = 385,
                ZdjecieUrl =
                    "https://lewmik.pl/zdjecia/2016/01/27/901/17/Opona_Radialna_Kleber_380_85_24_14.9_R24_Radial.jpg",
                Opis =
                    "Jest to ogumienie, które ma kordy osnowy ułożone promieniowo, czyli równolegle, jedna na drugiej. Nie tworzą sieci, a zwartą warstwę. Zwykle jako kord stosuje się stalowe druciki. Budowa radialna pozwala na zróżnicowanie cech poszczególnych części opony. ",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Hydrauliczny hamulec",
                Kod = "H78",
                Cena = 990,
                ZdjecieUrl = "https://www.knott.pl/wp-content/uploads/200x30-Hydraulik-Simplex-1024x983.jpg",
                Opis =
                    "Zaletą tych hamulców, w przeciwieństwie do hamulców o pływających, czy ruchomych połączeniach tarcz, jest brak ruchomych elementów, co sprawia, iż sprawdzają się one w układach pojazdów poruszających po drogach nieutwardzonych, w terenie lub w otoczeniu o silnym zanieczyszczeniu.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Sprzeglo rozrusznika",
                Kod = "H78",
                Cena = 870,
                ZdjecieUrl =
                    "https://quadowanie.pl/shop/29266-thickbox_default/sprzeglo-rozrusznika-bendiks-cf-moto-450-500-520-550-625-800.jpg",
                Opis =
                    "Wysokiej jakości zamiennik. Producent: Power Force. Wymiary: średnica frezu: 16 mm. W skład zestawu wchodzi: zębatka; łożysko igłowe wewnętrzne ; łożysko jednokierunkowe.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Lusterko zewnetrzne",
                Kod = "L78",
                Cena = 420,
                ZdjecieUrl =
                    "https://image.ceneostatic.pl/data/products/137152654/i-dlaauta-trafic-vivaro-primastar-wklad-szklo-lusterka-lewy.jpg",
                Opis =
                    "Lusterko montowane zwykle po stronie kierowcy, które dzięki dwuczęściowej powierzchni (tzn. zewnętrzny jego kraniec został nieco zakrzywiony na zewnątrz) eliminuje niebezpieczne martwe pole i zdecydowanie zwiększa bezpieczeństwo, np. przy zmianie pasa ruchu, przy wyprzedzaniu. W asferyczne lusterka zewnętrzne po stronie kierowcy wyposażone są niemal wszystkie obecnie sprzedawane samochody osobowe.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Opona klasyczna",
                Kod = "O67",
                Cena = 385,
                ZdjecieUrl =
                    "https://lewmik.pl/zdjecia/2016/01/27/901/17/Opona_Radialna_Kleber_380_85_24_14.9_R24_Radial.jpg",
                Opis =
                    "Jest to ogumienie, które ma kordy osnowy ułożone promieniowo, czyli równolegle, jedna na drugiej. Nie tworzą sieci, a zwartą warstwę. Zwykle jako kord stosuje się stalowe druciki. Budowa radialna pozwala na zróżnicowanie cech poszczególnych części opony. ",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Hamulec tytan",
                Kod = "H78",
                Cena = 1100,
                ZdjecieUrl = "https://www.knott.pl/wp-content/uploads/200x30-Hydraulik-Simplex-1024x983.jpg",
                Opis =
                    "Zaletą tych hamulców, w przeciwieństwie do hamulców o pływających, czy ruchomych połączeniach tarcz, jest brak ruchomych elementów, co sprawia, iż sprawdzają się one w układach pojazdów poruszających po drogach nieutwardzonych, w terenie lub w otoczeniu o silnym zanieczyszczeniu.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Sprzeglo stalowe",
                Kod = "H78",
                Cena = 1300,
                ZdjecieUrl =
                    "https://quadowanie.pl/shop/29266-thickbox_default/sprzeglo-rozrusznika-bendiks-cf-moto-450-500-520-550-625-800.jpg",
                Opis =
                    "Wysokiej jakości zamiennik. Producent: Power Force. Wymiary: średnica frezu: 16 mm. W skład zestawu wchodzi: zębatka; łożysko igłowe wewnętrzne ; łożysko jednokierunkowe.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            },
            new()
            {
                Nazwa = "Lusterka automatyczne zestaw",
                Kod = "L78",
                Cena = 545,
                ZdjecieUrl =
                    "https://image.ceneostatic.pl/data/products/137152654/i-dlaauta-trafic-vivaro-primastar-wklad-szklo-lusterka-lewy.jpg",
                Opis =
                    "Lusterko montowane zwykle po stronie kierowcy, które dzięki dwuczęściowej powierzchni (tzn. zewnętrzny jego kraniec został nieco zakrzywiony na zewnątrz) eliminuje niebezpieczne martwe pole i zdecydowanie zwiększa bezpieczeństwo, np. przy zmianie pasa ruchu, przy wyprzedzaniu. W asferyczne lusterka zewnętrzne po stronie kierowcy wyposażone są niemal wszystkie obecnie sprzedawane samochody osobowe.",
                KiedyDodano = DateTime.Now,
                NaStanie = true
            }
        };

        var towaryZamowienia = new List<TowarZamowienium>
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
            }
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