//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class ICD9mCrud {
		///<summary>Gets one ICD9m object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static ICD9m SelectOne(long customerNum,long iCD9Num){
			string command="SELECT * FROM icd9m "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND ICD9Num = "+POut.Long(iCD9Num);
			List<ICD9m> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ICD9m object from the database using a query.</summary>
		internal static ICD9m SelectOne(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ICD9m> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ICD9m objects from the database using a query.</summary>
		internal static List<ICD9m> SelectMany(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ICD9m> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<ICD9m> TableToList(DataTable table){
			List<ICD9m> retVal=new List<ICD9m>();
			ICD9m iCD9m;
			for(int i=0;i<table.Rows.Count;i++) {
				iCD9m=new ICD9m();
				iCD9m.CustomerNum= PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				iCD9m.ICD9Num    = PIn.Long  (table.Rows[i]["ICD9Num"].ToString());
				iCD9m.ICD9Code   = PIn.String(table.Rows[i]["ICD9Code"].ToString());
				iCD9m.Description= PIn.String(table.Rows[i]["Description"].ToString());
				retVal.Add(iCD9m);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one ICD9m into the database.</summary>
		internal static long Insert(ICD9m iCD9m,bool useExistingPK){
			if(!useExistingPK) {
				iCD9m.ICD9Num=ReplicationServers.GetKey("icd9m","ICD9Num");
			}
			string command="INSERT INTO icd9m (";
			command+="ICD9Num,";
			command+="CustomerNum,ICD9Code,Description) VALUES(";
			command+=POut.Long(iCD9m.ICD9Num)+",";
			command+=
				     POut.Long  (iCD9m.CustomerNum)+","
				+"'"+POut.String(iCD9m.ICD9Code)+"',"
				+"'"+POut.String(iCD9m.Description)+"')";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return iCD9m.ICD9Num;
		}

		///<summary>Updates one ICD9m in the database.</summary>
		internal static void Update(ICD9m iCD9m){
			string command="UPDATE icd9m SET "
				+"ICD9Code   = '"+POut.String(iCD9m.ICD9Code)+"', "
				+"Description= '"+POut.String(iCD9m.Description)+"' "
				+"WHERE CustomerNum = "+POut.Long(iCD9m.CustomerNum)+" AND ICD9Num = "+POut.Long(iCD9m.ICD9Num);
			Db.NonQ(command);
		}

		///<summary>Deletes one ICD9m from the database.</summary>
		internal static void Delete(long customerNum,long iCD9Num){
			string command="DELETE FROM icd9m "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND ICD9Num = "+POut.Long(iCD9Num);
			Db.NonQ(command);
		}

		///<summary>Converts one ICD9 object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static ICD9m ConvertToM(ICD9 iCD9){
			ICD9m iCD9m=new ICD9m();
			//CustomerNum cannot be set.  Remains 0.
			iCD9m.ICD9Num    =iCD9.ICD9Num;
			iCD9m.ICD9Code   =iCD9.ICD9Code;
			iCD9m.Description=iCD9.Description;
			return iCD9m;
		}

	}
}