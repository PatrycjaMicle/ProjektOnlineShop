using SklepInternetowy.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SklepInternetowy.Views.LoginAndRegister;
using SklepInternetowyServiceReference;
using Xamarin.Forms;
using SklepInternetowy.Services.DataStore;

namespace SklepInternetowy.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        readonly LoginAndRegisterService _loginAndRegisterService;

        private string _email;
        private string _password;

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
            RegisterCommand = new Command( async () => await OnRegisterClicked());

            _loginAndRegisterService = new LoginAndRegisterService();
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

            var loginDto = new LoginDto()
            {
                Email = _email,
                Password = _password
            };

            //TODO add jwt decoding to get user role value
            var jwtStorage = await _loginAndRegisterService.Login(loginDto);

            if (jwtStorage != null)
            {
                App.Current.MainPage = new AppShell();
            }

        }

        private async Task OnRegisterClicked()
        { 
            App.Current.MainPage = new RegisterPage();
        }
    }
}
