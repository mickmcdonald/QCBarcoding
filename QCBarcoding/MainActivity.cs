using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace QCBarcoding
{
  [Activity(Label = "QCBarcoding", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);

      // Get our button from the layout resource,
      // and attach an event to it
      Button JobButton = FindViewById<Button>(Resource.Id.JobButton);
      JobButton.Click += JobButtonClick;

      Button SynchButton = FindViewById<Button>(Resource.Id.SynchButton);
      SynchButton.Click += SynchButtonClick;

      Button ExitButton = FindViewById<Button>(Resource.Id.ExitButton);
      ExitButton.Click += ExitButtonClick;
    }

    protected void SynchButtonClick (object sender, EventArgs ea)
    {
       this.StartActivity(typeof(Synch));
    }

    protected void JobButtonClick (object sender, EventArgs ea)
    {
       this.StartActivity(typeof(Jobs));
    }

    protected void ExitButtonClick(object sender, EventArgs ea)
    {
       System.Environment.Exit(0);
    }
    
  }
}

