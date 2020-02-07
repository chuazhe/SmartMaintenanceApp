using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SmartMaintenanceApp.Models;
using SmartMaintenanceApp.Views;
using SmartMaintenanceApp.Services;
using System.Windows.Input;

namespace SmartMaintenanceApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private LoginServices _loginServices = new LoginServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new Command(async() =>
                                                      {
                                                          await _loginServices.LoginAsync(Email, Password);
                                                      });




    }
}
