//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EmailMessageCrud {
		///<summary>Gets one EmailMessage object from the database using the primary key.  Returns null if not found.</summary>
		public static EmailMessage SelectOne(long emailMessageNum) {
			string command="SELECT * FROM emailmessage "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessageNum);
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EmailMessage object from the database using a query.</summary>
		public static EmailMessage SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EmailMessage objects from the database using a query.</summary>
		public static List<EmailMessage> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailMessage> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EmailMessage> TableToList(DataTable table) {
			List<EmailMessage> retVal=new List<EmailMessage>();
			EmailMessage emailMessage;
			foreach(DataRow row in table.Rows) {
				emailMessage=new EmailMessage();
				emailMessage.EmailMessageNum = PIn.Long  (row["EmailMessageNum"].ToString());
				emailMessage.PatNum          = PIn.Long  (row["PatNum"].ToString());
				emailMessage.ToAddress       = PIn.String(row["ToAddress"].ToString());
				emailMessage.FromAddress     = PIn.String(row["FromAddress"].ToString());
				emailMessage.Subject         = PIn.String(row["Subject"].ToString());
				emailMessage.BodyText        = PIn.String(row["BodyText"].ToString());
				emailMessage.MsgDateTime     = PIn.DateT (row["MsgDateTime"].ToString());
				emailMessage.SentOrReceived  = (OpenDentBusiness.EmailSentOrReceived)PIn.Int(row["SentOrReceived"].ToString());
				emailMessage.RecipientAddress= PIn.String(row["RecipientAddress"].ToString());
				emailMessage.RawEmailIn      = PIn.String(row["RawEmailIn"].ToString());
				emailMessage.ProvNumWebMail  = PIn.Long  (row["ProvNumWebMail"].ToString());
				emailMessage.PatNumSubj      = PIn.Long  (row["PatNumSubj"].ToString());
				emailMessage.CcAddress       = PIn.String(row["CcAddress"].ToString());
				emailMessage.BccAddress      = PIn.String(row["BccAddress"].ToString());
				emailMessage.HideIn          = (OpenDentBusiness.HideInFlags)PIn.Int(row["HideIn"].ToString());
				emailMessage.AptNum          = PIn.Long  (row["AptNum"].ToString());
				emailMessage.UserNum         = PIn.Long  (row["UserNum"].ToString());
				emailMessage.HtmlType        = (OpenDentBusiness.EmailType)PIn.Int(row["HtmlType"].ToString());
				emailMessage.SecDateTEntry   = PIn.DateT (row["SecDateTEntry"].ToString());
				emailMessage.SecDateTEdit    = PIn.DateT (row["SecDateTEdit"].ToString());
				string msgType=row["MsgType"].ToString();
				if(msgType=="") {
					emailMessage.MsgType       =(OpenDentBusiness.EmailMessageSource)0;
				}
				else try{
					emailMessage.MsgType       =(OpenDentBusiness.EmailMessageSource)Enum.Parse(typeof(OpenDentBusiness.EmailMessageSource),msgType);
				}
				catch{
					emailMessage.MsgType       =(OpenDentBusiness.EmailMessageSource)0;
				}
				emailMessage.FailReason      = PIn.String(row["FailReason"].ToString());
				retVal.Add(emailMessage);
			}
			return retVal;
		}

		///<summary>Converts a list of EmailMessage into a DataTable.</summary>
		public static DataTable ListToTable(List<EmailMessage> listEmailMessages,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EmailMessage";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EmailMessageNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ToAddress");
			table.Columns.Add("FromAddress");
			table.Columns.Add("Subject");
			table.Columns.Add("BodyText");
			table.Columns.Add("MsgDateTime");
			table.Columns.Add("SentOrReceived");
			table.Columns.Add("RecipientAddress");
			table.Columns.Add("RawEmailIn");
			table.Columns.Add("ProvNumWebMail");
			table.Columns.Add("PatNumSubj");
			table.Columns.Add("CcAddress");
			table.Columns.Add("BccAddress");
			table.Columns.Add("HideIn");
			table.Columns.Add("AptNum");
			table.Columns.Add("UserNum");
			table.Columns.Add("HtmlType");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("SecDateTEdit");
			table.Columns.Add("MsgType");
			table.Columns.Add("FailReason");
			foreach(EmailMessage emailMessage in listEmailMessages) {
				table.Rows.Add(new object[] {
					POut.Long  (emailMessage.EmailMessageNum),
					POut.Long  (emailMessage.PatNum),
					            emailMessage.ToAddress,
					            emailMessage.FromAddress,
					            emailMessage.Subject,
					            emailMessage.BodyText,
					POut.DateT (emailMessage.MsgDateTime,false),
					POut.Int   ((int)emailMessage.SentOrReceived),
					            emailMessage.RecipientAddress,
					            emailMessage.RawEmailIn,
					POut.Long  (emailMessage.ProvNumWebMail),
					POut.Long  (emailMessage.PatNumSubj),
					            emailMessage.CcAddress,
					            emailMessage.BccAddress,
					POut.Int   ((int)emailMessage.HideIn),
					POut.Long  (emailMessage.AptNum),
					POut.Long  (emailMessage.UserNum),
					POut.Int   ((int)emailMessage.HtmlType),
					POut.DateT (emailMessage.SecDateTEntry,false),
					POut.DateT (emailMessage.SecDateTEdit,false),
					POut.Int   ((int)emailMessage.MsgType),
					            emailMessage.FailReason,
				});
			}
			return table;
		}

		///<summary>Inserts one EmailMessage into the database.  Returns the new priKey.</summary>
		public static long Insert(EmailMessage emailMessage) {
			return Insert(emailMessage,false);
		}

		///<summary>Inserts one EmailMessage into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EmailMessage emailMessage,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				emailMessage.EmailMessageNum=ReplicationServers.GetKey("emailmessage","EmailMessageNum");
			}
			string command="INSERT INTO emailmessage (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmailMessageNum,";
			}
			command+="PatNum,ToAddress,FromAddress,Subject,BodyText,MsgDateTime,SentOrReceived,RecipientAddress,RawEmailIn,ProvNumWebMail,PatNumSubj,CcAddress,BccAddress,HideIn,AptNum,UserNum,HtmlType,SecDateTEntry,MsgType,FailReason) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(emailMessage.EmailMessageNum)+",";
			}
			command+=
				     POut.Long  (emailMessage.PatNum)+","
				+    DbHelper.ParamChar+"paramToAddress,"
				+    DbHelper.ParamChar+"paramFromAddress,"
				+    DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    POut.DateT (emailMessage.MsgDateTime)+","
				+    POut.Int   ((int)emailMessage.SentOrReceived)+","
				+"'"+POut.String(emailMessage.RecipientAddress)+"',"
				+    DbHelper.ParamChar+"paramRawEmailIn,"
				+    POut.Long  (emailMessage.ProvNumWebMail)+","
				+    POut.Long  (emailMessage.PatNumSubj)+","
				+    DbHelper.ParamChar+"paramCcAddress,"
				+    DbHelper.ParamChar+"paramBccAddress,"
				+    POut.Int   ((int)emailMessage.HideIn)+","
				+    POut.Long  (emailMessage.AptNum)+","
				+    POut.Long  (emailMessage.UserNum)+","
				+    POut.Int   ((int)emailMessage.HtmlType)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+"'"+POut.String(emailMessage.MsgType.ToString())+"',"
				+"'"+POut.String(emailMessage.FailReason)+"')";
			if(emailMessage.ToAddress==null) {
				emailMessage.ToAddress="";
			}
			OdSqlParameter paramToAddress=new OdSqlParameter("paramToAddress",OdDbType.Text,POut.StringParam(emailMessage.ToAddress));
			if(emailMessage.FromAddress==null) {
				emailMessage.FromAddress="";
			}
			OdSqlParameter paramFromAddress=new OdSqlParameter("paramFromAddress",OdDbType.Text,POut.StringParam(emailMessage.FromAddress));
			if(emailMessage.Subject==null) {
				emailMessage.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailMessage.Subject));
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailMessage.BodyText));
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,POut.StringParam(emailMessage.RawEmailIn));
			if(emailMessage.CcAddress==null) {
				emailMessage.CcAddress="";
			}
			OdSqlParameter paramCcAddress=new OdSqlParameter("paramCcAddress",OdDbType.Text,POut.StringParam(emailMessage.CcAddress));
			if(emailMessage.BccAddress==null) {
				emailMessage.BccAddress="";
			}
			OdSqlParameter paramBccAddress=new OdSqlParameter("paramBccAddress",OdDbType.Text,POut.StringParam(emailMessage.BccAddress));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
			}
			else {
				emailMessage.EmailMessageNum=Db.NonQ(command,true,"EmailMessageNum","emailMessage",paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
			}
			return emailMessage.EmailMessageNum;
		}

		///<summary>Inserts one EmailMessage into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailMessage emailMessage) {
			return InsertNoCache(emailMessage,false);
		}

		///<summary>Inserts one EmailMessage into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailMessage emailMessage,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO emailmessage (";
			if(!useExistingPK && isRandomKeys) {
				emailMessage.EmailMessageNum=ReplicationServers.GetKeyNoCache("emailmessage","EmailMessageNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EmailMessageNum,";
			}
			command+="PatNum,ToAddress,FromAddress,Subject,BodyText,MsgDateTime,SentOrReceived,RecipientAddress,RawEmailIn,ProvNumWebMail,PatNumSubj,CcAddress,BccAddress,HideIn,AptNum,UserNum,HtmlType,SecDateTEntry,MsgType,FailReason) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(emailMessage.EmailMessageNum)+",";
			}
			command+=
				     POut.Long  (emailMessage.PatNum)+","
				+    DbHelper.ParamChar+"paramToAddress,"
				+    DbHelper.ParamChar+"paramFromAddress,"
				+    DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    POut.DateT (emailMessage.MsgDateTime)+","
				+    POut.Int   ((int)emailMessage.SentOrReceived)+","
				+"'"+POut.String(emailMessage.RecipientAddress)+"',"
				+    DbHelper.ParamChar+"paramRawEmailIn,"
				+    POut.Long  (emailMessage.ProvNumWebMail)+","
				+    POut.Long  (emailMessage.PatNumSubj)+","
				+    DbHelper.ParamChar+"paramCcAddress,"
				+    DbHelper.ParamChar+"paramBccAddress,"
				+    POut.Int   ((int)emailMessage.HideIn)+","
				+    POut.Long  (emailMessage.AptNum)+","
				+    POut.Long  (emailMessage.UserNum)+","
				+    POut.Int   ((int)emailMessage.HtmlType)+","
				+    DbHelper.Now()+","
				//SecDateTEdit can only be set by MySQL
				+"'"+POut.String(emailMessage.MsgType.ToString())+"',"
				+"'"+POut.String(emailMessage.FailReason)+"')";
			if(emailMessage.ToAddress==null) {
				emailMessage.ToAddress="";
			}
			OdSqlParameter paramToAddress=new OdSqlParameter("paramToAddress",OdDbType.Text,POut.StringParam(emailMessage.ToAddress));
			if(emailMessage.FromAddress==null) {
				emailMessage.FromAddress="";
			}
			OdSqlParameter paramFromAddress=new OdSqlParameter("paramFromAddress",OdDbType.Text,POut.StringParam(emailMessage.FromAddress));
			if(emailMessage.Subject==null) {
				emailMessage.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailMessage.Subject));
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailMessage.BodyText));
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,POut.StringParam(emailMessage.RawEmailIn));
			if(emailMessage.CcAddress==null) {
				emailMessage.CcAddress="";
			}
			OdSqlParameter paramCcAddress=new OdSqlParameter("paramCcAddress",OdDbType.Text,POut.StringParam(emailMessage.CcAddress));
			if(emailMessage.BccAddress==null) {
				emailMessage.BccAddress="";
			}
			OdSqlParameter paramBccAddress=new OdSqlParameter("paramBccAddress",OdDbType.Text,POut.StringParam(emailMessage.BccAddress));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
			}
			else {
				emailMessage.EmailMessageNum=Db.NonQ(command,true,"EmailMessageNum","emailMessage",paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
			}
			return emailMessage.EmailMessageNum;
		}

		///<summary>Updates one EmailMessage in the database.</summary>
		public static void Update(EmailMessage emailMessage) {
			string command="UPDATE emailmessage SET "
				+"PatNum          =  "+POut.Long  (emailMessage.PatNum)+", "
				+"ToAddress       =  "+DbHelper.ParamChar+"paramToAddress, "
				+"FromAddress     =  "+DbHelper.ParamChar+"paramFromAddress, "
				+"Subject         =  "+DbHelper.ParamChar+"paramSubject, "
				+"BodyText        =  "+DbHelper.ParamChar+"paramBodyText, "
				+"MsgDateTime     =  "+POut.DateT (emailMessage.MsgDateTime)+", "
				+"SentOrReceived  =  "+POut.Int   ((int)emailMessage.SentOrReceived)+", "
				+"RecipientAddress= '"+POut.String(emailMessage.RecipientAddress)+"', "
				+"RawEmailIn      =  "+DbHelper.ParamChar+"paramRawEmailIn, "
				+"ProvNumWebMail  =  "+POut.Long  (emailMessage.ProvNumWebMail)+", "
				+"PatNumSubj      =  "+POut.Long  (emailMessage.PatNumSubj)+", "
				+"CcAddress       =  "+DbHelper.ParamChar+"paramCcAddress, "
				+"BccAddress      =  "+DbHelper.ParamChar+"paramBccAddress, "
				+"HideIn          =  "+POut.Int   ((int)emailMessage.HideIn)+", "
				+"AptNum          =  "+POut.Long  (emailMessage.AptNum)+", "
				+"UserNum         =  "+POut.Long  (emailMessage.UserNum)+", "
				+"HtmlType        =  "+POut.Int   ((int)emailMessage.HtmlType)+", "
				//SecDateTEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"MsgType         = '"+POut.String(emailMessage.MsgType.ToString())+"', "
				+"FailReason      = '"+POut.String(emailMessage.FailReason)+"' "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessage.EmailMessageNum);
			if(emailMessage.ToAddress==null) {
				emailMessage.ToAddress="";
			}
			OdSqlParameter paramToAddress=new OdSqlParameter("paramToAddress",OdDbType.Text,POut.StringParam(emailMessage.ToAddress));
			if(emailMessage.FromAddress==null) {
				emailMessage.FromAddress="";
			}
			OdSqlParameter paramFromAddress=new OdSqlParameter("paramFromAddress",OdDbType.Text,POut.StringParam(emailMessage.FromAddress));
			if(emailMessage.Subject==null) {
				emailMessage.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailMessage.Subject));
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailMessage.BodyText));
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,POut.StringParam(emailMessage.RawEmailIn));
			if(emailMessage.CcAddress==null) {
				emailMessage.CcAddress="";
			}
			OdSqlParameter paramCcAddress=new OdSqlParameter("paramCcAddress",OdDbType.Text,POut.StringParam(emailMessage.CcAddress));
			if(emailMessage.BccAddress==null) {
				emailMessage.BccAddress="";
			}
			OdSqlParameter paramBccAddress=new OdSqlParameter("paramBccAddress",OdDbType.Text,POut.StringParam(emailMessage.BccAddress));
			Db.NonQ(command,paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
		}

		///<summary>Updates one EmailMessage in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EmailMessage emailMessage,EmailMessage oldEmailMessage) {
			string command="";
			if(emailMessage.PatNum != oldEmailMessage.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(emailMessage.PatNum)+"";
			}
			if(emailMessage.ToAddress != oldEmailMessage.ToAddress) {
				if(command!="") { command+=",";}
				command+="ToAddress = "+DbHelper.ParamChar+"paramToAddress";
			}
			if(emailMessage.FromAddress != oldEmailMessage.FromAddress) {
				if(command!="") { command+=",";}
				command+="FromAddress = "+DbHelper.ParamChar+"paramFromAddress";
			}
			if(emailMessage.Subject != oldEmailMessage.Subject) {
				if(command!="") { command+=",";}
				command+="Subject = "+DbHelper.ParamChar+"paramSubject";
			}
			if(emailMessage.BodyText != oldEmailMessage.BodyText) {
				if(command!="") { command+=",";}
				command+="BodyText = "+DbHelper.ParamChar+"paramBodyText";
			}
			if(emailMessage.MsgDateTime != oldEmailMessage.MsgDateTime) {
				if(command!="") { command+=",";}
				command+="MsgDateTime = "+POut.DateT(emailMessage.MsgDateTime)+"";
			}
			if(emailMessage.SentOrReceived != oldEmailMessage.SentOrReceived) {
				if(command!="") { command+=",";}
				command+="SentOrReceived = "+POut.Int   ((int)emailMessage.SentOrReceived)+"";
			}
			if(emailMessage.RecipientAddress != oldEmailMessage.RecipientAddress) {
				if(command!="") { command+=",";}
				command+="RecipientAddress = '"+POut.String(emailMessage.RecipientAddress)+"'";
			}
			if(emailMessage.RawEmailIn != oldEmailMessage.RawEmailIn) {
				if(command!="") { command+=",";}
				command+="RawEmailIn = "+DbHelper.ParamChar+"paramRawEmailIn";
			}
			if(emailMessage.ProvNumWebMail != oldEmailMessage.ProvNumWebMail) {
				if(command!="") { command+=",";}
				command+="ProvNumWebMail = "+POut.Long(emailMessage.ProvNumWebMail)+"";
			}
			if(emailMessage.PatNumSubj != oldEmailMessage.PatNumSubj) {
				if(command!="") { command+=",";}
				command+="PatNumSubj = "+POut.Long(emailMessage.PatNumSubj)+"";
			}
			if(emailMessage.CcAddress != oldEmailMessage.CcAddress) {
				if(command!="") { command+=",";}
				command+="CcAddress = "+DbHelper.ParamChar+"paramCcAddress";
			}
			if(emailMessage.BccAddress != oldEmailMessage.BccAddress) {
				if(command!="") { command+=",";}
				command+="BccAddress = "+DbHelper.ParamChar+"paramBccAddress";
			}
			if(emailMessage.HideIn != oldEmailMessage.HideIn) {
				if(command!="") { command+=",";}
				command+="HideIn = "+POut.Int   ((int)emailMessage.HideIn)+"";
			}
			if(emailMessage.AptNum != oldEmailMessage.AptNum) {
				if(command!="") { command+=",";}
				command+="AptNum = "+POut.Long(emailMessage.AptNum)+"";
			}
			if(emailMessage.UserNum != oldEmailMessage.UserNum) {
				if(command!="") { command+=",";}
				command+="UserNum = "+POut.Long(emailMessage.UserNum)+"";
			}
			if(emailMessage.HtmlType != oldEmailMessage.HtmlType) {
				if(command!="") { command+=",";}
				command+="HtmlType = "+POut.Int   ((int)emailMessage.HtmlType)+"";
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(emailMessage.MsgType != oldEmailMessage.MsgType) {
				if(command!="") { command+=",";}
				command+="MsgType = '"+POut.String(emailMessage.MsgType.ToString())+"'";
			}
			if(emailMessage.FailReason != oldEmailMessage.FailReason) {
				if(command!="") { command+=",";}
				command+="FailReason = '"+POut.String(emailMessage.FailReason)+"'";
			}
			if(command=="") {
				return false;
			}
			if(emailMessage.ToAddress==null) {
				emailMessage.ToAddress="";
			}
			OdSqlParameter paramToAddress=new OdSqlParameter("paramToAddress",OdDbType.Text,POut.StringParam(emailMessage.ToAddress));
			if(emailMessage.FromAddress==null) {
				emailMessage.FromAddress="";
			}
			OdSqlParameter paramFromAddress=new OdSqlParameter("paramFromAddress",OdDbType.Text,POut.StringParam(emailMessage.FromAddress));
			if(emailMessage.Subject==null) {
				emailMessage.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailMessage.Subject));
			if(emailMessage.BodyText==null) {
				emailMessage.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailMessage.BodyText));
			if(emailMessage.RawEmailIn==null) {
				emailMessage.RawEmailIn="";
			}
			OdSqlParameter paramRawEmailIn=new OdSqlParameter("paramRawEmailIn",OdDbType.Text,POut.StringParam(emailMessage.RawEmailIn));
			if(emailMessage.CcAddress==null) {
				emailMessage.CcAddress="";
			}
			OdSqlParameter paramCcAddress=new OdSqlParameter("paramCcAddress",OdDbType.Text,POut.StringParam(emailMessage.CcAddress));
			if(emailMessage.BccAddress==null) {
				emailMessage.BccAddress="";
			}
			OdSqlParameter paramBccAddress=new OdSqlParameter("paramBccAddress",OdDbType.Text,POut.StringParam(emailMessage.BccAddress));
			command="UPDATE emailmessage SET "+command
				+" WHERE EmailMessageNum = "+POut.Long(emailMessage.EmailMessageNum);
			Db.NonQ(command,paramToAddress,paramFromAddress,paramSubject,paramBodyText,paramRawEmailIn,paramCcAddress,paramBccAddress);
			return true;
		}

		///<summary>Returns true if Update(EmailMessage,EmailMessage) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EmailMessage emailMessage,EmailMessage oldEmailMessage) {
			if(emailMessage.PatNum != oldEmailMessage.PatNum) {
				return true;
			}
			if(emailMessage.ToAddress != oldEmailMessage.ToAddress) {
				return true;
			}
			if(emailMessage.FromAddress != oldEmailMessage.FromAddress) {
				return true;
			}
			if(emailMessage.Subject != oldEmailMessage.Subject) {
				return true;
			}
			if(emailMessage.BodyText != oldEmailMessage.BodyText) {
				return true;
			}
			if(emailMessage.MsgDateTime != oldEmailMessage.MsgDateTime) {
				return true;
			}
			if(emailMessage.SentOrReceived != oldEmailMessage.SentOrReceived) {
				return true;
			}
			if(emailMessage.RecipientAddress != oldEmailMessage.RecipientAddress) {
				return true;
			}
			if(emailMessage.RawEmailIn != oldEmailMessage.RawEmailIn) {
				return true;
			}
			if(emailMessage.ProvNumWebMail != oldEmailMessage.ProvNumWebMail) {
				return true;
			}
			if(emailMessage.PatNumSubj != oldEmailMessage.PatNumSubj) {
				return true;
			}
			if(emailMessage.CcAddress != oldEmailMessage.CcAddress) {
				return true;
			}
			if(emailMessage.BccAddress != oldEmailMessage.BccAddress) {
				return true;
			}
			if(emailMessage.HideIn != oldEmailMessage.HideIn) {
				return true;
			}
			if(emailMessage.AptNum != oldEmailMessage.AptNum) {
				return true;
			}
			if(emailMessage.UserNum != oldEmailMessage.UserNum) {
				return true;
			}
			if(emailMessage.HtmlType != oldEmailMessage.HtmlType) {
				return true;
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(emailMessage.MsgType != oldEmailMessage.MsgType) {
				return true;
			}
			if(emailMessage.FailReason != oldEmailMessage.FailReason) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EmailMessage from the database.</summary>
		public static void Delete(long emailMessageNum) {
			string command="DELETE FROM emailmessage "
				+"WHERE EmailMessageNum = "+POut.Long(emailMessageNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EmailMessages from the database.</summary>
		public static void DeleteMany(List<long> listEmailMessageNums) {
			if(listEmailMessageNums==null || listEmailMessageNums.Count==0) {
				return;
			}
			string command="DELETE FROM emailmessage "
				+"WHERE EmailMessageNum IN("+string.Join(",",listEmailMessageNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}