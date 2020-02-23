using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMaintenanceApp.Models
{
    public class Constants
    {
        // /10.0.2.2 is the computer IP, because the localhost of emulator is the emulator, not the computer

        //public const string RequestUri = "http://10.0.2.2:4000/";
        //public const string RequestUri = "http://192.0.2.2:4000/";

        public const string RequestUri = "http://86b49f5c.ngrok.io/";
        




        public const string AuthStateKey = "authState";
        public const string AuthServiceDiscoveryKey = "authServiceDiscovery";

        public const string ClientId = "{clientId}";
        public const string RedirectUri = "{redirectUri}";
        public const string OrgUrl = "https://{yourOktaDomain}";
        public const string AuthorizationServerId = "default";

        public static readonly string DiscoveryEndpoint =
            $"{OrgUrl}/oauth2/{AuthorizationServerId}/.well-known/openid-configuration";


        public static readonly string[] Scopes = new string[] {
        "openid", "profile", "email", "offline_access" };


    }
}
