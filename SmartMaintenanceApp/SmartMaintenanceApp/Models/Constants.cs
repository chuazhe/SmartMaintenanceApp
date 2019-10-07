using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMaintenanceApp.Models
{
    public class Constants
    {
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


        public string GetOrgUrl { get;}

    }
}
