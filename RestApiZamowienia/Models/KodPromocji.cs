using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
}
