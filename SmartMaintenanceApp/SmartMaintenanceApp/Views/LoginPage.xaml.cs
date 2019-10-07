using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using SmartMaintenanceApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartMaintenanceApp.ViewModels;
using SmartMaintenanceApp.Models;


namespace SmartMaintenanceApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public event EventHandler<string> LoginChanged;
        LoginViewModel viewModel;



        public LoginPage ()
		{
			InitializeComponent();


            BindingContext = viewModel = new LoginViewModel();

        }



        private async void LoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            //await DisplayAlert("Greeting", $"Hello {email+","+password}!", "Howdy");

            var server = Constants.AuthorizationServerId;


            var loginProvider = DependencyService.Get<ILoginProvider>();
            var idToken = await loginProvider.LoginAsync();

            string userName = null;
            if (idToken != null)
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var token = jwtHandler.ReadJwtToken(idToken);
                userName = token.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
            }

            if (LoginChanged != null) LoginChanged(this, userName);

            if (userName == null)
            {
                ErrorLabel.Text = "Login failed.";
                return;
            }

            LoginPanel.IsVisible = false;
            LogoutPanel.IsVisible = true;
            ErrorLabel.Text = "";
            LoggedInLabel.Text = "You are logged in as " + userName;
        }
        

        private void LogoutClicked(object sender, EventArgs e)
        {
            LoginPanel.IsVisible = true;
            LogoutPanel.IsVisible = false;
            if (LoginChanged != null) LoginChanged(this, null);
        }
    }
}