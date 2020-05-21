using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using SmartMaintenanceApp.Views;

namespace SmartMaintenanceApp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            if (App.IsUserLoggedIn)
            {
                base.OnMessageReceived(message);
                string messageBody = string.Empty;

                if (message.GetNotification() != null)
                {
                    messageBody = message.GetNotification().Body;
                }

                // NOTE: test messages sent via the Azure portal will be received here
                else
                {
                    //messageBody = message.Data.Values.First();
                    messageBody = message.Data["message"];
                }

                //User

                int value = Convert.ToInt32(message.Data["manager"]);

                //Check for Manager
                if (value == 1 && App.Role == "Manager")
                {
                    // convert the incoming message to a local notification
                    SendLocalNotification(messageBody);

                    // send the incoming message directly to the MainPage
                    SendMessageToMainPage(messageBody);
                }

                //Check for User
                if (value == 0 && App.Role == "User")
                {
                    // convert the incoming message to a local notification
                    SendLocalNotification(messageBody);

                    // send the incoming message directly to the MainPage
                    SendMessageToMainPage(messageBody);
                }




            }

        }

        void SendLocalNotification(string body)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("message", body);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetContentTitle("XamarinNotify Message")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentText(body)
                .SetAutoCancel(true)
                .SetShowWhen(false)
                .SetContentIntent(pendingIntent);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                notificationBuilder.SetChannelId(AndroidConstants.NotificationChannelName);
            }

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
        }

        void SendMessageToMainPage(string body)
        {
            Log.Debug("Notification", body);
        }
    }
}