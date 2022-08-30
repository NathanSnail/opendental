//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using OpenDentBusiness;
using OpenDentBusiness.WebTypes.WebForms;

namespace OpenDentBusiness.WebTypes.WebForms.Crud{
	public class WebForms_SheetFieldDefCrud {
		///<summary>Gets one WebForms_SheetFieldDef object from the database using the primary key.  Returns null if not found.</summary>
		public static WebForms_SheetFieldDef SelectOne(long webSheetFieldDefID) {
			string command="SELECT * FROM webforms_sheetfielddef "
				+"WHERE WebSheetFieldDefID = "+POut.Long(webSheetFieldDefID);
			List<WebForms_SheetFieldDef> list=TableToList(DataCore.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebForms_SheetFieldDef object from the database using a query.</summary>
		public static WebForms_SheetFieldDef SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebForms_SheetFieldDef> list=TableToList(DataCore.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebForms_SheetFieldDef objects from the database using a query.</summary>
		public static List<WebForms_SheetFieldDef> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebForms_SheetFieldDef> list=TableToList(DataCore.GetTable(command));
			return list;
		}

		///<summary>Converts a list of WebForms_SheetFieldDef into a DataTable.</summary>
		public static DataTable ListToTable(List<WebForms_SheetFieldDef> listWebForms_SheetFieldDefs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebForms_SheetFieldDef";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("WebSheetFieldDefID");
			table.Columns.Add("WebSheetDefID");
			table.Columns.Add("FieldType");
			table.Columns.Add("FieldName");
			table.Columns.Add("FieldValue");
			table.Columns.Add("FontSize");
			table.Columns.Add("FontName");
			table.Columns.Add("FontIsBold");
			table.Columns.Add("XPos");
			table.Columns.Add("YPos");
			table.Columns.Add("Width");
			table.Columns.Add("Height");
			table.Columns.Add("GrowthBehavior");
			table.Columns.Add("RadioButtonValue");
			table.Columns.Add("RadioButtonGroup");
			table.Columns.Add("IsRequired");
			table.Columns.Add("ImageData");
			table.Columns.Add("TabOrder");
			table.Columns.Add("ReportableName");
			table.Columns.Add("TextAlign");
			table.Columns.Add("ItemColor");
			table.Columns.Add("TabOrderMobile");
			table.Columns.Add("UiLabelMobile");
			table.Columns.Add("UiLabelMobileRadioButton");
			table.Columns.Add("Language");
			table.Columns.Add("SheetFieldDefNum");
			table.Columns.Add("CanElectronicallySign");
			table.Columns.Add("IsSigProvRestricted");
			foreach(WebForms_SheetFieldDef webForms_SheetFieldDef in listWebForms_SheetFieldDefs) {
				table.Rows.Add(new object[] {
					POut.Long  (webForms_SheetFieldDef.WebSheetFieldDefID),
					POut.Long  (webForms_SheetFieldDef.WebSheetDefID),
					POut.Int   ((int)webForms_SheetFieldDef.FieldType),
					            webForms_SheetFieldDef.FieldName,
					            webForms_SheetFieldDef.FieldValue,
					POut.Float (webForms_SheetFieldDef.FontSize),
					            webForms_SheetFieldDef.FontName,
					POut.Bool  (webForms_SheetFieldDef.FontIsBold),
					POut.Int   (webForms_SheetFieldDef.XPos),
					POut.Int   (webForms_SheetFieldDef.YPos),
					POut.Int   (webForms_SheetFieldDef.Width),
					POut.Int   (webForms_SheetFieldDef.Height),
					POut.Int   ((int)webForms_SheetFieldDef.GrowthBehavior),
					            webForms_SheetFieldDef.RadioButtonValue,
					            webForms_SheetFieldDef.RadioButtonGroup,
					POut.Bool  (webForms_SheetFieldDef.IsRequired),
					            webForms_SheetFieldDef.ImageData,
					POut.Int   (webForms_SheetFieldDef.TabOrder),
					            webForms_SheetFieldDef.ReportableName,
					POut.Int   ((int)webForms_SheetFieldDef.TextAlign),
					POut.Int   (webForms_SheetFieldDef.ItemColor.ToArgb()),
					POut.Int   (webForms_SheetFieldDef.TabOrderMobile),
					            webForms_SheetFieldDef.UiLabelMobile,
					            webForms_SheetFieldDef.UiLabelMobileRadioButton,
					            webForms_SheetFieldDef.Language,
					POut.Long  (webForms_SheetFieldDef.SheetFieldDefNum),
					POut.Bool  (webForms_SheetFieldDef.CanElectronicallySign),
					POut.Bool  (webForms_SheetFieldDef.IsSigProvRestricted),
				});
			}
			return table;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebForms_SheetFieldDef> TableToList(DataTable table) {
			List<WebForms_SheetFieldDef> retVal=new List<WebForms_SheetFieldDef>();
			WebForms_SheetFieldDef webForms_SheetFieldDef;
			for(int i=0;i<table.Rows.Count;i++) {
				webForms_SheetFieldDef=new WebForms_SheetFieldDef();
				webForms_SheetFieldDef.WebSheetFieldDefID      = PIn.Long  (table.Rows[i]["WebSheetFieldDefID"].ToString());
				webForms_SheetFieldDef.WebSheetDefID           = PIn.Long  (table.Rows[i]["WebSheetDefID"].ToString());
				webForms_SheetFieldDef.FieldType               = (OpenDentBusiness.SheetFieldType)PIn.Int(table.Rows[i]["FieldType"].ToString());
				webForms_SheetFieldDef.FieldName               = PIn.String(table.Rows[i]["FieldName"].ToString());
				webForms_SheetFieldDef.FieldValue              = PIn.String(table.Rows[i]["FieldValue"].ToString());
				webForms_SheetFieldDef.FontSize                = PIn.Float (table.Rows[i]["FontSize"].ToString());
				webForms_SheetFieldDef.FontName                = PIn.String(table.Rows[i]["FontName"].ToString());
				webForms_SheetFieldDef.FontIsBold              = PIn.Bool  (table.Rows[i]["FontIsBold"].ToString());
				webForms_SheetFieldDef.XPos                    = PIn.Int   (table.Rows[i]["XPos"].ToString());
				webForms_SheetFieldDef.YPos                    = PIn.Int   (table.Rows[i]["YPos"].ToString());
				webForms_SheetFieldDef.Width                   = PIn.Int   (table.Rows[i]["Width"].ToString());
				webForms_SheetFieldDef.Height                  = PIn.Int   (table.Rows[i]["Height"].ToString());
				webForms_SheetFieldDef.GrowthBehavior          = (OpenDentBusiness.GrowthBehaviorEnum)PIn.Int(table.Rows[i]["GrowthBehavior"].ToString());
				webForms_SheetFieldDef.RadioButtonValue        = PIn.String(table.Rows[i]["RadioButtonValue"].ToString());
				webForms_SheetFieldDef.RadioButtonGroup        = PIn.String(table.Rows[i]["RadioButtonGroup"].ToString());
				webForms_SheetFieldDef.IsRequired              = PIn.Bool  (table.Rows[i]["IsRequired"].ToString());
				webForms_SheetFieldDef.ImageData               = PIn.String(table.Rows[i]["ImageData"].ToString());
				webForms_SheetFieldDef.TabOrder                = PIn.Int   (table.Rows[i]["TabOrder"].ToString());
				webForms_SheetFieldDef.ReportableName          = PIn.String(table.Rows[i]["ReportableName"].ToString());
				webForms_SheetFieldDef.TextAlign               = (System.Windows.Forms.HorizontalAlignment)PIn.Int(table.Rows[i]["TextAlign"].ToString());
				webForms_SheetFieldDef.ItemColor               = Color.FromArgb(PIn.Int(table.Rows[i]["ItemColor"].ToString()));
				webForms_SheetFieldDef.TabOrderMobile          = PIn.Int   (table.Rows[i]["TabOrderMobile"].ToString());
				webForms_SheetFieldDef.UiLabelMobile           = PIn.String(table.Rows[i]["UiLabelMobile"].ToString());
				webForms_SheetFieldDef.UiLabelMobileRadioButton= PIn.String(table.Rows[i]["UiLabelMobileRadioButton"].ToString());
				webForms_SheetFieldDef.Language                = PIn.String(table.Rows[i]["Language"].ToString());
				webForms_SheetFieldDef.SheetFieldDefNum        = PIn.Long  (table.Rows[i]["SheetFieldDefNum"].ToString());
				webForms_SheetFieldDef.CanElectronicallySign   = PIn.Bool  (table.Rows[i]["CanElectronicallySign"].ToString());
				webForms_SheetFieldDef.IsSigProvRestricted     = PIn.Bool  (table.Rows[i]["IsSigProvRestricted"].ToString());
				retVal.Add(webForms_SheetFieldDef);
			}
			return retVal;
		}

		///<summary>Inserts one WebForms_SheetFieldDef into the database.  Returns the new priKey.</summary>
		public static long Insert(WebForms_SheetFieldDef webForms_SheetFieldDef) {
			return Insert(webForms_SheetFieldDef,false);
		}

		///<summary>Inserts one WebForms_SheetFieldDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebForms_SheetFieldDef webForms_SheetFieldDef,bool useExistingPK) {
			string command="INSERT INTO webforms_sheetfielddef (";
			if(useExistingPK) {
				command+="WebSheetFieldDefID,";
			}
			command+="WebSheetDefID,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,ImageData,TabOrder,ReportableName,TextAlign,ItemColor,TabOrderMobile,UiLabelMobile,UiLabelMobileRadioButton,Language,SheetFieldDefNum,CanElectronicallySign,IsSigProvRestricted) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webForms_SheetFieldDef.WebSheetFieldDefID)+",";
			}
			command+=
				     POut.Long  (webForms_SheetFieldDef.WebSheetDefID)+","
				+    POut.Int   ((int)webForms_SheetFieldDef.FieldType)+","
				+"'"+POut.String(webForms_SheetFieldDef.FieldName)+"',"
				+    DbHelper.ParamChar+"paramFieldValue,"
				+    POut.Float (webForms_SheetFieldDef.FontSize)+","
				+"'"+POut.String(webForms_SheetFieldDef.FontName)+"',"
				+    POut.Bool  (webForms_SheetFieldDef.FontIsBold)+","
				+    POut.Int   (webForms_SheetFieldDef.XPos)+","
				+    POut.Int   (webForms_SheetFieldDef.YPos)+","
				+    POut.Int   (webForms_SheetFieldDef.Width)+","
				+    POut.Int   (webForms_SheetFieldDef.Height)+","
				+    POut.Int   ((int)webForms_SheetFieldDef.GrowthBehavior)+","
				+"'"+POut.String(webForms_SheetFieldDef.RadioButtonValue)+"',"
				+"'"+POut.String(webForms_SheetFieldDef.RadioButtonGroup)+"',"
				+    POut.Bool  (webForms_SheetFieldDef.IsRequired)+","
				+    DbHelper.ParamChar+"paramImageData,"
				+    POut.Int   (webForms_SheetFieldDef.TabOrder)+","
				+"'"+POut.String(webForms_SheetFieldDef.ReportableName)+"',"
				+    POut.Int   ((int)webForms_SheetFieldDef.TextAlign)+","
				+    POut.Int   (webForms_SheetFieldDef.ItemColor.ToArgb())+","
				+    POut.Int   (webForms_SheetFieldDef.TabOrderMobile)+","
				+"'"+POut.String(webForms_SheetFieldDef.UiLabelMobile)+"',"
				+"'"+POut.String(webForms_SheetFieldDef.UiLabelMobileRadioButton)+"',"
				+"'"+POut.String(webForms_SheetFieldDef.Language)+"',"
				+    POut.Long  (webForms_SheetFieldDef.SheetFieldDefNum)+","
				+    POut.Bool  (webForms_SheetFieldDef.CanElectronicallySign)+","
				+    POut.Bool  (webForms_SheetFieldDef.IsSigProvRestricted)+")";
			if(webForms_SheetFieldDef.FieldValue==null) {
				webForms_SheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,webForms_SheetFieldDef.FieldValue);
			if(webForms_SheetFieldDef.ImageData==null) {
				webForms_SheetFieldDef.ImageData="";
			}
			OdSqlParameter paramImageData=new OdSqlParameter("paramImageData",OdDbType.Text,webForms_SheetFieldDef.ImageData);
			if(useExistingPK) {
				DataCore.NonQ(command,paramFieldValue,paramImageData);
			}
			else {
				webForms_SheetFieldDef.WebSheetFieldDefID=DataCore.NonQ(command,true,paramFieldValue,paramImageData);
			}
			return webForms_SheetFieldDef.WebSheetFieldDefID;
		}

		///<summary>Inserts many WebForms_SheetFieldDefs into the database.</summary>
		public static void InsertMany(List<WebForms_SheetFieldDef> listWebForms_SheetFieldDefs) {
			InsertMany(listWebForms_SheetFieldDefs,false);
		}

		///<summary>Inserts many WebForms_SheetFieldDefs into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<WebForms_SheetFieldDef> listWebForms_SheetFieldDefs,bool useExistingPK) {
			StringBuilder sbCommands=null;
			int index=0;
			int countRows=0;
			while(index < listWebForms_SheetFieldDefs.Count) {
				WebForms_SheetFieldDef webForms_SheetFieldDef=listWebForms_SheetFieldDefs[index];
				StringBuilder sbRow=new StringBuilder("(");
				bool hasComma=false;
				if(sbCommands==null) {
					sbCommands=new StringBuilder();
					sbCommands.Append("INSERT INTO webforms_sheetfielddef (");
					if(useExistingPK) {
						sbCommands.Append("WebSheetFieldDefID,");
					}
					sbCommands.Append("WebSheetDefID,FieldType,FieldName,FieldValue,FontSize,FontName,FontIsBold,XPos,YPos,Width,Height,GrowthBehavior,RadioButtonValue,RadioButtonGroup,IsRequired,ImageData,TabOrder,ReportableName,TextAlign,ItemColor,TabOrderMobile,UiLabelMobile,UiLabelMobileRadioButton,Language,SheetFieldDefNum,CanElectronicallySign,IsSigProvRestricted) VALUES ");
					countRows=0;
				}
				else {
					hasComma=true;
				}
				if(useExistingPK) {
					sbRow.Append(POut.Long(webForms_SheetFieldDef.WebSheetFieldDefID)); sbRow.Append(",");
				}
				sbRow.Append(POut.Long(webForms_SheetFieldDef.WebSheetDefID)); sbRow.Append(",");
				sbRow.Append(POut.Int((int)webForms_SheetFieldDef.FieldType)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.FieldName)+"'"); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.FieldValue)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Float(webForms_SheetFieldDef.FontSize)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.FontName)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_SheetFieldDef.FontIsBold)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.XPos)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.YPos)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.Width)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.Height)); sbRow.Append(",");
				sbRow.Append(POut.Int((int)webForms_SheetFieldDef.GrowthBehavior)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.RadioButtonValue)+"'"); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.RadioButtonGroup)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_SheetFieldDef.IsRequired)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.ImageData)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.TabOrder)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.ReportableName)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Int((int)webForms_SheetFieldDef.TextAlign)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.ItemColor.ToArgb())); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_SheetFieldDef.TabOrderMobile)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.UiLabelMobile)+"'"); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.UiLabelMobileRadioButton)+"'"); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_SheetFieldDef.Language)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Long(webForms_SheetFieldDef.SheetFieldDefNum)); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_SheetFieldDef.CanElectronicallySign)); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_SheetFieldDef.IsSigProvRestricted)); sbRow.Append(")");
				if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
					DataCore.NonQ(sbCommands.ToString());
					sbCommands=null;
				}
				else {
					if(hasComma) {
						sbCommands.Append(",");
					}
					sbCommands.Append(sbRow.ToString());
					countRows++;
					if(index==listWebForms_SheetFieldDefs.Count-1) {
						DataCore.NonQ(sbCommands.ToString());
					}
					index++;
				}
			}
		}

		///<summary>Updates one WebForms_SheetFieldDef in the database.</summary>
		public static void Update(WebForms_SheetFieldDef webForms_SheetFieldDef) {
			string command="UPDATE webforms_sheetfielddef SET "
				+"WebSheetDefID           =  "+POut.Long  (webForms_SheetFieldDef.WebSheetDefID)+", "
				+"FieldType               =  "+POut.Int   ((int)webForms_SheetFieldDef.FieldType)+", "
				+"FieldName               = '"+POut.String(webForms_SheetFieldDef.FieldName)+"', "
				+"FieldValue              =  "+DbHelper.ParamChar+"paramFieldValue, "
				+"FontSize                =  "+POut.Float (webForms_SheetFieldDef.FontSize)+", "
				+"FontName                = '"+POut.String(webForms_SheetFieldDef.FontName)+"', "
				+"FontIsBold              =  "+POut.Bool  (webForms_SheetFieldDef.FontIsBold)+", "
				+"XPos                    =  "+POut.Int   (webForms_SheetFieldDef.XPos)+", "
				+"YPos                    =  "+POut.Int   (webForms_SheetFieldDef.YPos)+", "
				+"Width                   =  "+POut.Int   (webForms_SheetFieldDef.Width)+", "
				+"Height                  =  "+POut.Int   (webForms_SheetFieldDef.Height)+", "
				+"GrowthBehavior          =  "+POut.Int   ((int)webForms_SheetFieldDef.GrowthBehavior)+", "
				+"RadioButtonValue        = '"+POut.String(webForms_SheetFieldDef.RadioButtonValue)+"', "
				+"RadioButtonGroup        = '"+POut.String(webForms_SheetFieldDef.RadioButtonGroup)+"', "
				+"IsRequired              =  "+POut.Bool  (webForms_SheetFieldDef.IsRequired)+", "
				+"ImageData               =  "+DbHelper.ParamChar+"paramImageData, "
				+"TabOrder                =  "+POut.Int   (webForms_SheetFieldDef.TabOrder)+", "
				+"ReportableName          = '"+POut.String(webForms_SheetFieldDef.ReportableName)+"', "
				+"TextAlign               =  "+POut.Int   ((int)webForms_SheetFieldDef.TextAlign)+", "
				+"ItemColor               =  "+POut.Int   (webForms_SheetFieldDef.ItemColor.ToArgb())+", "
				+"TabOrderMobile          =  "+POut.Int   (webForms_SheetFieldDef.TabOrderMobile)+", "
				+"UiLabelMobile           = '"+POut.String(webForms_SheetFieldDef.UiLabelMobile)+"', "
				+"UiLabelMobileRadioButton= '"+POut.String(webForms_SheetFieldDef.UiLabelMobileRadioButton)+"', "
				+"Language                = '"+POut.String(webForms_SheetFieldDef.Language)+"', "
				+"SheetFieldDefNum        =  "+POut.Long  (webForms_SheetFieldDef.SheetFieldDefNum)+", "
				+"CanElectronicallySign   =  "+POut.Bool  (webForms_SheetFieldDef.CanElectronicallySign)+", "
				+"IsSigProvRestricted     =  "+POut.Bool  (webForms_SheetFieldDef.IsSigProvRestricted)+" "
				+"WHERE WebSheetFieldDefID = "+POut.Long(webForms_SheetFieldDef.WebSheetFieldDefID);
			if(webForms_SheetFieldDef.FieldValue==null) {
				webForms_SheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,webForms_SheetFieldDef.FieldValue);
			if(webForms_SheetFieldDef.ImageData==null) {
				webForms_SheetFieldDef.ImageData="";
			}
			OdSqlParameter paramImageData=new OdSqlParameter("paramImageData",OdDbType.Text,webForms_SheetFieldDef.ImageData);
			DataCore.NonQ(command,paramFieldValue,paramImageData);
		}

		///<summary>Updates one WebForms_SheetFieldDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebForms_SheetFieldDef webForms_SheetFieldDef,WebForms_SheetFieldDef oldWebForms_SheetFieldDef) {
			string command="";
			if(webForms_SheetFieldDef.WebSheetDefID != oldWebForms_SheetFieldDef.WebSheetDefID) {
				if(command!="") { command+=",";}
				command+="WebSheetDefID = "+POut.Long(webForms_SheetFieldDef.WebSheetDefID)+"";
			}
			if(webForms_SheetFieldDef.FieldType != oldWebForms_SheetFieldDef.FieldType) {
				if(command!="") { command+=",";}
				command+="FieldType = "+POut.Int   ((int)webForms_SheetFieldDef.FieldType)+"";
			}
			if(webForms_SheetFieldDef.FieldName != oldWebForms_SheetFieldDef.FieldName) {
				if(command!="") { command+=",";}
				command+="FieldName = '"+POut.String(webForms_SheetFieldDef.FieldName)+"'";
			}
			if(webForms_SheetFieldDef.FieldValue != oldWebForms_SheetFieldDef.FieldValue) {
				if(command!="") { command+=",";}
				command+="FieldValue = "+DbHelper.ParamChar+"paramFieldValue";
			}
			if(webForms_SheetFieldDef.FontSize != oldWebForms_SheetFieldDef.FontSize) {
				if(command!="") { command+=",";}
				command+="FontSize = "+POut.Float(webForms_SheetFieldDef.FontSize)+"";
			}
			if(webForms_SheetFieldDef.FontName != oldWebForms_SheetFieldDef.FontName) {
				if(command!="") { command+=",";}
				command+="FontName = '"+POut.String(webForms_SheetFieldDef.FontName)+"'";
			}
			if(webForms_SheetFieldDef.FontIsBold != oldWebForms_SheetFieldDef.FontIsBold) {
				if(command!="") { command+=",";}
				command+="FontIsBold = "+POut.Bool(webForms_SheetFieldDef.FontIsBold)+"";
			}
			if(webForms_SheetFieldDef.XPos != oldWebForms_SheetFieldDef.XPos) {
				if(command!="") { command+=",";}
				command+="XPos = "+POut.Int(webForms_SheetFieldDef.XPos)+"";
			}
			if(webForms_SheetFieldDef.YPos != oldWebForms_SheetFieldDef.YPos) {
				if(command!="") { command+=",";}
				command+="YPos = "+POut.Int(webForms_SheetFieldDef.YPos)+"";
			}
			if(webForms_SheetFieldDef.Width != oldWebForms_SheetFieldDef.Width) {
				if(command!="") { command+=",";}
				command+="Width = "+POut.Int(webForms_SheetFieldDef.Width)+"";
			}
			if(webForms_SheetFieldDef.Height != oldWebForms_SheetFieldDef.Height) {
				if(command!="") { command+=",";}
				command+="Height = "+POut.Int(webForms_SheetFieldDef.Height)+"";
			}
			if(webForms_SheetFieldDef.GrowthBehavior != oldWebForms_SheetFieldDef.GrowthBehavior) {
				if(command!="") { command+=",";}
				command+="GrowthBehavior = "+POut.Int   ((int)webForms_SheetFieldDef.GrowthBehavior)+"";
			}
			if(webForms_SheetFieldDef.RadioButtonValue != oldWebForms_SheetFieldDef.RadioButtonValue) {
				if(command!="") { command+=",";}
				command+="RadioButtonValue = '"+POut.String(webForms_SheetFieldDef.RadioButtonValue)+"'";
			}
			if(webForms_SheetFieldDef.RadioButtonGroup != oldWebForms_SheetFieldDef.RadioButtonGroup) {
				if(command!="") { command+=",";}
				command+="RadioButtonGroup = '"+POut.String(webForms_SheetFieldDef.RadioButtonGroup)+"'";
			}
			if(webForms_SheetFieldDef.IsRequired != oldWebForms_SheetFieldDef.IsRequired) {
				if(command!="") { command+=",";}
				command+="IsRequired = "+POut.Bool(webForms_SheetFieldDef.IsRequired)+"";
			}
			if(webForms_SheetFieldDef.ImageData != oldWebForms_SheetFieldDef.ImageData) {
				if(command!="") { command+=",";}
				command+="ImageData = "+DbHelper.ParamChar+"paramImageData";
			}
			if(webForms_SheetFieldDef.TabOrder != oldWebForms_SheetFieldDef.TabOrder) {
				if(command!="") { command+=",";}
				command+="TabOrder = "+POut.Int(webForms_SheetFieldDef.TabOrder)+"";
			}
			if(webForms_SheetFieldDef.ReportableName != oldWebForms_SheetFieldDef.ReportableName) {
				if(command!="") { command+=",";}
				command+="ReportableName = '"+POut.String(webForms_SheetFieldDef.ReportableName)+"'";
			}
			if(webForms_SheetFieldDef.TextAlign != oldWebForms_SheetFieldDef.TextAlign) {
				if(command!="") { command+=",";}
				command+="TextAlign = "+POut.Int   ((int)webForms_SheetFieldDef.TextAlign)+"";
			}
			if(webForms_SheetFieldDef.ItemColor != oldWebForms_SheetFieldDef.ItemColor) {
				if(command!="") { command+=",";}
				command+="ItemColor = "+POut.Int(webForms_SheetFieldDef.ItemColor.ToArgb())+"";
			}
			if(webForms_SheetFieldDef.TabOrderMobile != oldWebForms_SheetFieldDef.TabOrderMobile) {
				if(command!="") { command+=",";}
				command+="TabOrderMobile = "+POut.Int(webForms_SheetFieldDef.TabOrderMobile)+"";
			}
			if(webForms_SheetFieldDef.UiLabelMobile != oldWebForms_SheetFieldDef.UiLabelMobile) {
				if(command!="") { command+=",";}
				command+="UiLabelMobile = '"+POut.String(webForms_SheetFieldDef.UiLabelMobile)+"'";
			}
			if(webForms_SheetFieldDef.UiLabelMobileRadioButton != oldWebForms_SheetFieldDef.UiLabelMobileRadioButton) {
				if(command!="") { command+=",";}
				command+="UiLabelMobileRadioButton = '"+POut.String(webForms_SheetFieldDef.UiLabelMobileRadioButton)+"'";
			}
			if(webForms_SheetFieldDef.Language != oldWebForms_SheetFieldDef.Language) {
				if(command!="") { command+=",";}
				command+="Language = '"+POut.String(webForms_SheetFieldDef.Language)+"'";
			}
			if(webForms_SheetFieldDef.SheetFieldDefNum != oldWebForms_SheetFieldDef.SheetFieldDefNum) {
				if(command!="") { command+=",";}
				command+="SheetFieldDefNum = "+POut.Long(webForms_SheetFieldDef.SheetFieldDefNum)+"";
			}
			if(webForms_SheetFieldDef.CanElectronicallySign != oldWebForms_SheetFieldDef.CanElectronicallySign) {
				if(command!="") { command+=",";}
				command+="CanElectronicallySign = "+POut.Bool(webForms_SheetFieldDef.CanElectronicallySign)+"";
			}
			if(webForms_SheetFieldDef.IsSigProvRestricted != oldWebForms_SheetFieldDef.IsSigProvRestricted) {
				if(command!="") { command+=",";}
				command+="IsSigProvRestricted = "+POut.Bool(webForms_SheetFieldDef.IsSigProvRestricted)+"";
			}
			if(command=="") {
				return false;
			}
			if(webForms_SheetFieldDef.FieldValue==null) {
				webForms_SheetFieldDef.FieldValue="";
			}
			OdSqlParameter paramFieldValue=new OdSqlParameter("paramFieldValue",OdDbType.Text,webForms_SheetFieldDef.FieldValue);
			if(webForms_SheetFieldDef.ImageData==null) {
				webForms_SheetFieldDef.ImageData="";
			}
			OdSqlParameter paramImageData=new OdSqlParameter("paramImageData",OdDbType.Text,webForms_SheetFieldDef.ImageData);
			command="UPDATE webforms_sheetfielddef SET "+command
				+" WHERE WebSheetFieldDefID = "+POut.Long(webForms_SheetFieldDef.WebSheetFieldDefID);
			DataCore.NonQ(command,paramFieldValue,paramImageData);
			return true;
		}

		///<summary>Deletes one WebForms_SheetFieldDef from the database.</summary>
		public static void Delete(long webSheetFieldDefID) {
			string command="DELETE FROM webforms_sheetfielddef "
				+"WHERE WebSheetFieldDefID = "+POut.Long(webSheetFieldDefID);
			DataCore.NonQ(command);
		}

	}
}