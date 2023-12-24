using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

[Table("Klient")]
public partial class Klient
{
    [Key]
    public int IdKlienta { get; set; }

    [StringLength(50)]
    public string? Imie { get; set; }

    [StringLength(50)]
    public string? Nazwisko { get; set; }

    public int? IdAdresu { get; set; }

    public int? KtoDodal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyDodano { get; set; }

    public int? KtoZmodyfikowal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyZmodyfikowano { get; set; }

    public int? KtoUsunal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUsunieto { get; set; }

    public bool? Aktywny { get; set; }

    [ForeignKey("IdAdresu")]
    [InverseProperty("Klients")]
    public virtual Adre? IdAdresuNavigation { get; set; }

    [ForeignKey("KtoDodal")]
    [InverseProperty("KlientKtoDodalNavigations")]
    public virtual Uzytkownik? KtoDodalNavigation { get; set; }

    [ForeignKey("KtoUsunal")]
    [InverseProperty("KlientKtoUsunalNavigations")]
    public virtual Uzytkownik? KtoUsunalNavigation { get; set; }

    [ForeignKey("KtoZmodyfikowal")]
    [InverseProperty("KlientKtoZmodyfikowalNavigations")]
    public virtual Uzytkownik? KtoZmodyfikowalNavigation { get; set; }

    [JsonIgnore]
    [InverseProperty("IdKlientaNavigation")]
    public virtual ICollection<SesjaKoszyka> SesjaKoszykas { get; set; } = new List<SesjaKoszyka>();

    [JsonIgnore]
    [InverseProperty("IdKlientaNavigation")]
    public virtual ICollection<Zamowienie> Zamowienies { get; set; } = new List<Zamowienie>();
}
