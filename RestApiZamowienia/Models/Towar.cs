using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("Towar")]
public class Towar
{
    [Key] public int IdTowaru { get; set; }

    [StringLength(50)] public string? Nazwa { get; set; }

    [StringLength(50)] public string? Kod { get; set; }

    public int? IdKategorii { get; set; }

    [Column(TypeName = "decimal(18, 0)")] public decimal? Cena { get; set; }

    public bool? NaStanie { get; set; }

    public string? ZdjecieUrl { get; set; }

    public string? Opis { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyDodano { get; set; }

    public int? KtoDodal { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyZmodyfikowano { get; set; }

    public int? KtoZmodyfikowal { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyUsunieto { get; set; }

    public int? KtoUsunal { get; set; }

    public bool? Aktywny { get; set; }

    [InverseProperty("IdTowaruNavigation")]
    public virtual ICollection<ElementKoszyka> ElementKoszykas { get; set; } = new List<ElementKoszyka>();

    [ForeignKey("IdKategorii")]
    [InverseProperty("Towars")]
    [JsonIgnore]
    public virtual Kategorium? IdKategoriiNavigation { get; set; }

    [ForeignKey("KtoDodal")]
    [InverseProperty("TowarKtoDodalNavigations")]
    [JsonIgnore]
    public virtual Uzytkownik? KtoDodalNavigation { get; set; }

    [ForeignKey("KtoUsunal")]
    [InverseProperty("TowarKtoUsunalNavigations")]
    [JsonIgnore]
    public virtual Uzytkownik? KtoUsunalNavigation { get; set; }

    [ForeignKey("KtoZmodyfikowal")]
    [InverseProperty("TowarKtoZmodyfikowalNavigations")]
    [JsonIgnore]
    public virtual Uzytkownik? KtoZmodyfikowalNavigation { get; set; }

    [InverseProperty("IdTowaruNavigation")]
    [JsonIgnore]
    public virtual ICollection<TowarZamowienium> TowarZamowienia { get; set; } = new List<TowarZamowienium>();
}