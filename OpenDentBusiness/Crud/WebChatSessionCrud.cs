//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class WebChatSessionCrud {
		///<summary>Gets one WebChatSession object from the database using the primary key.  Returns null if not found.</summary>
		public static WebChatSession SelectOne(long webChatSessionNum) {
			string command="SELECT * FROM webchatsession "
				+"WHERE WebChatSessionNum = "+POut.Long(webChatSessionNum);
			List<WebChatSession> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebChatSession object from the database using a query.</summary>
		public static WebChatSession SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebChatSession> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebChatSession objects from the database using a query.</summary>
		public static List<WebChatSession> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebChatSession> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebChatSession> TableToList(DataTable table) {
			List<WebChatSession> retVal=new List<WebChatSession>();
			WebChatSession webChatSession;
			foreach(DataRow row in table.Rows) {
				webChatSession=new WebChatSession();
				webChatSession.WebChatSessionNum= PIn.Long  (row["WebChatSessionNum"].ToString());
				webChatSession.UserName         = PIn.String(row["UserName"].ToString());
				webChatSession.PracticeName     = PIn.String(row["PracticeName"].ToString());
				webChatSession.EmailAddress     = PIn.String(row["EmailAddress"].ToString());
				webChatSession.PhoneNumber      = PIn.String(row["PhoneNumber"].ToString());
				webChatSession.IsCustomer       = PIn.Bool  (row["IsCustomer"].ToString());
				webChatSession.QuestionText     = PIn.String(row["QuestionText"].ToString());
				webChatSession.TechName         = PIn.String(row["TechName"].ToString());
				webChatSession.DateTcreated     = PIn.DateT (row["DateTcreated"].ToString());
				webChatSession.DateTend         = PIn.DateT (row["DateTend"].ToString());
				webChatSession.PatNum           = PIn.Long  (row["PatNum"].ToString());
				webChatSession.Note             = PIn.String(row["Note"].ToString());
				webChatSession.IpAddress        = PIn.String(row["IpAddress"].ToString());
				retVal.Add(webChatSession);
			}
			return retVal;
		}

		///<summary>Converts a list of WebChatSession into a DataTable.</summary>
		public static DataTable ListToTable(List<WebChatSession> listWebChatSessions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebChatSession";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("WebChatSessionNum");
			table.Columns.Add("UserName");
			table.Columns.Add("PracticeName");
			table.Columns.Add("EmailAddress");
			table.Columns.Add("PhoneNumber");
			table.Columns.Add("IsCustomer");
			table.Columns.Add("QuestionText");
			table.Columns.Add("TechName");
			table.Columns.Add("DateTcreated");
			table.Columns.Add("DateTend");
			table.Columns.Add("PatNum");
			table.Columns.Add("Note");
			table.Columns.Add("IpAddress");
			foreach(WebChatSession webChatSession in listWebChatSessions) {
				table.Rows.Add(new object[] {
					POut.Long  (webChatSession.WebChatSessionNum),
					            webChatSession.UserName,
					            webChatSession.PracticeName,
					            webChatSession.EmailAddress,
					            webChatSession.PhoneNumber,
					POut.Bool  (webChatSession.IsCustomer),
					            webChatSession.QuestionText,
					            webChatSession.TechName,
					POut.DateT (webChatSession.DateTcreated,false),
					POut.DateT (webChatSession.DateTend,false),
					POut.Long  (webChatSession.PatNum),
					            webChatSession.Note,
					            webChatSession.IpAddress,
				});
			}
			return table;
		}

		///<summary>Inserts one WebChatSession into the database.  Returns the new priKey.</summary>
		public static long Insert(WebChatSession webChatSession) {
			return Insert(webChatSession,false);
		}

		///<summary>Inserts one WebChatSession into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebChatSession webChatSession,bool useExistingPK) {
			string command="INSERT INTO webchatsession (";
			if(useExistingPK) {
				command+="WebChatSessionNum,";
			}
			command+="UserName,PracticeName,EmailAddress,PhoneNumber,IsCustomer,QuestionText,TechName,DateTcreated,DateTend,PatNum,Note,IpAddress) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webChatSession.WebChatSessionNum)+",";
			}
			command+=
				 "'"+POut.String(webChatSession.UserName)+"',"
				+"'"+POut.String(webChatSession.PracticeName)+"',"
				+"'"+POut.String(webChatSession.EmailAddress)+"',"
				+"'"+POut.String(webChatSession.PhoneNumber)+"',"
				+    POut.Bool  (webChatSession.IsCustomer)+","
				+"'"+POut.String(webChatSession.QuestionText)+"',"
				+"'"+POut.String(webChatSession.TechName)+"',"
				+    POut.DateT (webChatSession.DateTcreated)+","
				+    POut.DateT (webChatSession.DateTend)+","
				+    POut.Long  (webChatSession.PatNum)+","
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(webChatSession.IpAddress)+"')";
			if(webChatSession.Note==null) {
				webChatSession.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(webChatSession.Note));
			if(useExistingPK) {
				Db.NonQ(command,paramNote);
			}
			else {
				webChatSession.WebChatSessionNum=Db.NonQ(command,true,"WebChatSessionNum","webChatSession",paramNote);
			}
			return webChatSession.WebChatSessionNum;
		}

		///<summary>Inserts one WebChatSession into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebChatSession webChatSession) {
			return InsertNoCache(webChatSession,false);
		}

		///<summary>Inserts one WebChatSession into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebChatSession webChatSession,bool useExistingPK) {
			string command="INSERT INTO webchatsession (";
			if(useExistingPK) {
				command+="WebChatSessionNum,";
			}
			command+="UserName,PracticeName,EmailAddress,PhoneNumber,IsCustomer,QuestionText,TechName,DateTcreated,DateTend,PatNum,Note,IpAddress) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webChatSession.WebChatSessionNum)+",";
			}
			command+=
				 "'"+POut.String(webChatSession.UserName)+"',"
				+"'"+POut.String(webChatSession.PracticeName)+"',"
				+"'"+POut.String(webChatSession.EmailAddress)+"',"
				+"'"+POut.String(webChatSession.PhoneNumber)+"',"
				+    POut.Bool  (webChatSession.IsCustomer)+","
				+"'"+POut.String(webChatSession.QuestionText)+"',"
				+"'"+POut.String(webChatSession.TechName)+"',"
				+    POut.DateT (webChatSession.DateTcreated)+","
				+    POut.DateT (webChatSession.DateTend)+","
				+    POut.Long  (webChatSession.PatNum)+","
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(webChatSession.IpAddress)+"')";
			if(webChatSession.Note==null) {
				webChatSession.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(webChatSession.Note));
			if(useExistingPK) {
				Db.NonQ(command,paramNote);
			}
			else {
				webChatSession.WebChatSessionNum=Db.NonQ(command,true,"WebChatSessionNum","webChatSession",paramNote);
			}
			return webChatSession.WebChatSessionNum;
		}

		///<summary>Updates one WebChatSession in the database.</summary>
		public static void Update(WebChatSession webChatSession) {
			string command="UPDATE webchatsession SET "
				+"UserName         = '"+POut.String(webChatSession.UserName)+"', "
				+"PracticeName     = '"+POut.String(webChatSession.PracticeName)+"', "
				+"EmailAddress     = '"+POut.String(webChatSession.EmailAddress)+"', "
				+"PhoneNumber      = '"+POut.String(webChatSession.PhoneNumber)+"', "
				+"IsCustomer       =  "+POut.Bool  (webChatSession.IsCustomer)+", "
				+"QuestionText     = '"+POut.String(webChatSession.QuestionText)+"', "
				+"TechName         = '"+POut.String(webChatSession.TechName)+"', "
				+"DateTcreated     =  "+POut.DateT (webChatSession.DateTcreated)+", "
				+"DateTend         =  "+POut.DateT (webChatSession.DateTend)+", "
				+"PatNum           =  "+POut.Long  (webChatSession.PatNum)+", "
				+"Note             =  "+DbHelper.ParamChar+"paramNote, "
				+"IpAddress        = '"+POut.String(webChatSession.IpAddress)+"' "
				+"WHERE WebChatSessionNum = "+POut.Long(webChatSession.WebChatSessionNum);
			if(webChatSession.Note==null) {
				webChatSession.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(webChatSession.Note));
			Db.NonQ(command,paramNote);
		}

		///<summary>Updates one WebChatSession in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebChatSession webChatSession,WebChatSession oldWebChatSession) {
			string command="";
			if(webChatSession.UserName != oldWebChatSession.UserName) {
				if(command!="") { command+=",";}
				command+="UserName = '"+POut.String(webChatSession.UserName)+"'";
			}
			if(webChatSession.PracticeName != oldWebChatSession.PracticeName) {
				if(command!="") { command+=",";}
				command+="PracticeName = '"+POut.String(webChatSession.PracticeName)+"'";
			}
			if(webChatSession.EmailAddress != oldWebChatSession.EmailAddress) {
				if(command!="") { command+=",";}
				command+="EmailAddress = '"+POut.String(webChatSession.EmailAddress)+"'";
			}
			if(webChatSession.PhoneNumber != oldWebChatSession.PhoneNumber) {
				if(command!="") { command+=",";}
				command+="PhoneNumber = '"+POut.String(webChatSession.PhoneNumber)+"'";
			}
			if(webChatSession.IsCustomer != oldWebChatSession.IsCustomer) {
				if(command!="") { command+=",";}
				command+="IsCustomer = "+POut.Bool(webChatSession.IsCustomer)+"";
			}
			if(webChatSession.QuestionText != oldWebChatSession.QuestionText) {
				if(command!="") { command+=",";}
				command+="QuestionText = '"+POut.String(webChatSession.QuestionText)+"'";
			}
			if(webChatSession.TechName != oldWebChatSession.TechName) {
				if(command!="") { command+=",";}
				command+="TechName = '"+POut.String(webChatSession.TechName)+"'";
			}
			if(webChatSession.DateTcreated != oldWebChatSession.DateTcreated) {
				if(command!="") { command+=",";}
				command+="DateTcreated = "+POut.DateT(webChatSession.DateTcreated)+"";
			}
			if(webChatSession.DateTend != oldWebChatSession.DateTend) {
				if(command!="") { command+=",";}
				command+="DateTend = "+POut.DateT(webChatSession.DateTend)+"";
			}
			if(webChatSession.PatNum != oldWebChatSession.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(webChatSession.PatNum)+"";
			}
			if(webChatSession.Note != oldWebChatSession.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(webChatSession.IpAddress != oldWebChatSession.IpAddress) {
				if(command!="") { command+=",";}
				command+="IpAddress = '"+POut.String(webChatSession.IpAddress)+"'";
			}
			if(command=="") {
				return false;
			}
			if(webChatSession.Note==null) {
				webChatSession.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringNote(webChatSession.Note));
			command="UPDATE webchatsession SET "+command
				+" WHERE WebChatSessionNum = "+POut.Long(webChatSession.WebChatSessionNum);
			Db.NonQ(command,paramNote);
			return true;
		}

		///<summary>Returns true if Update(WebChatSession,WebChatSession) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(WebChatSession webChatSession,WebChatSession oldWebChatSession) {
			if(webChatSession.UserName != oldWebChatSession.UserName) {
				return true;
			}
			if(webChatSession.PracticeName != oldWebChatSession.PracticeName) {
				return true;
			}
			if(webChatSession.EmailAddress != oldWebChatSession.EmailAddress) {
				return true;
			}
			if(webChatSession.PhoneNumber != oldWebChatSession.PhoneNumber) {
				return true;
			}
			if(webChatSession.IsCustomer != oldWebChatSession.IsCustomer) {
				return true;
			}
			if(webChatSession.QuestionText != oldWebChatSession.QuestionText) {
				return true;
			}
			if(webChatSession.TechName != oldWebChatSession.TechName) {
				return true;
			}
			if(webChatSession.DateTcreated != oldWebChatSession.DateTcreated) {
				return true;
			}
			if(webChatSession.DateTend != oldWebChatSession.DateTend) {
				return true;
			}
			if(webChatSession.PatNum != oldWebChatSession.PatNum) {
				return true;
			}
			if(webChatSession.Note != oldWebChatSession.Note) {
				return true;
			}
			if(webChatSession.IpAddress != oldWebChatSession.IpAddress) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one WebChatSession from the database.</summary>
		public static void Delete(long webChatSessionNum) {
			string command="DELETE FROM webchatsession "
				+"WHERE WebChatSessionNum = "+POut.Long(webChatSessionNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many WebChatSessions from the database.</summary>
		public static void DeleteMany(List<long> listWebChatSessionNums) {
			if(listWebChatSessionNums==null || listWebChatSessionNums.Count==0) {
				return;
			}
			string command="DELETE FROM webchatsession "
				+"WHERE WebChatSessionNum IN("+string.Join(",",listWebChatSessionNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}