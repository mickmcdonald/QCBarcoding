using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;

namespace QCBarcoding.model
{
	public class JobDatabase : SQLiteConnection
	{
		static object locker = new object ();

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "QCBarcoding.db3";
				
#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else
				
#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else
				
#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		
				
#endif
				return path;	
			}
		}

		public JobDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<Job> ();
		}

		public IEnumerable<Job> GetJobs () 
		{
			lock (locker) {
				return (from i in Table<Job> () select i).ToList ();
			}
		}
		
		public Job GetJob (int id)
		{
			lock (locker) {
				return Table<Job>().FirstOrDefault(x => x.Id == id);
			}
		}
		
		public int SaveJob (Job item) 
		{
			lock (locker) {
				if (item.Id != 0) {
					Update (item);
					return item.Id;
				} else {
					return Insert (item);
				}
			}
		}
		
//		public int DeleteJob(int id) 
//		{
//			lock (locker) {
//				return Delete<Job> (new Job () { Id = id });
//			}
//		}
		public int DeleteJob(Job Job) 
		{
			lock (locker) {
				return Delete<Job> (Job.Id);
			}
		}
	}
}