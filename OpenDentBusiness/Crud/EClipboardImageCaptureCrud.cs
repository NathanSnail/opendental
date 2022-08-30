//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EClipboardImageCaptureCrud {
		///<summary>Gets one EClipboardImageCapture object from the database using the primary key.  Returns null if not found.</summary>
		public static EClipboardImageCapture SelectOne(long eClipboardImageCaptureNum) {
			string command="SELECT * FROM eclipboardimagecapture "
				+"WHERE EClipboardImageCaptureNum = "+POut.Long(eClipboardImageCaptureNum);
			List<EClipboardImageCapture> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EClipboardImageCapture object from the database using a query.</summary>
		public static EClipboardImageCapture SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EClipboardImageCapture> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EClipboardImageCapture objects from the database using a query.</summary>
		public static List<EClipboardImageCapture> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EClipboardImageCapture> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EClipboardImageCapture> TableToList(DataTable table) {
			List<EClipboardImageCapture> retVal=new List<EClipboardImageCapture>();
			EClipboardImageCapture eClipboardImageCapture;
			foreach(DataRow row in table.Rows) {
				eClipboardImageCapture=new EClipboardImageCapture();
				eClipboardImageCapture.EClipboardImageCaptureNum= PIn.Long  (row["EClipboardImageCaptureNum"].ToString());
				eClipboardImageCapture.PatNum                   = PIn.Long  (row["PatNum"].ToString());
				eClipboardImageCapture.DefNum                   = PIn.Long  (row["DefNum"].ToString());
				eClipboardImageCapture.IsSelfPortrait           = PIn.Bool  (row["IsSelfPortrait"].ToString());
				eClipboardImageCapture.DateTimeUpserted         = PIn.DateT (row["DateTimeUpserted"].ToString());
				eClipboardImageCapture.DocNum                   = PIn.Long  (row["DocNum"].ToString());
				retVal.Add(eClipboardImageCapture);
			}
			return retVal;
		}

		///<summary>Converts a list of EClipboardImageCapture into a DataTable.</summary>
		public static DataTable ListToTable(List<EClipboardImageCapture> listEClipboardImageCaptures,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EClipboardImageCapture";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EClipboardImageCaptureNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("DefNum");
			table.Columns.Add("IsSelfPortrait");
			table.Columns.Add("DateTimeUpserted");
			table.Columns.Add("DocNum");
			foreach(EClipboardImageCapture eClipboardImageCapture in listEClipboardImageCaptures) {
				table.Rows.Add(new object[] {
					POut.Long  (eClipboardImageCapture.EClipboardImageCaptureNum),
					POut.Long  (eClipboardImageCapture.PatNum),
					POut.Long  (eClipboardImageCapture.DefNum),
					POut.Bool  (eClipboardImageCapture.IsSelfPortrait),
					POut.DateT (eClipboardImageCapture.DateTimeUpserted,false),
					POut.Long  (eClipboardImageCapture.DocNum),
				});
			}
			return table;
		}

		///<summary>Inserts one EClipboardImageCapture into the database.  Returns the new priKey.</summary>
		public static long Insert(EClipboardImageCapture eClipboardImageCapture) {
			return Insert(eClipboardImageCapture,false);
		}

		///<summary>Inserts one EClipboardImageCapture into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EClipboardImageCapture eClipboardImageCapture,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				eClipboardImageCapture.EClipboardImageCaptureNum=ReplicationServers.GetKey("eclipboardimagecapture","EClipboardImageCaptureNum");
			}
			string command="INSERT INTO eclipboardimagecapture (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EClipboardImageCaptureNum,";
			}
			command+="PatNum,DefNum,IsSelfPortrait,DateTimeUpserted,DocNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(eClipboardImageCapture.EClipboardImageCaptureNum)+",";
			}
			command+=
				     POut.Long  (eClipboardImageCapture.PatNum)+","
				+    POut.Long  (eClipboardImageCapture.DefNum)+","
				+    POut.Bool  (eClipboardImageCapture.IsSelfPortrait)+","
				+    POut.DateT (eClipboardImageCapture.DateTimeUpserted)+","
				+    POut.Long  (eClipboardImageCapture.DocNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				eClipboardImageCapture.EClipboardImageCaptureNum=Db.NonQ(command,true,"EClipboardImageCaptureNum","eClipboardImageCapture");
			}
			return eClipboardImageCapture.EClipboardImageCaptureNum;
		}

		///<summary>Inserts one EClipboardImageCapture into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EClipboardImageCapture eClipboardImageCapture) {
			return InsertNoCache(eClipboardImageCapture,false);
		}

		///<summary>Inserts one EClipboardImageCapture into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EClipboardImageCapture eClipboardImageCapture,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO eclipboardimagecapture (";
			if(!useExistingPK && isRandomKeys) {
				eClipboardImageCapture.EClipboardImageCaptureNum=ReplicationServers.GetKeyNoCache("eclipboardimagecapture","EClipboardImageCaptureNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EClipboardImageCaptureNum,";
			}
			command+="PatNum,DefNum,IsSelfPortrait,DateTimeUpserted,DocNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(eClipboardImageCapture.EClipboardImageCaptureNum)+",";
			}
			command+=
				     POut.Long  (eClipboardImageCapture.PatNum)+","
				+    POut.Long  (eClipboardImageCapture.DefNum)+","
				+    POut.Bool  (eClipboardImageCapture.IsSelfPortrait)+","
				+    POut.DateT (eClipboardImageCapture.DateTimeUpserted)+","
				+    POut.Long  (eClipboardImageCapture.DocNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				eClipboardImageCapture.EClipboardImageCaptureNum=Db.NonQ(command,true,"EClipboardImageCaptureNum","eClipboardImageCapture");
			}
			return eClipboardImageCapture.EClipboardImageCaptureNum;
		}

		///<summary>Updates one EClipboardImageCapture in the database.</summary>
		public static void Update(EClipboardImageCapture eClipboardImageCapture) {
			string command="UPDATE eclipboardimagecapture SET "
				+"PatNum                   =  "+POut.Long  (eClipboardImageCapture.PatNum)+", "
				+"DefNum                   =  "+POut.Long  (eClipboardImageCapture.DefNum)+", "
				+"IsSelfPortrait           =  "+POut.Bool  (eClipboardImageCapture.IsSelfPortrait)+", "
				+"DateTimeUpserted         =  "+POut.DateT (eClipboardImageCapture.DateTimeUpserted)+", "
				+"DocNum                   =  "+POut.Long  (eClipboardImageCapture.DocNum)+" "
				+"WHERE EClipboardImageCaptureNum = "+POut.Long(eClipboardImageCapture.EClipboardImageCaptureNum);
			Db.NonQ(command);
		}

		///<summary>Updates one EClipboardImageCapture in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EClipboardImageCapture eClipboardImageCapture,EClipboardImageCapture oldEClipboardImageCapture) {
			string command="";
			if(eClipboardImageCapture.PatNum != oldEClipboardImageCapture.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(eClipboardImageCapture.PatNum)+"";
			}
			if(eClipboardImageCapture.DefNum != oldEClipboardImageCapture.DefNum) {
				if(command!="") { command+=",";}
				command+="DefNum = "+POut.Long(eClipboardImageCapture.DefNum)+"";
			}
			if(eClipboardImageCapture.IsSelfPortrait != oldEClipboardImageCapture.IsSelfPortrait) {
				if(command!="") { command+=",";}
				command+="IsSelfPortrait = "+POut.Bool(eClipboardImageCapture.IsSelfPortrait)+"";
			}
			if(eClipboardImageCapture.DateTimeUpserted != oldEClipboardImageCapture.DateTimeUpserted) {
				if(command!="") { command+=",";}
				command+="DateTimeUpserted = "+POut.DateT(eClipboardImageCapture.DateTimeUpserted)+"";
			}
			if(eClipboardImageCapture.DocNum != oldEClipboardImageCapture.DocNum) {
				if(command!="") { command+=",";}
				command+="DocNum = "+POut.Long(eClipboardImageCapture.DocNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE eclipboardimagecapture SET "+command
				+" WHERE EClipboardImageCaptureNum = "+POut.Long(eClipboardImageCapture.EClipboardImageCaptureNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(EClipboardImageCapture,EClipboardImageCapture) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EClipboardImageCapture eClipboardImageCapture,EClipboardImageCapture oldEClipboardImageCapture) {
			if(eClipboardImageCapture.PatNum != oldEClipboardImageCapture.PatNum) {
				return true;
			}
			if(eClipboardImageCapture.DefNum != oldEClipboardImageCapture.DefNum) {
				return true;
			}
			if(eClipboardImageCapture.IsSelfPortrait != oldEClipboardImageCapture.IsSelfPortrait) {
				return true;
			}
			if(eClipboardImageCapture.DateTimeUpserted != oldEClipboardImageCapture.DateTimeUpserted) {
				return true;
			}
			if(eClipboardImageCapture.DocNum != oldEClipboardImageCapture.DocNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EClipboardImageCapture from the database.</summary>
		public static void Delete(long eClipboardImageCaptureNum) {
			string command="DELETE FROM eclipboardimagecapture "
				+"WHERE EClipboardImageCaptureNum = "+POut.Long(eClipboardImageCaptureNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EClipboardImageCaptures from the database.</summary>
		public static void DeleteMany(List<long> listEClipboardImageCaptureNums) {
			if(listEClipboardImageCaptureNums==null || listEClipboardImageCaptureNums.Count==0) {
				return;
			}
			string command="DELETE FROM eclipboardimagecapture "
				+"WHERE EClipboardImageCaptureNum IN("+string.Join(",",listEClipboardImageCaptureNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}