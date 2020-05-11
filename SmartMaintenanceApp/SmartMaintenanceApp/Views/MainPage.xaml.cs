using SmartMaintenanceApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMaintenanceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine("Login" + App.IsUserLoggedIn);

            Email.Text = "Logged in as: "+App.Email;
            Role.Text = "Role: "+App.Role;


        }

        private void LogoutClicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            App.Current.MainPage = new NavigationPage(new LoginPage());
            Debug.WriteLine("Logout" + App.IsUserLoggedIn);

        }



    }
}