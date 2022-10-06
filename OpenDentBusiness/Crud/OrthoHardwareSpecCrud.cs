//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class OrthoHardwareSpecCrud {
		///<summary>Gets one OrthoHardwareSpec object from the database using the primary key.  Returns null if not found.</summary>
		public static OrthoHardwareSpec SelectOne(long orthoHardwareSpecNum) {
			string command="SELECT * FROM orthohardwarespec "
				+"WHERE OrthoHardwareSpecNum = "+POut.Long(orthoHardwareSpecNum);
			List<OrthoHardwareSpec> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OrthoHardwareSpec object from the database using a query.</summary>
		public static OrthoHardwareSpec SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<OrthoHardwareSpec> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OrthoHardwareSpec objects from the database using a query.</summary>
		public static List<OrthoHardwareSpec> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<OrthoHardwareSpec> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OrthoHardwareSpec> TableToList(DataTable table) {
			List<OrthoHardwareSpec> retVal=new List<OrthoHardwareSpec>();
			OrthoHardwareSpec orthoHardwareSpec;
			foreach(DataRow row in table.Rows) {
				orthoHardwareSpec=new OrthoHardwareSpec();
				orthoHardwareSpec.OrthoHardwareSpecNum= PIn.Long  (row["OrthoHardwareSpecNum"].ToString());
				orthoHardwareSpec.OrthoHardwareType   = (OpenDentBusiness.EnumOrthoHardwareType)PIn.Int(row["OrthoHardwareType"].ToString());
				orthoHardwareSpec.Description         = PIn.String(row["Description"].ToString());
				orthoHardwareSpec.ItemColor           = Color.FromArgb(PIn.Int(row["ItemColor"].ToString()));
				orthoHardwareSpec.IsHidden            = PIn.Bool  (row["IsHidden"].ToString());
				orthoHardwareSpec.ItemOrder           = PIn.Int   (row["ItemOrder"].ToString());
				retVal.Add(orthoHardwareSpec);
			}
			return retVal;
		}

		///<summary>Converts a list of OrthoHardwareSpec into a DataTable.</summary>
		public static DataTable ListToTable(List<OrthoHardwareSpec> listOrthoHardwareSpecs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OrthoHardwareSpec";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OrthoHardwareSpecNum");
			table.Columns.Add("OrthoHardwareType");
			table.Columns.Add("Description");
			table.Columns.Add("ItemColor");
			table.Columns.Add("IsHidden");
			table.Columns.Add("ItemOrder");
			foreach(OrthoHardwareSpec orthoHardwareSpec in listOrthoHardwareSpecs) {
				table.Rows.Add(new object[] {
					POut.Long  (orthoHardwareSpec.OrthoHardwareSpecNum),
					POut.Int   ((int)orthoHardwareSpec.OrthoHardwareType),
					            orthoHardwareSpec.Description,
					POut.Int   (orthoHardwareSpec.ItemColor.ToArgb()),
					POut.Bool  (orthoHardwareSpec.IsHidden),
					POut.Int   (orthoHardwareSpec.ItemOrder),
				});
			}
			return table;
		}

		///<summary>Inserts one OrthoHardwareSpec into the database.  Returns the new priKey.</summary>
		public static long Insert(OrthoHardwareSpec orthoHardwareSpec) {
			return Insert(orthoHardwareSpec,false);
		}

		///<summary>Inserts one OrthoHardwareSpec into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OrthoHardwareSpec orthoHardwareSpec,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				orthoHardwareSpec.OrthoHardwareSpecNum=ReplicationServers.GetKey("orthohardwarespec","OrthoHardwareSpecNum");
			}
			string command="INSERT INTO orthohardwarespec (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OrthoHardwareSpecNum,";
			}
			command+="OrthoHardwareType,Description,ItemColor,IsHidden,ItemOrder) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(orthoHardwareSpec.OrthoHardwareSpecNum)+",";
			}
			command+=
				     POut.Int   ((int)orthoHardwareSpec.OrthoHardwareType)+","
				+"'"+POut.String(orthoHardwareSpec.Description)+"',"
				+    POut.Int   (orthoHardwareSpec.ItemColor.ToArgb())+","
				+    POut.Bool  (orthoHardwareSpec.IsHidden)+","
				+    POut.Int   (orthoHardwareSpec.ItemOrder)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoHardwareSpec.OrthoHardwareSpecNum=Db.NonQ(command,true,"OrthoHardwareSpecNum","orthoHardwareSpec");
			}
			return orthoHardwareSpec.OrthoHardwareSpecNum;
		}

		///<summary>Inserts one OrthoHardwareSpec into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoHardwareSpec orthoHardwareSpec) {
			return InsertNoCache(orthoHardwareSpec,false);
		}

		///<summary>Inserts one OrthoHardwareSpec into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoHardwareSpec orthoHardwareSpec,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO orthohardwarespec (";
			if(!useExistingPK && isRandomKeys) {
				orthoHardwareSpec.OrthoHardwareSpecNum=ReplicationServers.GetKeyNoCache("orthohardwarespec","OrthoHardwareSpecNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="OrthoHardwareSpecNum,";
			}
			command+="OrthoHardwareType,Description,ItemColor,IsHidden,ItemOrder) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(orthoHardwareSpec.OrthoHardwareSpecNum)+",";
			}
			command+=
				     POut.Int   ((int)orthoHardwareSpec.OrthoHardwareType)+","
				+"'"+POut.String(orthoHardwareSpec.Description)+"',"
				+    POut.Int   (orthoHardwareSpec.ItemColor.ToArgb())+","
				+    POut.Bool  (orthoHardwareSpec.IsHidden)+","
				+    POut.Int   (orthoHardwareSpec.ItemOrder)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoHardwareSpec.OrthoHardwareSpecNum=Db.NonQ(command,true,"OrthoHardwareSpecNum","orthoHardwareSpec");
			}
			return orthoHardwareSpec.OrthoHardwareSpecNum;
		}

		///<summary>Updates one OrthoHardwareSpec in the database.</summary>
		public static void Update(OrthoHardwareSpec orthoHardwareSpec) {
			string command="UPDATE orthohardwarespec SET "
				+"OrthoHardwareType   =  "+POut.Int   ((int)orthoHardwareSpec.OrthoHardwareType)+", "
				+"Description         = '"+POut.String(orthoHardwareSpec.Description)+"', "
				+"ItemColor           =  "+POut.Int   (orthoHardwareSpec.ItemColor.ToArgb())+", "
				+"IsHidden            =  "+POut.Bool  (orthoHardwareSpec.IsHidden)+", "
				+"ItemOrder           =  "+POut.Int   (orthoHardwareSpec.ItemOrder)+" "
				+"WHERE OrthoHardwareSpecNum = "+POut.Long(orthoHardwareSpec.OrthoHardwareSpecNum);
			Db.NonQ(command);
		}

		///<summary>Updates one OrthoHardwareSpec in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OrthoHardwareSpec orthoHardwareSpec,OrthoHardwareSpec oldOrthoHardwareSpec) {
			string command="";
			if(orthoHardwareSpec.OrthoHardwareType != oldOrthoHardwareSpec.OrthoHardwareType) {
				if(command!="") { command+=",";}
				command+="OrthoHardwareType = "+POut.Int   ((int)orthoHardwareSpec.OrthoHardwareType)+"";
			}
			if(orthoHardwareSpec.Description != oldOrthoHardwareSpec.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(orthoHardwareSpec.Description)+"'";
			}
			if(orthoHardwareSpec.ItemColor != oldOrthoHardwareSpec.ItemColor) {
				if(command!="") { command+=",";}
				command+="ItemColor = "+POut.Int(orthoHardwareSpec.ItemColor.ToArgb())+"";
			}
			if(orthoHardwareSpec.IsHidden != oldOrthoHardwareSpec.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(orthoHardwareSpec.IsHidden)+"";
			}
			if(orthoHardwareSpec.ItemOrder != oldOrthoHardwareSpec.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(orthoHardwareSpec.ItemOrder)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE orthohardwarespec SET "+command
				+" WHERE OrthoHardwareSpecNum = "+POut.Long(orthoHardwareSpec.OrthoHardwareSpecNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(OrthoHardwareSpec,OrthoHardwareSpec) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OrthoHardwareSpec orthoHardwareSpec,OrthoHardwareSpec oldOrthoHardwareSpec) {
			if(orthoHardwareSpec.OrthoHardwareType != oldOrthoHardwareSpec.OrthoHardwareType) {
				return true;
			}
			if(orthoHardwareSpec.Description != oldOrthoHardwareSpec.Description) {
				return true;
			}
			if(orthoHardwareSpec.ItemColor != oldOrthoHardwareSpec.ItemColor) {
				return true;
			}
			if(orthoHardwareSpec.IsHidden != oldOrthoHardwareSpec.IsHidden) {
				return true;
			}
			if(orthoHardwareSpec.ItemOrder != oldOrthoHardwareSpec.ItemOrder) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one OrthoHardwareSpec from the database.</summary>
		public static void Delete(long orthoHardwareSpecNum) {
			string command="DELETE FROM orthohardwarespec "
				+"WHERE OrthoHardwareSpecNum = "+POut.Long(orthoHardwareSpecNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many OrthoHardwareSpecs from the database.</summary>
		public static void DeleteMany(List<long> listOrthoHardwareSpecNums) {
			if(listOrthoHardwareSpecNums==null || listOrthoHardwareSpecNums.Count==0) {
				return;
			}
			string command="DELETE FROM orthohardwarespec "
				+"WHERE OrthoHardwareSpecNum IN("+string.Join(",",listOrthoHardwareSpecNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}