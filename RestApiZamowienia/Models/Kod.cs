using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestApiZamowienia.Models;

[Table("Kod")]
public class Kod
{
    [Key]
    public int IdKodu { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [JsonIgnore]
    public ICollection<KodPromocji> KodyPromocji { get; set; } = new List<KodPromocji>();
}