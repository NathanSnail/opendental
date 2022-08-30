//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class CloudAddressCrud {
		///<summary>Gets one CloudAddress object from the database using the primary key.  Returns null if not found.</summary>
		public static CloudAddress SelectOne(long cloudAddressNum) {
			string command="SELECT * FROM cloudaddress "
				+"WHERE CloudAddressNum = "+POut.Long(cloudAddressNum);
			List<CloudAddress> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CloudAddress object from the database using a query.</summary>
		public static CloudAddress SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CloudAddress> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CloudAddress objects from the database using a query.</summary>
		public static List<CloudAddress> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CloudAddress> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<CloudAddress> TableToList(DataTable table) {
			List<CloudAddress> retVal=new List<CloudAddress>();
			CloudAddress cloudAddress;
			foreach(DataRow row in table.Rows) {
				cloudAddress=new CloudAddress();
				cloudAddress.CloudAddressNum    = PIn.Long  (row["CloudAddressNum"].ToString());
				cloudAddress.IpAddress          = PIn.String(row["IpAddress"].ToString());
				cloudAddress.UserNumLastConnect = PIn.Long  (row["UserNumLastConnect"].ToString());
				cloudAddress.DateTimeLastConnect= PIn.DateT (row["DateTimeLastConnect"].ToString());
				retVal.Add(cloudAddress);
			}
			return retVal;
		}

		///<summary>Converts a list of CloudAddress into a DataTable.</summary>
		public static DataTable ListToTable(List<CloudAddress> listCloudAddresss,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="CloudAddress";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("CloudAddressNum");
			table.Columns.Add("IpAddress");
			table.Columns.Add("UserNumLastConnect");
			table.Columns.Add("DateTimeLastConnect");
			foreach(CloudAddress cloudAddress in listCloudAddresss) {
				table.Rows.Add(new object[] {
					POut.Long  (cloudAddress.CloudAddressNum),
					            cloudAddress.IpAddress,
					POut.Long  (cloudAddress.UserNumLastConnect),
					POut.DateT (cloudAddress.DateTimeLastConnect,false),
				});
			}
			return table;
		}

		///<summary>Inserts one CloudAddress into the database.  Returns the new priKey.</summary>
		public static long Insert(CloudAddress cloudAddress) {
			return Insert(cloudAddress,false);
		}

		///<summary>Inserts one CloudAddress into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(CloudAddress cloudAddress,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				cloudAddress.CloudAddressNum=ReplicationServers.GetKey("cloudaddress","CloudAddressNum");
			}
			string command="INSERT INTO cloudaddress (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CloudAddressNum,";
			}
			command+="IpAddress,UserNumLastConnect,DateTimeLastConnect) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(cloudAddress.CloudAddressNum)+",";
			}
			command+=
				 "'"+POut.String(cloudAddress.IpAddress)+"',"
				+    POut.Long  (cloudAddress.UserNumLastConnect)+","
				+    POut.DateT (cloudAddress.DateTimeLastConnect)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				cloudAddress.CloudAddressNum=Db.NonQ(command,true,"CloudAddressNum","cloudAddress");
			}
			return cloudAddress.CloudAddressNum;
		}

		///<summary>Inserts one CloudAddress into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CloudAddress cloudAddress) {
			return InsertNoCache(cloudAddress,false);
		}

		///<summary>Inserts one CloudAddress into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CloudAddress cloudAddress,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO cloudaddress (";
			if(!useExistingPK && isRandomKeys) {
				cloudAddress.CloudAddressNum=ReplicationServers.GetKeyNoCache("cloudaddress","CloudAddressNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CloudAddressNum,";
			}
			command+="IpAddress,UserNumLastConnect,DateTimeLastConnect) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(cloudAddress.CloudAddressNum)+",";
			}
			command+=
				 "'"+POut.String(cloudAddress.IpAddress)+"',"
				+    POut.Long  (cloudAddress.UserNumLastConnect)+","
				+    POut.DateT (cloudAddress.DateTimeLastConnect)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				cloudAddress.CloudAddressNum=Db.NonQ(command,true,"CloudAddressNum","cloudAddress");
			}
			return cloudAddress.CloudAddressNum;
		}

		///<summary>Updates one CloudAddress in the database.</summary>
		public static void Update(CloudAddress cloudAddress) {
			string command="UPDATE cloudaddress SET "
				+"IpAddress          = '"+POut.String(cloudAddress.IpAddress)+"', "
				+"UserNumLastConnect =  "+POut.Long  (cloudAddress.UserNumLastConnect)+", "
				+"DateTimeLastConnect=  "+POut.DateT (cloudAddress.DateTimeLastConnect)+" "
				+"WHERE CloudAddressNum = "+POut.Long(cloudAddress.CloudAddressNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CloudAddress in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(CloudAddress cloudAddress,CloudAddress oldCloudAddress) {
			string command="";
			if(cloudAddress.IpAddress != oldCloudAddress.IpAddress) {
				if(command!="") { command+=",";}
				command+="IpAddress = '"+POut.String(cloudAddress.IpAddress)+"'";
			}
			if(cloudAddress.UserNumLastConnect != oldCloudAddress.UserNumLastConnect) {
				if(command!="") { command+=",";}
				command+="UserNumLastConnect = "+POut.Long(cloudAddress.UserNumLastConnect)+"";
			}
			if(cloudAddress.DateTimeLastConnect != oldCloudAddress.DateTimeLastConnect) {
				if(command!="") { command+=",";}
				command+="DateTimeLastConnect = "+POut.DateT(cloudAddress.DateTimeLastConnect)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE cloudaddress SET "+command
				+" WHERE CloudAddressNum = "+POut.Long(cloudAddress.CloudAddressNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(CloudAddress,CloudAddress) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(CloudAddress cloudAddress,CloudAddress oldCloudAddress) {
			if(cloudAddress.IpAddress != oldCloudAddress.IpAddress) {
				return true;
			}
			if(cloudAddress.UserNumLastConnect != oldCloudAddress.UserNumLastConnect) {
				return true;
			}
			if(cloudAddress.DateTimeLastConnect != oldCloudAddress.DateTimeLastConnect) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one CloudAddress from the database.</summary>
		public static void Delete(long cloudAddressNum) {
			string command="DELETE FROM cloudaddress "
				+"WHERE CloudAddressNum = "+POut.Long(cloudAddressNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many CloudAddresss from the database.</summary>
		public static void DeleteMany(List<long> listCloudAddressNums) {
			if(listCloudAddressNums==null || listCloudAddressNums.Count==0) {
				return;
			}
			string command="DELETE FROM cloudaddress "
				+"WHERE CloudAddressNum IN("+string.Join(",",listCloudAddressNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}