using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RestApiZamowienia.Models.Context;

namespace RestApiZamowienia.Models;

[Table("KodPromocji")]
public class KodPromocji
{
    [Key]
    public int IdKoduPromocji { get; set; }

    public int? IdPromocji { get; set; }
    
    [JsonIgnore]
    public Promocja? Promocja { get; set; }

    public int? IdKodu { get; set; }
    
    [JsonIgnore]
    public Kod? Kod { get; set; }

    [InverseProperty("IdKoduPromocjiNavigation")]
    [JsonIgnore]

    public virtual ICollection<Zamowienie> Zamowienies { get; set; } = new List<Zamowienie>();
}
