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
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace SmartMaintenanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public event EventHandler<string> LoginChanged;
        LoginViewModel viewModel;



        public LoginPage()
        {
            InitializeComponent();


            BindingContext = viewModel = new LoginViewModel();

        }



        private async void LoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            //await DisplayAlert("Greeting", $"Hello {email+","+password}!", "Howdy");


            LoginInfo item = new LoginInfo();
            item.Email = email;
            item.Password = password;

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            var client = new HttpClient();
            response = await client.PostAsync(Constants.RequestUri + "api/account/login", content);
            var content2 = await response.Content.ReadAsStringAsync();
            //content 2 is the token

            if (response.IsSuccessStatusCode)
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var token = jwtHandler.ReadJwtToken(content2);
                var role = token.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
                LoginPanel.IsVisible = false;
                //LogoutPanel.IsVisible = true;
                ErrorLabel.Text = "";
                Debug.WriteLine("You are logged in as " + email + "  " + role);
                //MessagingCenter.Send<object,string,string>(this, App.EVENT_LAUNCH_MAIN_PAGE,email,role);
                App.IsUserLoggedIn = true;
                App.Email = email;
                App.Role = role;

                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();

            }
            else
            {
                ErrorLabel.Text = "Login failed";
                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;

                return;
            }
        }




        private void LogoutClicked(object sender, EventArgs e)
        {
            LoginPanel.IsVisible = true;
            //LogoutPanel.IsVisible = false;
            if (LoginChanged != null) LoginChanged(this, null);
            //MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_LOGIN_PAGE);
            //MessagingCenter.Send<object>(this, App.EVENT_LAUNCH_LOGIN_PAGE);



        }
    }
}