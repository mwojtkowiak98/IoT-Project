using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Support.V4.App;

namespace FoodOrderApp.Droid
{

        [Activity(Label = "FoodOrderApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
        public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        {
            static readonly int NOTIFICATION_ID = 1000;
            static readonly string CHANNEL_ID = "location_notification";

            protected override void OnCreate(Bundle savedInstanceState)
            {
                TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(savedInstanceState);

                CreateNotificationChannel();
                NotificationFeature();

                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

                LoadApplication(new App());

            }
            public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }

            void CreateNotificationChannel()
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                {
                    return;
                }

                var channel = new NotificationChannel(CHANNEL_ID, "channelName", NotificationImportance.Default)
                {
                    Description = "NotificationChannel_description"
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }

            public void NotificationFeature()
            {
                var builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                              .SetAutoCancel(true)
                              .SetContentTitle("Food Order App")
                              .SetContentText("It's nice to see you again! Check our new Menu!")
                              .SetSmallIcon(Resource.Drawable.icbutton);

                var notificationManager = NotificationManagerCompat.From(this);
                notificationManager.Notify(NOTIFICATION_ID, builder.Build());
            }

        }
}