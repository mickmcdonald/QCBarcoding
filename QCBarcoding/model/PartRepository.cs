using System;
using System.Collections.Generic;

namespace QCBarcoding.model
{
	public class PartRepository
	{
		PartDatabase db = null;
		protected static PartRepository me;	
		static PartRepository ()
		{
			me = new PartRepository();
		}
		protected PartRepository()
		{
			db = new PartDatabase(PartDatabase.DatabaseFilePath);
		}

		public static Part GetPart(int id)
		{
			return me.db.GetPart(id);
		}
		
		public static IEnumerable<Part> GetParts ()
		{
			return me.db.GetParts();
		}
		
		public static int SavePart (Part item)
		{
			return me.db.SavePart(item);
		}
		
		public static int DeletePart(Part item)
		{
			return me.db.DeletePart(item);
		}
	}
}

