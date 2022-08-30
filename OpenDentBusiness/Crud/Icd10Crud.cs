//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class Icd10Crud {
		///<summary>Gets one Icd10 object from the database using the primary key.  Returns null if not found.</summary>
		public static Icd10 SelectOne(long icd10Num) {
			string command="SELECT * FROM icd10 "
				+"WHERE Icd10Num = "+POut.Long(icd10Num);
			List<Icd10> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Icd10 object from the database using a query.</summary>
		public static Icd10 SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Icd10> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Icd10 objects from the database using a query.</summary>
		public static List<Icd10> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Icd10> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Icd10> TableToList(DataTable table) {
			List<Icd10> retVal=new List<Icd10>();
			Icd10 icd10;
			foreach(DataRow row in table.Rows) {
				icd10=new Icd10();
				icd10.Icd10Num   = PIn.Long  (row["Icd10Num"].ToString());
				icd10.Icd10Code  = PIn.String(row["Icd10Code"].ToString());
				icd10.Description= PIn.String(row["Description"].ToString());
				icd10.IsCode     = PIn.String(row["IsCode"].ToString());
				retVal.Add(icd10);
			}
			return retVal;
		}

		///<summary>Converts a list of Icd10 into a DataTable.</summary>
		public static DataTable ListToTable(List<Icd10> listIcd10s,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Icd10";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("Icd10Num");
			table.Columns.Add("Icd10Code");
			table.Columns.Add("Description");
			table.Columns.Add("IsCode");
			foreach(Icd10 icd10 in listIcd10s) {
				table.Rows.Add(new object[] {
					POut.Long  (icd10.Icd10Num),
					            icd10.Icd10Code,
					            icd10.Description,
					            icd10.IsCode,
				});
			}
			return table;
		}

		///<summary>Inserts one Icd10 into the database.  Returns the new priKey.</summary>
		public static long Insert(Icd10 icd10) {
			return Insert(icd10,false);
		}

		///<summary>Inserts one Icd10 into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Icd10 icd10,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				icd10.Icd10Num=ReplicationServers.GetKey("icd10","Icd10Num");
			}
			string command="INSERT INTO icd10 (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="Icd10Num,";
			}
			command+="Icd10Code,Description,IsCode) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(icd10.Icd10Num)+",";
			}
			command+=
				 "'"+POut.String(icd10.Icd10Code)+"',"
				+"'"+POut.String(icd10.Description)+"',"
				+"'"+POut.String(icd10.IsCode)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				icd10.Icd10Num=Db.NonQ(command,true,"Icd10Num","icd10");
			}
			return icd10.Icd10Num;
		}

		///<summary>Inserts one Icd10 into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Icd10 icd10) {
			return InsertNoCache(icd10,false);
		}

		///<summary>Inserts one Icd10 into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Icd10 icd10,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO icd10 (";
			if(!useExistingPK && isRandomKeys) {
				icd10.Icd10Num=ReplicationServers.GetKeyNoCache("icd10","Icd10Num");
			}
			if(isRandomKeys || useExistingPK) {
				command+="Icd10Num,";
			}
			command+="Icd10Code,Description,IsCode) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(icd10.Icd10Num)+",";
			}
			command+=
				 "'"+POut.String(icd10.Icd10Code)+"',"
				+"'"+POut.String(icd10.Description)+"',"
				+"'"+POut.String(icd10.IsCode)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				icd10.Icd10Num=Db.NonQ(command,true,"Icd10Num","icd10");
			}
			return icd10.Icd10Num;
		}

		///<summary>Updates one Icd10 in the database.</summary>
		public static void Update(Icd10 icd10) {
			string command="UPDATE icd10 SET "
				+"Icd10Code  = '"+POut.String(icd10.Icd10Code)+"', "
				+"Description= '"+POut.String(icd10.Description)+"', "
				+"IsCode     = '"+POut.String(icd10.IsCode)+"' "
				+"WHERE Icd10Num = "+POut.Long(icd10.Icd10Num);
			Db.NonQ(command);
		}

		///<summary>Updates one Icd10 in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Icd10 icd10,Icd10 oldIcd10) {
			string command="";
			if(icd10.Icd10Code != oldIcd10.Icd10Code) {
				if(command!="") { command+=",";}
				command+="Icd10Code = '"+POut.String(icd10.Icd10Code)+"'";
			}
			if(icd10.Description != oldIcd10.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(icd10.Description)+"'";
			}
			if(icd10.IsCode != oldIcd10.IsCode) {
				if(command!="") { command+=",";}
				command+="IsCode = '"+POut.String(icd10.IsCode)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE icd10 SET "+command
				+" WHERE Icd10Num = "+POut.Long(icd10.Icd10Num);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Icd10,Icd10) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Icd10 icd10,Icd10 oldIcd10) {
			if(icd10.Icd10Code != oldIcd10.Icd10Code) {
				return true;
			}
			if(icd10.Description != oldIcd10.Description) {
				return true;
			}
			if(icd10.IsCode != oldIcd10.IsCode) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Icd10 from the database.</summary>
		public static void Delete(long icd10Num) {
			string command="DELETE FROM icd10 "
				+"WHERE Icd10Num = "+POut.Long(icd10Num);
			Db.NonQ(command);
		}

		///<summary>Deletes many Icd10s from the database.</summary>
		public static void DeleteMany(List<long> listIcd10Nums) {
			if(listIcd10Nums==null || listIcd10Nums.Count==0) {
				return;
			}
			string command="DELETE FROM icd10 "
				+"WHERE Icd10Num IN("+string.Join(",",listIcd10Nums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}