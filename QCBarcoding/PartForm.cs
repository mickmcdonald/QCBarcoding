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
  [Activity(Label = "Part Form")]
  public class PartForm : Activity
  {
    protected Part Part = new model.Part();
    protected Button NewPartButton = null;
		protected TextView PartNoTextEditMed = null;
		protected Button saveButton = null;

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      this.SetContentView(Resource.Layout.PartForm);

      // Create your application here
      int PartId = Intent.GetIntExtra("PartID", 0);
			if (PartId > 0) {
				Part = PartRepository.GetPart(PartId);
			}

      PartNoTextEditMed = FindViewById<TextView>(Resource.Id.editPartNo);

      if(PartNoTextEditMed != null) { PartNoTextEditMed.Text = Part.PartNo; }
    }
  }
}