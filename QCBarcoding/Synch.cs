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
using System.IO;
using SQLite;
using QCBarcoding.model;

namespace QCBarcoding
{
  [Activity(Label = "Synch")]
  public class Synch : Activity
  {
    protected Job newjob = new Job();
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);


      object locker = new object(); // class level private field
      // rest of class code
      lock (locker)
      {
        newjob.JobId = 7422;
        newjob.JobNo = "CINC1393";
        newjob.DateCreated = "2016-07-24 08:42:44.457";
        JobRepository.SaveJob(newjob);

        newjob = new Job();
        newjob.JobId = 7421;
        newjob.JobNo = "SFOC1217";
        newjob.DateCreated = "2016-07-23 15:00:27.457";
        JobRepository.SaveJob(newjob);

        newjob = new Job();
        newjob.JobId = 7421;
        newjob.JobNo = "SFOC1217";
        newjob.DateCreated = "2016-07-23 15:00:27.457";
        JobRepository.SaveJob(newjob);
      }
    }
  }
}