using System.Threading.Tasks;
using SklepInternetowy.Services;
using SklepInternetowy.Views.LoginAndRegister;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels.LoginAndRegister
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly LoginAndRegisterService _loginAndRegisterService;
        private string _confirmPassword;
        private string _email;
        private string _imie;
        private string _nazwisko;
        private string _password;

        private string _userName;

        public RegisterViewModel()
        {
            _loginAndRegisterService = new LoginAndRegisterService();
            RegisterCommand = new Command(async () => await SignUp());
        }

        public string Imie
        {
            get => _imie;
            set => SetProperty(ref _imie, value);
        }

        public string Nazwisko
        {
            get => _nazwisko;
            set => SetProperty(ref _nazwisko, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public Command RegisterCommand { get; }

        private async Task SignUp()
        {
            var registerDto = new RegisterUserDto
            {
                Imie = _imie,
                Nazwisko = _nazwisko,
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            await _loginAndRegisterService.Register(registerDto);
            Application.Current.MainPage = new LoginPage();
        }
    }
}