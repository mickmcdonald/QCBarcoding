using System;
using System.Collections.Generic;
using Android.Widget;
using Android.App;
using Android;
using QCBarcoding.model;

namespace DataAccess {
	public class JobListAdapter : BaseAdapter<Job> {
		Activity context = null;
		IList<Job> Jobs = new List<Job>();
		
		public JobListAdapter (Activity context, IList<Job> Jobs) : base ()
		{
			this.context = context;
			this.Jobs = Jobs;
		}
		
		public override Job this[int position]
		{
			get { return Jobs[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return Jobs.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = Jobs[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
					context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItem1,
					parent, 
					false)) as TextView;

			view.SetText (item.JobNo == "" ? "<new Job>" : item.JobNo, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}