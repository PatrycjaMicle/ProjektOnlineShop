using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("SesjaKoszyka")]
public partial class SesjaKoszyka
{
    [Key]
    public int IdSesjiKoszyka { get; set; }

    public int? IdUzytkownika { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Suma { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUtworzenia { get; set; }

    [InverseProperty("IdSesjiKoszykaNavigation")]
    [JsonIgnore]
    public virtual ICollection<ElementKoszyka> ElementKoszykas { get; set; } = new List<ElementKoszyka>();

    [ForeignKey("IdUzytkownika")]
    [InverseProperty("SesjaKoszykas")]
    [JsonIgnore]
    public virtual Uzytkownik? IdUzytkownikaNavigation { get; set; }
}
