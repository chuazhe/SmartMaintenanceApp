using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SmartMaintenanceApp.Droid
{
    class AndroidConstants
    {
        public const string ListenConnectionString = "Endpoint=sb://smartmaintenance.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=HhgHkUNuWlSB75zWfi8kT/pcDkW5Q4AjVHTsa9pgDAA=";
        public const string NotificationHubName = "SmartMaintenance";
    }
}