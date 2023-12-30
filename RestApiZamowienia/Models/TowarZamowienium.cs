using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

public class TowarZamowienium
{
    [Key] public int IdTowaruZamowienia { get; set; }

    public string? NazwaTowaru { get; set; }

    public int? IdZamowienia { get; set; }

    [Column(TypeName = "decimal(18, 0)")] public decimal? Ilosc { get; set; }

    public bool? Aktywny { get; set; }

    [Column(TypeName = "decimal(18, 0)")] public decimal? Cena { get; set; }

    [ForeignKey("IdZamowienia")]
    [InverseProperty("TowarZamowienia")]
    [JsonIgnore]
    public virtual Zamowienie? IdZamowieniaNavigation { get; set; }
}