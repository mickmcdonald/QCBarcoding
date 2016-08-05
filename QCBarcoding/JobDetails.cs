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

namespace QCBarcoding
{
  [Activity(Label = "Job Details")]
  public class JobDetails : Activity
  {
    protected Job job = new model.Job();
    protected Button NewPartButton = null;
		protected TextView jobNoTextEditMed = null;
		protected Button saveButton = null;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      this.SetContentView(Resource.Layout.JobDetails);

      Button NewPartButton = FindViewById<Button>(Resource.Id.NewPartButton);
      NewPartButton.Click += PartFormLoad;

      // Create your application here
      int jobId = Intent.GetIntExtra("JobID", 0);
			if (jobId > 0) {
				job = JobRepository.GetJob(jobId);
			}

      jobNoTextEditMed = FindViewById<TextView>(Resource.Id.textMedJobNo);

      if(jobNoTextEditMed != null) { jobNoTextEditMed.Text = "Job No: " + job.JobNo; }
    }

    protected void PartFormLoad (object sender, EventArgs ea)
    {
      this.StartActivity(typeof(PartForm));
      // this.SetContentView(Resource.Layout.PartForm);
    }
  }
}