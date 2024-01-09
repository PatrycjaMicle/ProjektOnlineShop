using System.ComponentModel.DataAnnotations;

namespace SklepInternetowy.WWW.Models.ViewModels;

public class DodajProduktViewModel
{
    [StringLength(20, MinimumLength = 2)]
    public string? Nazwa { get; set; }

    public string? Kod { get; set; }

    public int? IdKategorii { get; set; }

    public double? Cena { get; set; }

    public bool? NaStanie { get; set; }

    public string? ZdjecieUrl { get; set; }

    [StringLength(20, MinimumLength = 10)]
    public string? Opis { get; set; }
}