using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RestApiZamowienia.Models;

[Table("Uzytkownik")]
public class Uzytkownik
{
    [Key] public int IdUzytkownika { get; set; }

    [StringLength(50)] public string? Imie { get; set; }

    [StringLength(50)] public string? Nazwisko { get; set; }

    [Column(TypeName = "datetime")] public DateTime? DataDodania { get; set; }

    [StringLength(50)] public string? Email { get; set; }

    public string ZahaszowaneHaslo { get; set; }

    public RolaUzytkownika RolaUzytkownika { get; set; }
    public int RolaUzytkownikaId { get; set; }

    [JsonIgnore]
    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Adre> AdreKtoDodalNavigations { get; set; } = new List<Adre>();

    [JsonIgnore]
    [InverseProperty("KtoEdytowalNavigation")]
    public virtual ICollection<Adre> AdreKtoEdytowalNavigations { get; set; } = new List<Adre>();

    [JsonIgnore]
    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Adre> AdreKtoUsunalNavigations { get; set; } = new List<Adre>();

    [JsonIgnore]
    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoDodalNavigations { get; set; } = new List<Kategorium>();

    [JsonIgnore]
    [InverseProperty("KtoEdytowalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoEdytowalNavigations { get; set; } = new List<Kategorium>();

    [JsonIgnore]
    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoUsunalNavigations { get; set; } = new List<Kategorium>();

    [JsonIgnore]
    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Klient> KlientKtoDodalNavigations { get; set; } = new List<Klient>();

    [JsonIgnore]
    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Klient> KlientKtoUsunalNavigations { get; set; } = new List<Klient>();

    [JsonIgnore]
    [InverseProperty("KtoZmodyfikowalNavigation")]
    public virtual ICollection<Klient> KlientKtoZmodyfikowalNavigations { get; set; } = new List<Klient>();

    [JsonIgnore]
    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Towar> TowarKtoDodalNavigations { get; set; } = new List<Towar>();

    [JsonIgnore]
    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Towar> TowarKtoUsunalNavigations { get; set; } = new List<Towar>();

    [JsonIgnore]
    [InverseProperty("KtoZmodyfikowalNavigation")]
    public virtual ICollection<Towar> TowarKtoZmodyfikowalNavigations { get; set; } = new List<Towar>();

    [JsonIgnore]
    [InverseProperty("IdUzytkownikaNavigation")]
    public ICollection<ElementKoszyka> ElementKoszykas { get; set; } = new List<ElementKoszyka>();
}