using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using WindowsAzure.Messaging;

namespace SmartMaintenanceApp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseRegistrationService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            string token = FirebaseInstanceId.Instance.Token;

            Log.Info(AndroidConstants.DebugTag, $"Token received: {token}");

            SendRegistrationToServer(token);
        }

        void SendRegistrationToServer(string token)
        {
            try
            {
                NotificationHub hub = new NotificationHub(AndroidConstants.NotificationHubName, AndroidConstants.ListenConnectionString, this);

                // register device with Azure Notification Hub using the token from FCM
                Registration reg = hub.Register(token, AndroidConstants.SubscriptionTags);

                // subscribe to the SubscriptionTags list with a simple template.
                string pnsHandle = reg.PNSHandle;
                var cats = string.Join(", ", reg.Tags);
                var temp = hub.RegisterTemplate(pnsHandle, "defaultTemplate", AndroidConstants.FCMTemplateBody, AndroidConstants.SubscriptionTags);
            }
            catch (Exception e)
            {
                Log.Error(AndroidConstants.DebugTag, $"Error registering device: {e.Message}");
            }
        }
    }
}