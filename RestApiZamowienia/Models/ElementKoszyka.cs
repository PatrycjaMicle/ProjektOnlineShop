using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
    public virtual SesjaKoszyka? IdSesjiKoszykaNavigation { get; set; }

    [ForeignKey("IdTowaru")]
    [InverseProperty("ElementKoszykas")]
    public virtual Towar? IdTowaruNavigation { get; set; }
}
