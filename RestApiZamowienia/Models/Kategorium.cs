using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiZamowienia.Models;

public class Kategorium
{
    [Key] public int IdKategorii { get; set; }

    [StringLength(50)] public string? Nazwa { get; set; }

    public int? KtoDodal { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyDodano { get; set; }

    public int? KtoEdytowal { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyEdytowano { get; set; }

    public int? KtoUsunal { get; set; }

    [Column(TypeName = "datetime")] public DateTime? KiedyUsunieto { get; set; }

    public bool? Aktywny { get; set; }

    [ForeignKey("KtoDodal")]
    [InverseProperty("KategoriumKtoDodalNavigations")]
    public virtual Uzytkownik? KtoDodalNavigation { get; set; }

    [ForeignKey("KtoEdytowal")]
    [InverseProperty("KategoriumKtoEdytowalNavigations")]
    public virtual Uzytkownik? KtoEdytowalNavigation { get; set; }

    [ForeignKey("KtoUsunal")]
    [InverseProperty("KategoriumKtoUsunalNavigations")]
    public virtual Uzytkownik? KtoUsunalNavigation { get; set; }

    [InverseProperty("IdKategoriiNavigation")]
    public virtual ICollection<Towar> Towars { get; set; } = new List<Towar>();
}