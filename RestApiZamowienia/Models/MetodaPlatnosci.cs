using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiZamowienia.Models;

[Table("MetodaPlatnosci")]
public partial class MetodaPlatnosci
{
    [Key]
    public int IdMetodyPlatnosci { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [InverseProperty("IdMetodyPlatnosciNavigation")]
    public virtual ICollection<Zamowienie> Zamowienies { get; set; } = new List<Zamowienie>();
}
