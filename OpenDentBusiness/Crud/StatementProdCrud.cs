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
	public class StatementProdCrud {
		///<summary>Gets one StatementProd object from the database using the primary key.  Returns null if not found.</summary>
		public static StatementProd SelectOne(long statementProdNum) {
			string command="SELECT * FROM statementprod "
				+"WHERE StatementProdNum = "+POut.Long(statementProdNum);
			List<StatementProd> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one StatementProd object from the database using a query.</summary>
		public static StatementProd SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<StatementProd> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of StatementProd objects from the database using a query.</summary>
		public static List<StatementProd> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<StatementProd> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<StatementProd> TableToList(DataTable table) {
			List<StatementProd> retVal=new List<StatementProd>();
			StatementProd statementProd;
			foreach(DataRow row in table.Rows) {
				statementProd=new StatementProd();
				statementProd.StatementProdNum= PIn.Long  (row["StatementProdNum"].ToString());
				statementProd.StatementNum    = PIn.Long  (row["StatementNum"].ToString());
				statementProd.DocNum          = PIn.Long  (row["DocNum"].ToString());
				statementProd.FKey            = PIn.Long  (row["FKey"].ToString());
				statementProd.ProdType        = (OpenDentBusiness.ProductionType)PIn.Int(row["ProdType"].ToString());
				statementProd.LateChargeAdjNum= PIn.Long  (row["LateChargeAdjNum"].ToString());
				retVal.Add(statementProd);
			}
			return retVal;
		}

		///<summary>Converts a list of StatementProd into a DataTable.</summary>
		public static DataTable ListToTable(List<StatementProd> listStatementProds,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="StatementProd";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("StatementProdNum");
			table.Columns.Add("StatementNum");
			table.Columns.Add("DocNum");
			table.Columns.Add("FKey");
			table.Columns.Add("ProdType");
			table.Columns.Add("LateChargeAdjNum");
			foreach(StatementProd statementProd in listStatementProds) {
				table.Rows.Add(new object[] {
					POut.Long  (statementProd.StatementProdNum),
					POut.Long  (statementProd.StatementNum),
					POut.Long  (statementProd.DocNum),
					POut.Long  (statementProd.FKey),
					POut.Int   ((int)statementProd.ProdType),
					POut.Long  (statementProd.LateChargeAdjNum),
				});
			}
			return table;
		}

		///<summary>Inserts one StatementProd into the database.  Returns the new priKey.</summary>
		public static long Insert(StatementProd statementProd) {
			return Insert(statementProd,false);
		}

		///<summary>Inserts one StatementProd into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(StatementProd statementProd,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				statementProd.StatementProdNum=ReplicationServers.GetKey("statementprod","StatementProdNum");
			}
			string command="INSERT INTO statementprod (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="StatementProdNum,";
			}
			command+="StatementNum,DocNum,FKey,ProdType,LateChargeAdjNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(statementProd.StatementProdNum)+",";
			}
			command+=
				     POut.Long  (statementProd.StatementNum)+","
				+    POut.Long  (statementProd.DocNum)+","
				+    POut.Long  (statementProd.FKey)+","
				+    POut.Int   ((int)statementProd.ProdType)+","
				+    POut.Long  (statementProd.LateChargeAdjNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				statementProd.StatementProdNum=Db.NonQ(command,true,"StatementProdNum","statementProd");
			}
			return statementProd.StatementProdNum;
		}

		///<summary>Inserts many StatementProds into the database.</summary>
		public static void InsertMany(List<StatementProd> listStatementProds) {
			InsertMany(listStatementProds,false);
		}

		///<summary>Inserts many StatementProds into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<StatementProd> listStatementProds,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(StatementProd statementProd in listStatementProds) {
					Insert(statementProd);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listStatementProds.Count) {
					StatementProd statementProd=listStatementProds[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO statementprod (");
						if(useExistingPK) {
							sbCommands.Append("StatementProdNum,");
						}
						sbCommands.Append("StatementNum,DocNum,FKey,ProdType,LateChargeAdjNum) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(statementProd.StatementProdNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(statementProd.StatementNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(statementProd.DocNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(statementProd.FKey)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)statementProd.ProdType)); sbRow.Append(",");
					sbRow.Append(POut.Long(statementProd.LateChargeAdjNum)); sbRow.Append(")");
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
						if(index==listStatementProds.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one StatementProd into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(StatementProd statementProd) {
			return InsertNoCache(statementProd,false);
		}

		///<summary>Inserts one StatementProd into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(StatementProd statementProd,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO statementprod (";
			if(!useExistingPK && isRandomKeys) {
				statementProd.StatementProdNum=ReplicationServers.GetKeyNoCache("statementprod","StatementProdNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="StatementProdNum,";
			}
			command+="StatementNum,DocNum,FKey,ProdType,LateChargeAdjNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(statementProd.StatementProdNum)+",";
			}
			command+=
				     POut.Long  (statementProd.StatementNum)+","
				+    POut.Long  (statementProd.DocNum)+","
				+    POut.Long  (statementProd.FKey)+","
				+    POut.Int   ((int)statementProd.ProdType)+","
				+    POut.Long  (statementProd.LateChargeAdjNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				statementProd.StatementProdNum=Db.NonQ(command,true,"StatementProdNum","statementProd");
			}
			return statementProd.StatementProdNum;
		}

		///<summary>Updates one StatementProd in the database.</summary>
		public static void Update(StatementProd statementProd) {
			string command="UPDATE statementprod SET "
				+"StatementNum    =  "+POut.Long  (statementProd.StatementNum)+", "
				+"DocNum          =  "+POut.Long  (statementProd.DocNum)+", "
				+"FKey            =  "+POut.Long  (statementProd.FKey)+", "
				+"ProdType        =  "+POut.Int   ((int)statementProd.ProdType)+", "
				+"LateChargeAdjNum=  "+POut.Long  (statementProd.LateChargeAdjNum)+" "
				+"WHERE StatementProdNum = "+POut.Long(statementProd.StatementProdNum);
			Db.NonQ(command);
		}

		///<summary>Updates one StatementProd in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(StatementProd statementProd,StatementProd oldStatementProd) {
			string command="";
			if(statementProd.StatementNum != oldStatementProd.StatementNum) {
				if(command!="") { command+=",";}
				command+="StatementNum = "+POut.Long(statementProd.StatementNum)+"";
			}
			if(statementProd.DocNum != oldStatementProd.DocNum) {
				if(command!="") { command+=",";}
				command+="DocNum = "+POut.Long(statementProd.DocNum)+"";
			}
			if(statementProd.FKey != oldStatementProd.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(statementProd.FKey)+"";
			}
			if(statementProd.ProdType != oldStatementProd.ProdType) {
				if(command!="") { command+=",";}
				command+="ProdType = "+POut.Int   ((int)statementProd.ProdType)+"";
			}
			if(statementProd.LateChargeAdjNum != oldStatementProd.LateChargeAdjNum) {
				if(command!="") { command+=",";}
				command+="LateChargeAdjNum = "+POut.Long(statementProd.LateChargeAdjNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE statementprod SET "+command
				+" WHERE StatementProdNum = "+POut.Long(statementProd.StatementProdNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(StatementProd,StatementProd) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(StatementProd statementProd,StatementProd oldStatementProd) {
			if(statementProd.StatementNum != oldStatementProd.StatementNum) {
				return true;
			}
			if(statementProd.DocNum != oldStatementProd.DocNum) {
				return true;
			}
			if(statementProd.FKey != oldStatementProd.FKey) {
				return true;
			}
			if(statementProd.ProdType != oldStatementProd.ProdType) {
				return true;
			}
			if(statementProd.LateChargeAdjNum != oldStatementProd.LateChargeAdjNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one StatementProd from the database.</summary>
		public static void Delete(long statementProdNum) {
			string command="DELETE FROM statementprod "
				+"WHERE StatementProdNum = "+POut.Long(statementProdNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many StatementProds from the database.</summary>
		public static void DeleteMany(List<long> listStatementProdNums) {
			if(listStatementProdNums==null || listStatementProdNums.Count==0) {
				return;
			}
			string command="DELETE FROM statementprod "
				+"WHERE StatementProdNum IN("+string.Join(",",listStatementProdNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<StatementProd> listNew,List<StatementProd> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<StatementProd> listIns    =new List<StatementProd>();
			List<StatementProd> listUpdNew =new List<StatementProd>();
			List<StatementProd> listUpdDB  =new List<StatementProd>();
			List<StatementProd> listDel    =new List<StatementProd>();
			listNew.Sort((StatementProd x,StatementProd y) => { return x.StatementProdNum.CompareTo(y.StatementProdNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((StatementProd x,StatementProd y) => { return x.StatementProdNum.CompareTo(y.StatementProdNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			StatementProd fieldNew;
			StatementProd fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.StatementProdNum<fieldDB.StatementProdNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.StatementProdNum>fieldDB.StatementProdNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			DeleteMany(listDel.Select(x => x.StatementProdNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}