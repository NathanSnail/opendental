//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class DocumentmCrud {
		///<summary>Gets one Documentm object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Documentm SelectOne(long customerNum,long docNum){
			string command="SELECT * FROM documentm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND DocNum = "+POut.Long(docNum);
			List<Documentm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Documentm object from the database using a query.</summary>
		internal static Documentm SelectOne(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Documentm> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Documentm objects from the database using a query.</summary>
		internal static List<Documentm> SelectMany(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Documentm> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Documentm> TableToList(DataTable table){
			List<Documentm> retVal=new List<Documentm>();
			Documentm documentm;
			for(int i=0;i<table.Rows.Count;i++) {
				documentm=new Documentm();
				documentm.CustomerNum= PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				documentm.DocNum     = PIn.Long  (table.Rows[i]["DocNum"].ToString());
				documentm.PatNum     = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				documentm.RawBase64  = PIn.String(table.Rows[i]["RawBase64"].ToString());
				retVal.Add(documentm);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Documentm into the database.</summary>
		internal static long Insert(Documentm documentm,bool useExistingPK){
			if(!useExistingPK) {
				documentm.DocNum=ReplicationServers.GetKey("documentm","DocNum");
			}
			string command="INSERT INTO documentm (";
			command+="DocNum,";
			command+="CustomerNum,PatNum,RawBase64) VALUES(";
			command+=POut.Long(documentm.DocNum)+",";
			command+=
				     POut.Long  (documentm.CustomerNum)+","
				+    POut.Long  (documentm.PatNum)+","
				+DbHelper.ParamChar+"paramRawBase64)";
			if(documentm.RawBase64==null) {
				documentm.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,documentm.RawBase64);
			Db.NonQ(command,paramRawBase64);//There is no autoincrement in the mobile server.
			return documentm.DocNum;
		}

		///<summary>Updates one Documentm in the database.</summary>
		internal static void Update(Documentm documentm){
			string command="UPDATE documentm SET "
				+"PatNum     =  "+POut.Long  (documentm.PatNum)+", "
				+"RawBase64  =  "+DbHelper.ParamChar+"paramRawBase64 "
				+"WHERE CustomerNum = "+POut.Long(documentm.CustomerNum)+" AND DocNum = "+POut.Long(documentm.DocNum);
			if(documentm.RawBase64==null) {
				documentm.RawBase64="";
			}
			OdSqlParameter paramRawBase64=new OdSqlParameter("paramRawBase64",OdDbType.Text,documentm.RawBase64);
			Db.NonQ(command,paramRawBase64);
		}

		///<summary>Deletes one Documentm from the database.</summary>
		internal static void Delete(long customerNum,long docNum){
			string command="DELETE FROM documentm "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND DocNum = "+POut.Long(docNum);
			Db.NonQ(command);
		}

		///<summary>Converts one Document object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Documentm ConvertToM(Document document){
			Documentm documentm=new Documentm();
			//CustomerNum cannot be set.  Remains 0.
			documentm.DocNum     =document.DocNum;
			documentm.PatNum     =document.PatNum;
			documentm.RawBase64  =document.RawBase64;
			return documentm;
		}

	}
}