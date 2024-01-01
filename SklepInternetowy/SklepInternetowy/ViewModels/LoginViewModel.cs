using System.Threading.Tasks;
using SklepInternetowy.Services;
using SklepInternetowy.Views.LoginAndRegister;
using SklepInternetowyServiceReference;
using Xamarin.Forms;

namespace SklepInternetowy.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginAndRegisterService _loginAndRegisterService;
        private readonly UserService _userToken;

        private string _email;
        private string _password;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
            RegisterCommand = new Command(async () => await OnRegisterClicked());

            _loginAndRegisterService = new LoginAndRegisterService();
            _userToken = DependencyService.Get<UserService>();
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

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


        private async Task OnLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AppShell)}");

            var loginDto = new LoginDto
            {
                Email = _email,
                Password = _password
            };
            
            try
            {
                var jwtStorage = await _loginAndRegisterService.Login(loginDto);
                if (jwtStorage != null)
                {
                    //For authorization
                    // await SecureStorage.SetAsync("AuthToken", jwtStorage.Jwt);
                    _userToken.Token = jwtStorage.Jwt;
                    _userToken.DecodeJwt();
                    Application.Current.MainPage = new AppShell();
                }
            }
            catch (ApiException apiException)
            {
                await App.Current.MainPage.DisplayAlert(null, apiException.Response, "OK", FlowDirection.MatchParent);
            }
        }

        private async Task OnRegisterClicked()
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}