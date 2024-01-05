using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("Zamowienie")]
public class Zamowienie
{
    [Key] public int IdZamowienia { get; set; }

    [Column(TypeName = "datetime")] public DateTime? DataZamowienia { get; set; }

    public int? IdUzytkownika { get; set; }

    [Column(TypeName = "datetime")] public DateTime? TerminDostawy { get; set; }

    [Column(TypeName = "decimal(18, 0)")] public decimal? Suma { get; set; }

    public int? IdMetodyPlatnosci { get; set; }

    public int? IdKoduPromocji { get; set; }

    [ForeignKey("IdUzytkownika")]
    [InverseProperty("Zamowienies")]
    [JsonIgnore]
    public virtual Uzytkownik? IdUzytkownikaNavigation { get; set; }

    [ForeignKey("IdMetodyPlatnosci")]
    [InverseProperty("Zamowienies")]
    [JsonIgnore]
    public virtual MetodaPlatnosci? IdMetodyPlatnosciNavigation { get; set; }

    [ForeignKey("IdKoduPromocji")]
    [InverseProperty("Zamowienies")]
    [JsonIgnore]
    public virtual KodPromocji? IdKoduPromocjiNavigation { get; set; }

    [InverseProperty("IdZamowieniaNavigation")]
    [JsonIgnore]
    public virtual ICollection<TowarZamowienium> TowarZamowienia { get; set; } = new List<TowarZamowienium>();
}