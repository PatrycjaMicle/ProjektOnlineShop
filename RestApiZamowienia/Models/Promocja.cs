using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("Promocja")]
public class Promocja
{
    [Key]
    public int IdPromocji { get; set; }

    [StringLength(50)]
    public string? Wartosc { get; set; }

    [JsonIgnore]
    public ICollection<KodPromocji> KodyPromocji { get; set; } = new List<KodPromocji>();
}
