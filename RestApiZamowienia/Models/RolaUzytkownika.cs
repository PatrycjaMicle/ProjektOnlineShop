using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiZamowienia.Models;

public class RolaUzytkownika
{
    public int Id { get; set; }
    public string Name { get; set; }

    [InverseProperty("RolaUzytkownikaIdNavigation")]
    public virtual ICollection<Uzytkownik> Uzytkowniks { get; set; } = new List<Uzytkownik>();
}
