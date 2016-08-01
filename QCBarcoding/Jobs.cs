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
using QCBarcoding.model;
using DataAccess;

namespace QCBarcoding
{
  [Activity(Label = "Jobs")]
  public class Jobs : Activity
  {
    protected JobListAdapter jobList;
    protected IList<Job> jobs;
    protected ListView jobListView = null;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      this.SetContentView(Resource.Layout.Jobs);
      // Create your application here

      jobListView = FindViewById<ListView>(Resource.Id.JobList);

      //Android.Widget.ListView progList = FindViewById<ListView>(Resource.Id.JobList);
      //string[] items = new string[] { "Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers" };
      //ArrayAdapter<string> ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
      //progList.Adapter = ListAdapter;
      ListJobs();
    }

    protected override void OnResume()
    {
      base.OnResume();


    }

    protected void ListJobs()
    {
      jobs = JobRepository.GetJobs().ToList();

      // create our adapter
      jobList = new JobListAdapter(this, jobs);

      //Hook up our adapter to our ListView
      jobListView.Adapter = jobList;
    }
  }
}