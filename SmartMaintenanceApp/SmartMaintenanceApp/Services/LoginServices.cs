using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SmartMaintenanceApp.Models;
using System.Diagnostics;


namespace SmartMaintenanceApp.Services
{
    class LoginServices
    {
        public async Task LoginAsync(string userName, string password)
        {
            LoginInfo item = new LoginInfo();
            item.Email = userName;
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

                Debug.WriteLine(content2);

            }
            else
            {
                Console.WriteLine();
            }


        }

    }
}
