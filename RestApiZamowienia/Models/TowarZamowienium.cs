using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiZamowienia.Models;

public partial class TowarZamowienium
{
    [Key]
    public int IdTowaruZamowienia { get; set; }

    public int? IdTowaru { get; set; }

    public int? IdZamowienia { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Ilosc { get; set; }

    public bool? Aktywny { get; set; }

    [ForeignKey("IdTowaru")]
    [InverseProperty("TowarZamowienia")]
    public virtual Towar? IdTowaruNavigation { get; set; }

    [ForeignKey("IdZamowienia")]
    [InverseProperty("TowarZamowienia")]
    public virtual Zamowienie? IdZamowieniaNavigation { get; set; }
}
