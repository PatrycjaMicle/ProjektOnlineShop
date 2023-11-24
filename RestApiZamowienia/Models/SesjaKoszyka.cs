using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

[Table("SesjaKoszyka")]
public partial class SesjaKoszyka
{
    [Key]
    public int IdSesjiKoszyka { get; set; }

    public int? IdKlienta { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Suma { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUtworzenia { get; set; }

    [InverseProperty("IdSesjiKoszykaNavigation")]
    public virtual ICollection<ElementKoszyka> ElementKoszykas { get; set; } = new List<ElementKoszyka>();

    [ForeignKey("IdKlienta")]
    [InverseProperty("SesjaKoszykas")]
    public virtual Klient? IdKlientaNavigation { get; set; }
}
