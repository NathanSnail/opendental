//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class FHIRContactPointCrud {
		///<summary>Gets one FHIRContactPoint object from the database using the primary key.  Returns null if not found.</summary>
		public static FHIRContactPoint SelectOne(long fHIRContactPointNum) {
			string command="SELECT * FROM fhircontactpoint "
				+"WHERE FHIRContactPointNum = "+POut.Long(fHIRContactPointNum);
			List<FHIRContactPoint> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one FHIRContactPoint object from the database using a query.</summary>
		public static FHIRContactPoint SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<FHIRContactPoint> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of FHIRContactPoint objects from the database using a query.</summary>
		public static List<FHIRContactPoint> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<FHIRContactPoint> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<FHIRContactPoint> TableToList(DataTable table) {
			List<FHIRContactPoint> retVal=new List<FHIRContactPoint>();
			FHIRContactPoint fHIRContactPoint;
			foreach(DataRow row in table.Rows) {
				fHIRContactPoint=new FHIRContactPoint();
				fHIRContactPoint.FHIRContactPointNum= PIn.Long  (row["FHIRContactPointNum"].ToString());
				fHIRContactPoint.FHIRSubscriptionNum= PIn.Long  (row["FHIRSubscriptionNum"].ToString());
				fHIRContactPoint.ContactSystem      = (OpenDentBusiness.ContactPointSystem)PIn.Int(row["ContactSystem"].ToString());
				fHIRContactPoint.ContactValue       = PIn.String(row["ContactValue"].ToString());
				fHIRContactPoint.ContactUse         = (OpenDentBusiness.ContactPointUse)PIn.Int(row["ContactUse"].ToString());
				fHIRContactPoint.ItemOrder          = PIn.Int   (row["ItemOrder"].ToString());
				fHIRContactPoint.DateStart          = PIn.Date  (row["DateStart"].ToString());
				fHIRContactPoint.DateEnd            = PIn.Date  (row["DateEnd"].ToString());
				retVal.Add(fHIRContactPoint);
			}
			return retVal;
		}

		///<summary>Converts a list of FHIRContactPoint into a DataTable.</summary>
		public static DataTable ListToTable(List<FHIRContactPoint> listFHIRContactPoints,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="FHIRContactPoint";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("FHIRContactPointNum");
			table.Columns.Add("FHIRSubscriptionNum");
			table.Columns.Add("ContactSystem");
			table.Columns.Add("ContactValue");
			table.Columns.Add("ContactUse");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("DateStart");
			table.Columns.Add("DateEnd");
			foreach(FHIRContactPoint fHIRContactPoint in listFHIRContactPoints) {
				table.Rows.Add(new object[] {
					POut.Long  (fHIRContactPoint.FHIRContactPointNum),
					POut.Long  (fHIRContactPoint.FHIRSubscriptionNum),
					POut.Int   ((int)fHIRContactPoint.ContactSystem),
					            fHIRContactPoint.ContactValue,
					POut.Int   ((int)fHIRContactPoint.ContactUse),
					POut.Int   (fHIRContactPoint.ItemOrder),
					POut.DateT (fHIRContactPoint.DateStart,false),
					POut.DateT (fHIRContactPoint.DateEnd,false),
				});
			}
			return table;
		}

		///<summary>Inserts one FHIRContactPoint into the database.  Returns the new priKey.</summary>
		public static long Insert(FHIRContactPoint fHIRContactPoint) {
			return Insert(fHIRContactPoint,false);
		}

		///<summary>Inserts one FHIRContactPoint into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(FHIRContactPoint fHIRContactPoint,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				fHIRContactPoint.FHIRContactPointNum=ReplicationServers.GetKey("fhircontactpoint","FHIRContactPointNum");
			}
			string command="INSERT INTO fhircontactpoint (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="FHIRContactPointNum,";
			}
			command+="FHIRSubscriptionNum,ContactSystem,ContactValue,ContactUse,ItemOrder,DateStart,DateEnd) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(fHIRContactPoint.FHIRContactPointNum)+",";
			}
			command+=
				     POut.Long  (fHIRContactPoint.FHIRSubscriptionNum)+","
				+    POut.Int   ((int)fHIRContactPoint.ContactSystem)+","
				+"'"+POut.String(fHIRContactPoint.ContactValue)+"',"
				+    POut.Int   ((int)fHIRContactPoint.ContactUse)+","
				+    POut.Int   (fHIRContactPoint.ItemOrder)+","
				+    POut.Date  (fHIRContactPoint.DateStart)+","
				+    POut.Date  (fHIRContactPoint.DateEnd)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				fHIRContactPoint.FHIRContactPointNum=Db.NonQ(command,true,"FHIRContactPointNum","fHIRContactPoint");
			}
			return fHIRContactPoint.FHIRContactPointNum;
		}

		///<summary>Inserts one FHIRContactPoint into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FHIRContactPoint fHIRContactPoint) {
			return InsertNoCache(fHIRContactPoint,false);
		}

		///<summary>Inserts one FHIRContactPoint into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(FHIRContactPoint fHIRContactPoint,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO fhircontactpoint (";
			if(!useExistingPK && isRandomKeys) {
				fHIRContactPoint.FHIRContactPointNum=ReplicationServers.GetKeyNoCache("fhircontactpoint","FHIRContactPointNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="FHIRContactPointNum,";
			}
			command+="FHIRSubscriptionNum,ContactSystem,ContactValue,ContactUse,ItemOrder,DateStart,DateEnd) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(fHIRContactPoint.FHIRContactPointNum)+",";
			}
			command+=
				     POut.Long  (fHIRContactPoint.FHIRSubscriptionNum)+","
				+    POut.Int   ((int)fHIRContactPoint.ContactSystem)+","
				+"'"+POut.String(fHIRContactPoint.ContactValue)+"',"
				+    POut.Int   ((int)fHIRContactPoint.ContactUse)+","
				+    POut.Int   (fHIRContactPoint.ItemOrder)+","
				+    POut.Date  (fHIRContactPoint.DateStart)+","
				+    POut.Date  (fHIRContactPoint.DateEnd)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				fHIRContactPoint.FHIRContactPointNum=Db.NonQ(command,true,"FHIRContactPointNum","fHIRContactPoint");
			}
			return fHIRContactPoint.FHIRContactPointNum;
		}

		///<summary>Updates one FHIRContactPoint in the database.</summary>
		public static void Update(FHIRContactPoint fHIRContactPoint) {
			string command="UPDATE fhircontactpoint SET "
				+"FHIRSubscriptionNum=  "+POut.Long  (fHIRContactPoint.FHIRSubscriptionNum)+", "
				+"ContactSystem      =  "+POut.Int   ((int)fHIRContactPoint.ContactSystem)+", "
				+"ContactValue       = '"+POut.String(fHIRContactPoint.ContactValue)+"', "
				+"ContactUse         =  "+POut.Int   ((int)fHIRContactPoint.ContactUse)+", "
				+"ItemOrder          =  "+POut.Int   (fHIRContactPoint.ItemOrder)+", "
				+"DateStart          =  "+POut.Date  (fHIRContactPoint.DateStart)+", "
				+"DateEnd            =  "+POut.Date  (fHIRContactPoint.DateEnd)+" "
				+"WHERE FHIRContactPointNum = "+POut.Long(fHIRContactPoint.FHIRContactPointNum);
			Db.NonQ(command);
		}

		///<summary>Updates one FHIRContactPoint in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(FHIRContactPoint fHIRContactPoint,FHIRContactPoint oldFHIRContactPoint) {
			string command="";
			if(fHIRContactPoint.FHIRSubscriptionNum != oldFHIRContactPoint.FHIRSubscriptionNum) {
				if(command!="") { command+=",";}
				command+="FHIRSubscriptionNum = "+POut.Long(fHIRContactPoint.FHIRSubscriptionNum)+"";
			}
			if(fHIRContactPoint.ContactSystem != oldFHIRContactPoint.ContactSystem) {
				if(command!="") { command+=",";}
				command+="ContactSystem = "+POut.Int   ((int)fHIRContactPoint.ContactSystem)+"";
			}
			if(fHIRContactPoint.ContactValue != oldFHIRContactPoint.ContactValue) {
				if(command!="") { command+=",";}
				command+="ContactValue = '"+POut.String(fHIRContactPoint.ContactValue)+"'";
			}
			if(fHIRContactPoint.ContactUse != oldFHIRContactPoint.ContactUse) {
				if(command!="") { command+=",";}
				command+="ContactUse = "+POut.Int   ((int)fHIRContactPoint.ContactUse)+"";
			}
			if(fHIRContactPoint.ItemOrder != oldFHIRContactPoint.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(fHIRContactPoint.ItemOrder)+"";
			}
			if(fHIRContactPoint.DateStart.Date != oldFHIRContactPoint.DateStart.Date) {
				if(command!="") { command+=",";}
				command+="DateStart = "+POut.Date(fHIRContactPoint.DateStart)+"";
			}
			if(fHIRContactPoint.DateEnd.Date != oldFHIRContactPoint.DateEnd.Date) {
				if(command!="") { command+=",";}
				command+="DateEnd = "+POut.Date(fHIRContactPoint.DateEnd)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE fhircontactpoint SET "+command
				+" WHERE FHIRContactPointNum = "+POut.Long(fHIRContactPoint.FHIRContactPointNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(FHIRContactPoint,FHIRContactPoint) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(FHIRContactPoint fHIRContactPoint,FHIRContactPoint oldFHIRContactPoint) {
			if(fHIRContactPoint.FHIRSubscriptionNum != oldFHIRContactPoint.FHIRSubscriptionNum) {
				return true;
			}
			if(fHIRContactPoint.ContactSystem != oldFHIRContactPoint.ContactSystem) {
				return true;
			}
			if(fHIRContactPoint.ContactValue != oldFHIRContactPoint.ContactValue) {
				return true;
			}
			if(fHIRContactPoint.ContactUse != oldFHIRContactPoint.ContactUse) {
				return true;
			}
			if(fHIRContactPoint.ItemOrder != oldFHIRContactPoint.ItemOrder) {
				return true;
			}
			if(fHIRContactPoint.DateStart.Date != oldFHIRContactPoint.DateStart.Date) {
				return true;
			}
			if(fHIRContactPoint.DateEnd.Date != oldFHIRContactPoint.DateEnd.Date) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one FHIRContactPoint from the database.</summary>
		public static void Delete(long fHIRContactPointNum) {
			string command="DELETE FROM fhircontactpoint "
				+"WHERE FHIRContactPointNum = "+POut.Long(fHIRContactPointNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many FHIRContactPoints from the database.</summary>
		public static void DeleteMany(List<long> listFHIRContactPointNums) {
			if(listFHIRContactPointNums==null || listFHIRContactPointNums.Count==0) {
				return;
			}
			string command="DELETE FROM fhircontactpoint "
				+"WHERE FHIRContactPointNum IN("+string.Join(",",listFHIRContactPointNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}