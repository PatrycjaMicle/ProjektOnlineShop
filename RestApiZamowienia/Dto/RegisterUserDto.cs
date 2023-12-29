namespace RestApiZamowienia.Dto;

public class RegisterUserDto
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}