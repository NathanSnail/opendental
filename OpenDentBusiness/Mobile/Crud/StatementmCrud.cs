//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class StatementmCrud {
		///<summary>Gets one Statementm object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Statementm SelectOne(long customerNum,long statementNum){
			string command="SELECT * FROM statementm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND StatementNum = "+POut.Long(statementNum);
			List<Statementm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Statementm object from the database using a query.</summary>
		internal static Statementm SelectOne(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Statementm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Statementm objects from the database using a query.</summary>
		internal static List<Statementm> SelectMany(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Statementm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Statementm> TableToList(DataTable table){
			List<Statementm> retVal=new List<Statementm>();
			Statementm statementm;
			for(int i=0;i<table.Rows.Count;i++) {
				statementm=new Statementm();
				statementm.CustomerNum = PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				statementm.StatementNum= PIn.Long  (table.Rows[i]["StatementNum"].ToString());
				statementm.PatNum      = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				statementm.DateSent    = PIn.Date  (table.Rows[i]["DateSent"].ToString());
				statementm.DocNum      = PIn.Long  (table.Rows[i]["DocNum"].ToString());
				retVal.Add(statementm);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Statementm into the database.</summary>
		internal static long Insert(Statementm statementm,bool useExistingPK){
			if(!useExistingPK) {
				statementm.StatementNum=ReplicationServers.GetKey("statementm","StatementNum");
			}
			string command="INSERT INTO statementm (";
			command+="StatementNum,";
			command+="CustomerNum,PatNum,DateSent,DocNum) VALUES(";
			command+=POut.Long(statementm.StatementNum)+",";
			command+=
				     POut.Long  (statementm.CustomerNum)+","
				+    POut.Long  (statementm.PatNum)+","
				+    POut.Date  (statementm.DateSent)+","
				+    POut.Long  (statementm.DocNum)+")";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return statementm.StatementNum;
		}

		///<summary>Updates one Statementm in the database.</summary>
		internal static void Update(Statementm statementm){
			string command="UPDATE statementm SET "
				+"PatNum      =  "+POut.Long  (statementm.PatNum)+", "
				+"DateSent    =  "+POut.Date  (statementm.DateSent)+", "
				+"DocNum      =  "+POut.Long  (statementm.DocNum)+" "
				+"WHERE CustomerNum = "+POut.Long(statementm.CustomerNum)+" AND StatementNum = "+POut.Long(statementm.StatementNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Statementm from the database.</summary>
		internal static void Delete(long customerNum,long statementNum){
			string command="DELETE FROM statementm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND StatementNum = "+POut.Long(statementNum);
			Db.NonQ(command);
		}

		///<summary>Converts one Statement object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Statementm ConvertToM(Statement statement){
			Statementm statementm=new Statementm();
			//CustomerNum cannot be set.  Remains 0.
			statementm.StatementNum=statement.StatementNum;
			statementm.PatNum      =statement.PatNum;
			statementm.DateSent    =statement.DateSent;
			statementm.DocNum      =statement.DocNum;
			return statementm;
		}

	}
}