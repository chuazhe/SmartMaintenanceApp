using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartMaintenanceApp.Models;

namespace SmartMaintenanceApp.Services
{
    public interface ILoginProvider
    {
        Task<string> LoginAsync();
    }
}
