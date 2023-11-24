using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

[Table("Uzytkownik")]
public partial class Uzytkownik
{
    [Key]
    public int IdUzytkownika { get; set; }

    [StringLength(50)]
    public string? Imie { get; set; }

    [StringLength(50)]
    public string? Nazwisko { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataDodania { get; set; }

    [StringLength(50)]
    public string? Login { get; set; }

    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Adre> AdreKtoDodalNavigations { get; set; } = new List<Adre>();

    [InverseProperty("KtoEdytowalNavigation")]
    public virtual ICollection<Adre> AdreKtoEdytowalNavigations { get; set; } = new List<Adre>();

    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Adre> AdreKtoUsunalNavigations { get; set; } = new List<Adre>();

    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoDodalNavigations { get; set; } = new List<Kategorium>();

    [InverseProperty("KtoEdytowalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoEdytowalNavigations { get; set; } = new List<Kategorium>();

    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Kategorium> KategoriumKtoUsunalNavigations { get; set; } = new List<Kategorium>();

    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Klient> KlientKtoDodalNavigations { get; set; } = new List<Klient>();

    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Klient> KlientKtoUsunalNavigations { get; set; } = new List<Klient>();

    [InverseProperty("KtoZmodyfikowalNavigation")]
    public virtual ICollection<Klient> KlientKtoZmodyfikowalNavigations { get; set; } = new List<Klient>();

    [InverseProperty("KtoDodalNavigation")]
    public virtual ICollection<Towar> TowarKtoDodalNavigations { get; set; } = new List<Towar>();

    [InverseProperty("KtoUsunalNavigation")]
    public virtual ICollection<Towar> TowarKtoUsunalNavigations { get; set; } = new List<Towar>();

    [InverseProperty("KtoZmodyfikowalNavigation")]
    public virtual ICollection<Towar> TowarKtoZmodyfikowalNavigations { get; set; } = new List<Towar>();
}
