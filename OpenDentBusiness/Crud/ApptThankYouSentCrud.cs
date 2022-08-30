//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class ApptThankYouSentCrud {
		///<summary>Gets one ApptThankYouSent object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptThankYouSent SelectOne(long apptThankYouSentNum) {
			string command="SELECT * FROM apptthankyousent "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSentNum);
			List<ApptThankYouSent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptThankYouSent object from the database using a query.</summary>
		public static ApptThankYouSent SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptThankYouSent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptThankYouSent objects from the database using a query.</summary>
		public static List<ApptThankYouSent> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptThankYouSent> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptThankYouSent> TableToList(DataTable table) {
			List<ApptThankYouSent> retVal=new List<ApptThankYouSent>();
			ApptThankYouSent apptThankYouSent;
			foreach(DataRow row in table.Rows) {
				apptThankYouSent=new ApptThankYouSent();
				apptThankYouSent.ApptThankYouSentNum     = PIn.Long  (row["ApptThankYouSentNum"].ToString());
				apptThankYouSent.ApptSecDateTEntry       = PIn.DateT (row["ApptSecDateTEntry"].ToString());
				apptThankYouSent.DateTimeThankYouTransmit= PIn.DateT (row["DateTimeThankYouTransmit"].ToString());
				apptThankYouSent.DoNotResend             = PIn.Bool  (row["DoNotResend"].ToString());
				apptThankYouSent.ShortGUID               = PIn.String(row["ShortGUID"].ToString());
				apptThankYouSent.ApptNum                 = PIn.Long  (row["ApptNum"].ToString());
				apptThankYouSent.ApptDateTime            = PIn.DateT (row["ApptDateTime"].ToString());
				apptThankYouSent.TSPrior                 = TimeSpan.FromTicks(PIn.Long(row["TSPrior"].ToString()));
				apptThankYouSent.PatNum                  = PIn.Long  (row["PatNum"].ToString());
				apptThankYouSent.ClinicNum               = PIn.Long  (row["ClinicNum"].ToString());
				apptThankYouSent.SendStatus              = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["SendStatus"].ToString());
				apptThankYouSent.MessageType             = (OpenDentBusiness.CommType)PIn.Int(row["MessageType"].ToString());
				apptThankYouSent.MessageFk               = PIn.Long  (row["MessageFk"].ToString());
				apptThankYouSent.DateTimeEntry           = PIn.DateT (row["DateTimeEntry"].ToString());
				apptThankYouSent.DateTimeSent            = PIn.DateT (row["DateTimeSent"].ToString());
				apptThankYouSent.ResponseDescript        = PIn.String(row["ResponseDescript"].ToString());
				apptThankYouSent.ApptReminderRuleNum     = PIn.Long  (row["ApptReminderRuleNum"].ToString());
				retVal.Add(apptThankYouSent);
			}
			return retVal;
		}

		///<summary>Converts a list of ApptThankYouSent into a DataTable.</summary>
		public static DataTable ListToTable(List<ApptThankYouSent> listApptThankYouSents,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ApptThankYouSent";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ApptThankYouSentNum");
			table.Columns.Add("ApptSecDateTEntry");
			table.Columns.Add("DateTimeThankYouTransmit");
			table.Columns.Add("DoNotResend");
			table.Columns.Add("ShortGUID");
			table.Columns.Add("ApptNum");
			table.Columns.Add("ApptDateTime");
			table.Columns.Add("TSPrior");
			table.Columns.Add("PatNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("SendStatus");
			table.Columns.Add("MessageType");
			table.Columns.Add("MessageFk");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("DateTimeSent");
			table.Columns.Add("ResponseDescript");
			table.Columns.Add("ApptReminderRuleNum");
			foreach(ApptThankYouSent apptThankYouSent in listApptThankYouSents) {
				table.Rows.Add(new object[] {
					POut.Long  (apptThankYouSent.ApptThankYouSentNum),
					POut.DateT (apptThankYouSent.ApptSecDateTEntry,false),
					POut.DateT (apptThankYouSent.DateTimeThankYouTransmit,false),
					POut.Bool  (apptThankYouSent.DoNotResend),
					            apptThankYouSent.ShortGUID,
					POut.Long  (apptThankYouSent.ApptNum),
					POut.DateT (apptThankYouSent.ApptDateTime,false),
					POut.Long (apptThankYouSent.TSPrior.Ticks),
					POut.Long  (apptThankYouSent.PatNum),
					POut.Long  (apptThankYouSent.ClinicNum),
					POut.Int   ((int)apptThankYouSent.SendStatus),
					POut.Int   ((int)apptThankYouSent.MessageType),
					POut.Long  (apptThankYouSent.MessageFk),
					POut.DateT (apptThankYouSent.DateTimeEntry,false),
					POut.DateT (apptThankYouSent.DateTimeSent,false),
					            apptThankYouSent.ResponseDescript,
					POut.Long  (apptThankYouSent.ApptReminderRuleNum),
				});
			}
			return table;
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptThankYouSent apptThankYouSent) {
			return Insert(apptThankYouSent,false);
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptThankYouSent apptThankYouSent,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				apptThankYouSent.ApptThankYouSentNum=ReplicationServers.GetKey("apptthankyousent","ApptThankYouSentNum");
			}
			string command="INSERT INTO apptthankyousent (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptThankYouSentNum,";
			}
			command+="ApptSecDateTEntry,DateTimeThankYouTransmit,DoNotResend,ShortGUID,ApptNum,ApptDateTime,TSPrior,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptThankYouSent.ApptThankYouSentNum)+",";
			}
			command+=
				     POut.DateT (apptThankYouSent.ApptSecDateTEntry)+","
				+    POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+","
				+    POut.Bool  (apptThankYouSent.DoNotResend)+","
				+"'"+POut.String(apptThankYouSent.ShortGUID)+"',"
				+    POut.Long  (apptThankYouSent.ApptNum)+","
				+    POut.DateT (apptThankYouSent.ApptDateTime)+","
				+"'"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptThankYouSent.PatNum)+","
				+    POut.Long  (apptThankYouSent.ClinicNum)+","
				+    POut.Int   ((int)apptThankYouSent.SendStatus)+","
				+    POut.Int   ((int)apptThankYouSent.MessageType)+","
				+    POut.Long  (apptThankYouSent.MessageFk)+","
				+    DbHelper.Now()+","
				+    POut.DateT (apptThankYouSent.DateTimeSent)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Long  (apptThankYouSent.ApptReminderRuleNum)+")";
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(apptThankYouSent.ResponseDescript));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramResponseDescript);
			}
			else {
				apptThankYouSent.ApptThankYouSentNum=Db.NonQ(command,true,"ApptThankYouSentNum","apptThankYouSent",paramResponseDescript);
			}
			return apptThankYouSent.ApptThankYouSentNum;
		}

		///<summary>Inserts many ApptThankYouSents into the database.</summary>
		public static void InsertMany(List<ApptThankYouSent> listApptThankYouSents) {
			InsertMany(listApptThankYouSents,false);
		}

		///<summary>Inserts many ApptThankYouSents into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<ApptThankYouSent> listApptThankYouSents,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(ApptThankYouSent apptThankYouSent in listApptThankYouSents) {
					Insert(apptThankYouSent);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listApptThankYouSents.Count) {
					ApptThankYouSent apptThankYouSent=listApptThankYouSents[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO apptthankyousent (");
						if(useExistingPK) {
							sbCommands.Append("ApptThankYouSentNum,");
						}
						sbCommands.Append("ApptSecDateTEntry,DateTimeThankYouTransmit,DoNotResend,ShortGUID,ApptNum,ApptDateTime,TSPrior,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(apptThankYouSent.ApptThankYouSentNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.DateT(apptThankYouSent.ApptSecDateTEntry)); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.DateTimeThankYouTransmit)); sbRow.Append(",");
					sbRow.Append(POut.Bool(apptThankYouSent.DoNotResend)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.ShortGUID)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.ApptNum)); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.ApptDateTime)); sbRow.Append(",");
					sbRow.Append("'"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.PatNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.ClinicNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptThankYouSent.SendStatus)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptThankYouSent.MessageType)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.MessageFk)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(",");
					sbRow.Append(POut.DateT(apptThankYouSent.DateTimeSent)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(apptThankYouSent.ResponseDescript)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(apptThankYouSent.ApptReminderRuleNum)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listApptThankYouSents.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptThankYouSent apptThankYouSent) {
			return InsertNoCache(apptThankYouSent,false);
		}

		///<summary>Inserts one ApptThankYouSent into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptThankYouSent apptThankYouSent,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO apptthankyousent (";
			if(!useExistingPK && isRandomKeys) {
				apptThankYouSent.ApptThankYouSentNum=ReplicationServers.GetKeyNoCache("apptthankyousent","ApptThankYouSentNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ApptThankYouSentNum,";
			}
			command+="ApptSecDateTEntry,DateTimeThankYouTransmit,DoNotResend,ShortGUID,ApptNum,ApptDateTime,TSPrior,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(apptThankYouSent.ApptThankYouSentNum)+",";
			}
			command+=
				     POut.DateT (apptThankYouSent.ApptSecDateTEntry)+","
				+    POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+","
				+    POut.Bool  (apptThankYouSent.DoNotResend)+","
				+"'"+POut.String(apptThankYouSent.ShortGUID)+"',"
				+    POut.Long  (apptThankYouSent.ApptNum)+","
				+    POut.DateT (apptThankYouSent.ApptDateTime)+","
				+"'"+POut.Long(apptThankYouSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptThankYouSent.PatNum)+","
				+    POut.Long  (apptThankYouSent.ClinicNum)+","
				+    POut.Int   ((int)apptThankYouSent.SendStatus)+","
				+    POut.Int   ((int)apptThankYouSent.MessageType)+","
				+    POut.Long  (apptThankYouSent.MessageFk)+","
				+    DbHelper.Now()+","
				+    POut.DateT (apptThankYouSent.DateTimeSent)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Long  (apptThankYouSent.ApptReminderRuleNum)+")";
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(apptThankYouSent.ResponseDescript));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramResponseDescript);
			}
			else {
				apptThankYouSent.ApptThankYouSentNum=Db.NonQ(command,true,"ApptThankYouSentNum","apptThankYouSent",paramResponseDescript);
			}
			return apptThankYouSent.ApptThankYouSentNum;
		}

		///<summary>Updates one ApptThankYouSent in the database.</summary>
		public static void Update(ApptThankYouSent apptThankYouSent) {
			string command="UPDATE apptthankyousent SET "
				+"ApptSecDateTEntry       =  "+POut.DateT (apptThankYouSent.ApptSecDateTEntry)+", "
				+"DateTimeThankYouTransmit=  "+POut.DateT (apptThankYouSent.DateTimeThankYouTransmit)+", "
				+"DoNotResend             =  "+POut.Bool  (apptThankYouSent.DoNotResend)+", "
				+"ShortGUID               = '"+POut.String(apptThankYouSent.ShortGUID)+"', "
				+"ApptNum                 =  "+POut.Long  (apptThankYouSent.ApptNum)+", "
				+"ApptDateTime            =  "+POut.DateT (apptThankYouSent.ApptDateTime)+", "
				+"TSPrior                 =  "+POut.Long  (apptThankYouSent.TSPrior.Ticks)+", "
				+"PatNum                  =  "+POut.Long  (apptThankYouSent.PatNum)+", "
				+"ClinicNum               =  "+POut.Long  (apptThankYouSent.ClinicNum)+", "
				+"SendStatus              =  "+POut.Int   ((int)apptThankYouSent.SendStatus)+", "
				+"MessageType             =  "+POut.Int   ((int)apptThankYouSent.MessageType)+", "
				+"MessageFk               =  "+POut.Long  (apptThankYouSent.MessageFk)+", "
				//DateTimeEntry not allowed to change
				+"DateTimeSent            =  "+POut.DateT (apptThankYouSent.DateTimeSent)+", "
				+"ResponseDescript        =  "+DbHelper.ParamChar+"paramResponseDescript, "
				+"ApptReminderRuleNum     =  "+POut.Long  (apptThankYouSent.ApptReminderRuleNum)+" "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSent.ApptThankYouSentNum);
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(apptThankYouSent.ResponseDescript));
			Db.NonQ(command,paramResponseDescript);
		}

		///<summary>Updates one ApptThankYouSent in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptThankYouSent apptThankYouSent,ApptThankYouSent oldApptThankYouSent) {
			string command="";
			if(apptThankYouSent.ApptSecDateTEntry != oldApptThankYouSent.ApptSecDateTEntry) {
				if(command!="") { command+=",";}
				command+="ApptSecDateTEntry = "+POut.DateT(apptThankYouSent.ApptSecDateTEntry)+"";
			}
			if(apptThankYouSent.DateTimeThankYouTransmit != oldApptThankYouSent.DateTimeThankYouTransmit) {
				if(command!="") { command+=",";}
				command+="DateTimeThankYouTransmit = "+POut.DateT(apptThankYouSent.DateTimeThankYouTransmit)+"";
			}
			if(apptThankYouSent.DoNotResend != oldApptThankYouSent.DoNotResend) {
				if(command!="") { command+=",";}
				command+="DoNotResend = "+POut.Bool(apptThankYouSent.DoNotResend)+"";
			}
			if(apptThankYouSent.ShortGUID != oldApptThankYouSent.ShortGUID) {
				if(command!="") { command+=",";}
				command+="ShortGUID = '"+POut.String(apptThankYouSent.ShortGUID)+"'";
			}
			if(apptThankYouSent.ApptNum != oldApptThankYouSent.ApptNum) {
				if(command!="") { command+=",";}
				command+="ApptNum = "+POut.Long(apptThankYouSent.ApptNum)+"";
			}
			if(apptThankYouSent.ApptDateTime != oldApptThankYouSent.ApptDateTime) {
				if(command!="") { command+=",";}
				command+="ApptDateTime = "+POut.DateT(apptThankYouSent.ApptDateTime)+"";
			}
			if(apptThankYouSent.TSPrior != oldApptThankYouSent.TSPrior) {
				if(command!="") { command+=",";}
				command+="TSPrior = '"+POut.Long  (apptThankYouSent.TSPrior.Ticks)+"'";
			}
			if(apptThankYouSent.PatNum != oldApptThankYouSent.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(apptThankYouSent.PatNum)+"";
			}
			if(apptThankYouSent.ClinicNum != oldApptThankYouSent.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(apptThankYouSent.ClinicNum)+"";
			}
			if(apptThankYouSent.SendStatus != oldApptThankYouSent.SendStatus) {
				if(command!="") { command+=",";}
				command+="SendStatus = "+POut.Int   ((int)apptThankYouSent.SendStatus)+"";
			}
			if(apptThankYouSent.MessageType != oldApptThankYouSent.MessageType) {
				if(command!="") { command+=",";}
				command+="MessageType = "+POut.Int   ((int)apptThankYouSent.MessageType)+"";
			}
			if(apptThankYouSent.MessageFk != oldApptThankYouSent.MessageFk) {
				if(command!="") { command+=",";}
				command+="MessageFk = "+POut.Long(apptThankYouSent.MessageFk)+"";
			}
			//DateTimeEntry not allowed to change
			if(apptThankYouSent.DateTimeSent != oldApptThankYouSent.DateTimeSent) {
				if(command!="") { command+=",";}
				command+="DateTimeSent = "+POut.DateT(apptThankYouSent.DateTimeSent)+"";
			}
			if(apptThankYouSent.ResponseDescript != oldApptThankYouSent.ResponseDescript) {
				if(command!="") { command+=",";}
				command+="ResponseDescript = "+DbHelper.ParamChar+"paramResponseDescript";
			}
			if(apptThankYouSent.ApptReminderRuleNum != oldApptThankYouSent.ApptReminderRuleNum) {
				if(command!="") { command+=",";}
				command+="ApptReminderRuleNum = "+POut.Long(apptThankYouSent.ApptReminderRuleNum)+"";
			}
			if(command=="") {
				return false;
			}
			if(apptThankYouSent.ResponseDescript==null) {
				apptThankYouSent.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(apptThankYouSent.ResponseDescript));
			command="UPDATE apptthankyousent SET "+command
				+" WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSent.ApptThankYouSentNum);
			Db.NonQ(command,paramResponseDescript);
			return true;
		}

		///<summary>Returns true if Update(ApptThankYouSent,ApptThankYouSent) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ApptThankYouSent apptThankYouSent,ApptThankYouSent oldApptThankYouSent) {
			if(apptThankYouSent.ApptSecDateTEntry != oldApptThankYouSent.ApptSecDateTEntry) {
				return true;
			}
			if(apptThankYouSent.DateTimeThankYouTransmit != oldApptThankYouSent.DateTimeThankYouTransmit) {
				return true;
			}
			if(apptThankYouSent.DoNotResend != oldApptThankYouSent.DoNotResend) {
				return true;
			}
			if(apptThankYouSent.ShortGUID != oldApptThankYouSent.ShortGUID) {
				return true;
			}
			if(apptThankYouSent.ApptNum != oldApptThankYouSent.ApptNum) {
				return true;
			}
			if(apptThankYouSent.ApptDateTime != oldApptThankYouSent.ApptDateTime) {
				return true;
			}
			if(apptThankYouSent.TSPrior != oldApptThankYouSent.TSPrior) {
				return true;
			}
			if(apptThankYouSent.PatNum != oldApptThankYouSent.PatNum) {
				return true;
			}
			if(apptThankYouSent.ClinicNum != oldApptThankYouSent.ClinicNum) {
				return true;
			}
			if(apptThankYouSent.SendStatus != oldApptThankYouSent.SendStatus) {
				return true;
			}
			if(apptThankYouSent.MessageType != oldApptThankYouSent.MessageType) {
				return true;
			}
			if(apptThankYouSent.MessageFk != oldApptThankYouSent.MessageFk) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(apptThankYouSent.DateTimeSent != oldApptThankYouSent.DateTimeSent) {
				return true;
			}
			if(apptThankYouSent.ResponseDescript != oldApptThankYouSent.ResponseDescript) {
				return true;
			}
			if(apptThankYouSent.ApptReminderRuleNum != oldApptThankYouSent.ApptReminderRuleNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ApptThankYouSent from the database.</summary>
		public static void Delete(long apptThankYouSentNum) {
			string command="DELETE FROM apptthankyousent "
				+"WHERE ApptThankYouSentNum = "+POut.Long(apptThankYouSentNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many ApptThankYouSents from the database.</summary>
		public static void DeleteMany(List<long> listApptThankYouSentNums) {
			if(listApptThankYouSentNums==null || listApptThankYouSentNums.Count==0) {
				return;
			}
			string command="DELETE FROM apptthankyousent "
				+"WHERE ApptThankYouSentNum IN("+string.Join(",",listApptThankYouSentNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}