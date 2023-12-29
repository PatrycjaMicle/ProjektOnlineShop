using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiZamowienia.Models;

[Table("MetodaPlatnosci")]
public class MetodaPlatnosci
{
    [Key] public int IdMetodyPlatnosci { get; set; }

    [StringLength(50)] public string? Nazwa { get; set; }

    [InverseProperty("IdMetodyPlatnosciNavigation")]
    public virtual ICollection<Zamowienie> Zamowienies { get; set; } = new List<Zamowienie>();
}