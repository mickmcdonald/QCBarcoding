using System;
using System.Collections.Generic;

namespace QCBarcoding.model
{
	public class JobRepository
	{
		JobDatabase db = null;
		protected static JobRepository me;	
		static JobRepository ()
		{
			me = new JobRepository();
		}
		protected JobRepository()
		{
			db = new JobDatabase(JobDatabase.DatabaseFilePath);
		}

		public static Job GetJob(int id)
		{
			return me.db.GetJob(id);
		}
		
		public static IEnumerable<Job> GetJobs ()
		{
			return me.db.GetJobs();
		}
		
		public static int SaveJob (Job item)
		{
			return me.db.SaveJob(item);
		}
		
		public static int DeleteJob(Job item)
		{
			return me.db.DeleteJob(item);
		}
	}
}

