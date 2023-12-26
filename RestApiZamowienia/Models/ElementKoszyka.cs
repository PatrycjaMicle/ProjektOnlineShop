using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("ElementKoszyka")]
public partial class ElementKoszyka
{
    [Key]
    public int IdElementuKoszyka { get; set; }

    public int? IdSesjiKoszyka { get; set; }

    public int? IdTowaru { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ilosc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUtworzenia { get; set; }

    [ForeignKey("IdSesjiKoszyka")]
    [InverseProperty("ElementKoszykas")]
    [JsonIgnore]
    public virtual SesjaKoszyka? IdSesjiKoszykaNavigation { get; set; }

    [ForeignKey("IdTowaru")]
    [InverseProperty("ElementKoszykas")]
    [JsonIgnore]
    public virtual Towar? IdTowaruNavigation { get; set; }
}
