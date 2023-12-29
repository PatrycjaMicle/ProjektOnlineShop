using SklepInternetowy.Models;
using SklepInternetowy.Services.DataStore;
using SklepInternetowyServiceReference;
using System;

public class ElementKoszykaMapper
{
    private readonly TowaryDataStore towaryDataStore;

    public ElementKoszykaMapper(TowaryDataStore towaryDataStore)
    {
        this.towaryDataStore = towaryDataStore ?? throw new ArgumentNullException(nameof(towaryDataStore));
    }

    public ElementKoszykaForView MapToElementKoszykaForView(ElementKoszyka elementKoszyka)
    {
        if (elementKoszyka == null)
        {
            return null;
        }

        return new ElementKoszykaForView
        {
            IdElementuKoszyka = elementKoszyka.IdElementuKoszyka,
            IdUzytkownika = elementKoszyka.IdUzytkownika,
            IdTowaru = elementKoszyka.IdTowaru,
            TowarNazwa = GetTowarNazwa(elementKoszyka.IdTowaru),
            TowarCena = GetTowarCena(elementKoszyka.IdTowaru),
            Ilosc = elementKoszyka.Ilosc,
        };
    }

    private string GetTowarNazwa(int? idTowaru)
    {
        return towaryDataStore.Find(idTowaru.Value)?.Nazwa ?? string.Empty;
    }

    private double? GetTowarCena(int? idTowaru)
    {
        return towaryDataStore.Find(idTowaru.Value)?.Cena;
    }
}
