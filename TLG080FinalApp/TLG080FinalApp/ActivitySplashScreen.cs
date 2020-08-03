using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TLG080FinalApp.Resources
{
    [Activity(Label = "ActivitySplashScreen", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]
    public class ActivitySplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Thread.Sleep(2000);
            //Start Activity1 Activity  
            StartActivity(typeof(MainActivity));
        }
    }
}