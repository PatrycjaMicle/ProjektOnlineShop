using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

[Table("Towar")]
public partial class Towar
{
    [Key]
    public int IdTowaru { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [StringLength(50)]
    public string? Kod { get; set; }

    public int? IdKategorii { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Cena { get; set; }

    public bool? NaStanie { get; set; }

    public string? ZdjecieUrl { get; set; }

    public string? Opis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyDodano { get; set; }

    public int? KtoDodal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyZmodyfikowano { get; set; }

    public int? KtoZmodyfikowal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUsunieto { get; set; }

    public int? KtoUsunal { get; set; }

    public bool? Aktywny { get; set; }

    [InverseProperty("IdTowaruNavigation")]
    public virtual ICollection<ElementKoszyka> ElementKoszykas { get; set; } = new List<ElementKoszyka>();

    [ForeignKey("IdKategorii")]
    [InverseProperty("Towars")]
    public virtual Kategorium? IdKategoriiNavigation { get; set; }

    [ForeignKey("KtoDodal")]
    [InverseProperty("TowarKtoDodalNavigations")]
    public virtual Uzytkownik? KtoDodalNavigation { get; set; }

    [ForeignKey("KtoUsunal")]
    [InverseProperty("TowarKtoUsunalNavigations")]
    public virtual Uzytkownik? KtoUsunalNavigation { get; set; }

    [ForeignKey("KtoZmodyfikowal")]
    [InverseProperty("TowarKtoZmodyfikowalNavigations")]
    public virtual Uzytkownik? KtoZmodyfikowalNavigation { get; set; }

    [InverseProperty("IdTowaruNavigation")]
    public virtual ICollection<TowarZamowienium> TowarZamowienia { get; set; } = new List<TowarZamowienium>();
}
