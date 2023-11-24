using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

public partial class Adre
{
    [Key]
    public int IdAdresu { get; set; }

    [StringLength(50)]
    public string? Kraj { get; set; }

    [StringLength(50)]
    public string? Miejscowosc { get; set; }

    [StringLength(50)]
    public string? Ulica { get; set; }

    [StringLength(50)]
    public string? KodPocztowy { get; set; }

    [StringLength(50)]
    public string? NrBudynku { get; set; }

    [StringLength(50)]
    public string? NrLokalu { get; set; }

    public int? KtoDodal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyDodano { get; set; }

    public int? KtoEdytowal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyEdytowano { get; set; }

    public int? KtoUsunal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUsunieto { get; set; }

    public bool? Aktywny { get; set; }

    [InverseProperty("IdAdresuNavigation")]
    public virtual ICollection<Klient> Klients { get; set; } = new List<Klient>();

    [ForeignKey("KtoDodal")]
    [InverseProperty("AdreKtoDodalNavigations")]
    public virtual Uzytkownik? KtoDodalNavigation { get; set; }

    [ForeignKey("KtoEdytowal")]
    [InverseProperty("AdreKtoEdytowalNavigations")]
    public virtual Uzytkownik? KtoEdytowalNavigation { get; set; }

    [ForeignKey("KtoUsunal")]
    [InverseProperty("AdreKtoUsunalNavigations")]
    public virtual Uzytkownik? KtoUsunalNavigation { get; set; }
}
