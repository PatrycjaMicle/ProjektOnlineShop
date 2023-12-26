using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiZamowienia.Models;

[Table("Zamowienie")]
public partial class Zamowienie
{
    [Key]
    public int IdZamowienia { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataZamowienia { get; set; }

    public int? IdKlienta { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TerminDostawy { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Suma { get; set; }

    public int? IdMetodyPlatnosci { get; set; }

    [ForeignKey("IdKlienta")]
    [InverseProperty("Zamowienies")]
    public virtual Klient? IdKlientaNavigation { get; set; }

    [ForeignKey("IdMetodyPlatnosci")]
    [InverseProperty("Zamowienies")]
    public virtual MetodaPlatnosci? IdMetodyPlatnosciNavigation { get; set; }

    [InverseProperty("IdZamowieniaNavigation")]
    public virtual ICollection<TowarZamowienium> TowarZamowienia { get; set; } = new List<TowarZamowienium>();
}
