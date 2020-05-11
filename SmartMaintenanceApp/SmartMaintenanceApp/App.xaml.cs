using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartMaintenanceApp.Views;
using SmartMaintenanceApp.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartMaintenanceApp
{
    public partial class App : Application
    {

        public static bool IsUserLoggedIn { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; }

        public App()
        {

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }

        private void SetLoginPageAsRootPage(object sender)
        {
            MainPage = new LoginPage();
        }

        private void SetMainPageAsRootPage(object sender)
        {
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
