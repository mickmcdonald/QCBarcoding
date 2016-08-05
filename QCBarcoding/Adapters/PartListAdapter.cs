using System;
using System.Collections.Generic;
using Android.Widget;
using Android.App;
using Android;
using QCBarcoding.model;

namespace DataAccess {
	public class PartListAdapter : BaseAdapter<Part> {
		Activity context = null;
		IList<Part> Parts = new List<Part>();
		
		public PartListAdapter (Activity context, IList<Part> Parts) : base ()
		{
			this.context = context;
			this.Parts = Parts;
		}
		
		public override Part this[int position]
		{
			get { return Parts[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return Parts.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = Parts[position];			

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			// will sound familiar to MonoTouch developers with UITableViewCell.DequeueReusableCell()
			var view = (convertView ?? 
					context.LayoutInflater.Inflate(
					Android.Resource.Layout.SimpleListItem1,
					parent, 
					false)) as TextView;

			view.SetText (item.PartNo == "" ? "<new Part>" : item.PartNo, TextView.BufferType.Normal);

			//Finally return the view
			return view;
		}
	}
}