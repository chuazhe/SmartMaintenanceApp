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
        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine("Login" + App.IsUserLoggedIn);

            Email.Text = "Logged in as: "+App.Email;
            Role.Text = "Role: "+App.Role;
            //MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);

        }

        private void LogoutClicked(object sender, EventArgs e)
        {

            App.IsUserLoggedIn = false;
            App.Current.MainPage = new NavigationPage(new LoginPage());
            Debug.WriteLine("Logout" + App.IsUserLoggedIn);

        }

        /*

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
        */


        /*
        public void AddMessage(string message)
        {

            System.Diagnostics.Debug.WriteLine(message);
        }
        */
    }
}