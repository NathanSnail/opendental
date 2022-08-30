//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class SigElementDefCrud {
		///<summary>Gets one SigElementDef object from the database using the primary key.  Returns null if not found.</summary>
		public static SigElementDef SelectOne(long sigElementDefNum) {
			string command="SELECT * FROM sigelementdef "
				+"WHERE SigElementDefNum = "+POut.Long(sigElementDefNum);
			List<SigElementDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one SigElementDef object from the database using a query.</summary>
		public static SigElementDef SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SigElementDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of SigElementDef objects from the database using a query.</summary>
		public static List<SigElementDef> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<SigElementDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<SigElementDef> TableToList(DataTable table) {
			List<SigElementDef> retVal=new List<SigElementDef>();
			SigElementDef sigElementDef;
			foreach(DataRow row in table.Rows) {
				sigElementDef=new SigElementDef();
				sigElementDef.SigElementDefNum= PIn.Long  (row["SigElementDefNum"].ToString());
				sigElementDef.LightRow        = PIn.Byte  (row["LightRow"].ToString());
				sigElementDef.LightColor      = Color.FromArgb(PIn.Int(row["LightColor"].ToString()));
				sigElementDef.SigElementType  = (OpenDentBusiness.SignalElementType)PIn.Int(row["SigElementType"].ToString());
				sigElementDef.SigText         = PIn.String(row["SigText"].ToString());
				sigElementDef.Sound           = PIn.String(row["Sound"].ToString());
				sigElementDef.ItemOrder       = PIn.Int   (row["ItemOrder"].ToString());
				retVal.Add(sigElementDef);
			}
			return retVal;
		}

		///<summary>Converts a list of SigElementDef into a DataTable.</summary>
		public static DataTable ListToTable(List<SigElementDef> listSigElementDefs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="SigElementDef";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SigElementDefNum");
			table.Columns.Add("LightRow");
			table.Columns.Add("LightColor");
			table.Columns.Add("SigElementType");
			table.Columns.Add("SigText");
			table.Columns.Add("Sound");
			table.Columns.Add("ItemOrder");
			foreach(SigElementDef sigElementDef in listSigElementDefs) {
				table.Rows.Add(new object[] {
					POut.Long  (sigElementDef.SigElementDefNum),
					POut.Byte  (sigElementDef.LightRow),
					POut.Int   (sigElementDef.LightColor.ToArgb()),
					POut.Int   ((int)sigElementDef.SigElementType),
					            sigElementDef.SigText,
					            sigElementDef.Sound,
					POut.Int   (sigElementDef.ItemOrder),
				});
			}
			return table;
		}

		///<summary>Inserts one SigElementDef into the database.  Returns the new priKey.</summary>
		public static long Insert(SigElementDef sigElementDef) {
			return Insert(sigElementDef,false);
		}

		///<summary>Inserts one SigElementDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(SigElementDef sigElementDef,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				sigElementDef.SigElementDefNum=ReplicationServers.GetKey("sigelementdef","SigElementDefNum");
			}
			string command="INSERT INTO sigelementdef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="SigElementDefNum,";
			}
			command+="LightRow,LightColor,SigElementType,SigText,Sound,ItemOrder) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(sigElementDef.SigElementDefNum)+",";
			}
			command+=
				     POut.Byte  (sigElementDef.LightRow)+","
				+    POut.Int   (sigElementDef.LightColor.ToArgb())+","
				+    POut.Int   ((int)sigElementDef.SigElementType)+","
				+"'"+POut.String(sigElementDef.SigText)+"',"
				+    DbHelper.ParamChar+"paramSound,"
				+    POut.Int   (sigElementDef.ItemOrder)+")";
			if(sigElementDef.Sound==null) {
				sigElementDef.Sound="";
			}
			OdSqlParameter paramSound=new OdSqlParameter("paramSound",OdDbType.Text,POut.StringParam(sigElementDef.Sound));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramSound);
			}
			else {
				sigElementDef.SigElementDefNum=Db.NonQ(command,true,"SigElementDefNum","sigElementDef",paramSound);
			}
			return sigElementDef.SigElementDefNum;
		}

		///<summary>Inserts one SigElementDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SigElementDef sigElementDef) {
			return InsertNoCache(sigElementDef,false);
		}

		///<summary>Inserts one SigElementDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(SigElementDef sigElementDef,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO sigelementdef (";
			if(!useExistingPK && isRandomKeys) {
				sigElementDef.SigElementDefNum=ReplicationServers.GetKeyNoCache("sigelementdef","SigElementDefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="SigElementDefNum,";
			}
			command+="LightRow,LightColor,SigElementType,SigText,Sound,ItemOrder) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(sigElementDef.SigElementDefNum)+",";
			}
			command+=
				     POut.Byte  (sigElementDef.LightRow)+","
				+    POut.Int   (sigElementDef.LightColor.ToArgb())+","
				+    POut.Int   ((int)sigElementDef.SigElementType)+","
				+"'"+POut.String(sigElementDef.SigText)+"',"
				+    DbHelper.ParamChar+"paramSound,"
				+    POut.Int   (sigElementDef.ItemOrder)+")";
			if(sigElementDef.Sound==null) {
				sigElementDef.Sound="";
			}
			OdSqlParameter paramSound=new OdSqlParameter("paramSound",OdDbType.Text,POut.StringParam(sigElementDef.Sound));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramSound);
			}
			else {
				sigElementDef.SigElementDefNum=Db.NonQ(command,true,"SigElementDefNum","sigElementDef",paramSound);
			}
			return sigElementDef.SigElementDefNum;
		}

		///<summary>Updates one SigElementDef in the database.</summary>
		public static void Update(SigElementDef sigElementDef) {
			string command="UPDATE sigelementdef SET "
				+"LightRow        =  "+POut.Byte  (sigElementDef.LightRow)+", "
				+"LightColor      =  "+POut.Int   (sigElementDef.LightColor.ToArgb())+", "
				+"SigElementType  =  "+POut.Int   ((int)sigElementDef.SigElementType)+", "
				+"SigText         = '"+POut.String(sigElementDef.SigText)+"', "
				+"Sound           =  "+DbHelper.ParamChar+"paramSound, "
				+"ItemOrder       =  "+POut.Int   (sigElementDef.ItemOrder)+" "
				+"WHERE SigElementDefNum = "+POut.Long(sigElementDef.SigElementDefNum);
			if(sigElementDef.Sound==null) {
				sigElementDef.Sound="";
			}
			OdSqlParameter paramSound=new OdSqlParameter("paramSound",OdDbType.Text,POut.StringParam(sigElementDef.Sound));
			Db.NonQ(command,paramSound);
		}

		///<summary>Updates one SigElementDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(SigElementDef sigElementDef,SigElementDef oldSigElementDef) {
			string command="";
			if(sigElementDef.LightRow != oldSigElementDef.LightRow) {
				if(command!="") { command+=",";}
				command+="LightRow = "+POut.Byte(sigElementDef.LightRow)+"";
			}
			if(sigElementDef.LightColor != oldSigElementDef.LightColor) {
				if(command!="") { command+=",";}
				command+="LightColor = "+POut.Int(sigElementDef.LightColor.ToArgb())+"";
			}
			if(sigElementDef.SigElementType != oldSigElementDef.SigElementType) {
				if(command!="") { command+=",";}
				command+="SigElementType = "+POut.Int   ((int)sigElementDef.SigElementType)+"";
			}
			if(sigElementDef.SigText != oldSigElementDef.SigText) {
				if(command!="") { command+=",";}
				command+="SigText = '"+POut.String(sigElementDef.SigText)+"'";
			}
			if(sigElementDef.Sound != oldSigElementDef.Sound) {
				if(command!="") { command+=",";}
				command+="Sound = "+DbHelper.ParamChar+"paramSound";
			}
			if(sigElementDef.ItemOrder != oldSigElementDef.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(sigElementDef.ItemOrder)+"";
			}
			if(command=="") {
				return false;
			}
			if(sigElementDef.Sound==null) {
				sigElementDef.Sound="";
			}
			OdSqlParameter paramSound=new OdSqlParameter("paramSound",OdDbType.Text,POut.StringParam(sigElementDef.Sound));
			command="UPDATE sigelementdef SET "+command
				+" WHERE SigElementDefNum = "+POut.Long(sigElementDef.SigElementDefNum);
			Db.NonQ(command,paramSound);
			return true;
		}

		///<summary>Returns true if Update(SigElementDef,SigElementDef) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(SigElementDef sigElementDef,SigElementDef oldSigElementDef) {
			if(sigElementDef.LightRow != oldSigElementDef.LightRow) {
				return true;
			}
			if(sigElementDef.LightColor != oldSigElementDef.LightColor) {
				return true;
			}
			if(sigElementDef.SigElementType != oldSigElementDef.SigElementType) {
				return true;
			}
			if(sigElementDef.SigText != oldSigElementDef.SigText) {
				return true;
			}
			if(sigElementDef.Sound != oldSigElementDef.Sound) {
				return true;
			}
			if(sigElementDef.ItemOrder != oldSigElementDef.ItemOrder) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one SigElementDef from the database.</summary>
		public static void Delete(long sigElementDefNum) {
			string command="DELETE FROM sigelementdef "
				+"WHERE SigElementDefNum = "+POut.Long(sigElementDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many SigElementDefs from the database.</summary>
		public static void DeleteMany(List<long> listSigElementDefNums) {
			if(listSigElementDefNums==null || listSigElementDefNums.Count==0) {
				return;
			}
			string command="DELETE FROM sigelementdef "
				+"WHERE SigElementDefNum IN("+string.Join(",",listSigElementDefNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}