﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenDentBusiness;

namespace xCrudGenerator {
	public class PatientDataGenerator {
		private static List<EnumPdTable> _listPdTablesAll;

		public static void Generate(){
			string str=@"//This file is generated automatically by a button in the CrudGenerator
//Do not edit this file manually.
//Jordan is involved in the code generation because he's the only one allowed to edit PatientData.
//Last generated on "+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToShortTimeString()+@"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace OpenDentBusiness {
	public partial class PatientData {
		#region Fields - Public"+"\r\n";
			_listPdTablesAll=((EnumPdTable[])Enum.GetValues(typeof(EnumPdTable))).ToList();
			for(int i=0;i<_listPdTablesAll.Count;i++){
				if(_listPdTablesAll[i]==EnumPdTable.OrthoChart){
					str+="		public List<OrthoChartRow> ListOrthoChartRows;\r\n";
				}
				if(_listPdTablesAll[i]==EnumPdTable.Patient){
					str+="		///<summary>Guarantor is first.</summary>\r\n";
				}
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				if(_listPdTablesAll[i]==EnumPdTable.PatientSuperFamHead){
					str+="		public Patient PatientSuperFamHead;\r\n";
				}
				else if(_listPdTablesAll[i]==EnumPdTable.UserWebHasPortalAccess){
					str+="		public bool UserWebHasPortalAccess;\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.SingleObject){
					str+="		public "+_listPdTablesAll[i].ToString()+" "+_listPdTablesAll[i].ToString()+";\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.Table){
					str+="		[XmlIgnore]\r\n";
					str+="		public DataTable "+_listPdTablesAll[i].ToString()+";\r\n";
				}
				else{//list
					str+="		public List<"+_listPdTablesAll[i].ToString()+"> List"+GetPlural(_listPdTablesAll[i])+";\r\n";
				}
			}
			str+=@"		#endregion Fields - Public

		#region Properties
";
			bool firstRowGenerated=false;
			for(int i=0;i<_listPdTablesAll.Count;i++){
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				if(pdFieldType!=EnumPdFieldType.Table){
					continue;
				}
				if(firstRowGenerated){
					str+="\r\n";
				}
				str+=@"		[XmlElement(nameof("+_listPdTablesAll[i].ToString()+@"))]
		public string "+_listPdTablesAll[i].ToString()+@"Xml {
			get {
				if("+_listPdTablesAll[i].ToString()+@"==null) {
					return null;
				}
				return XmlConverter.TableToXml("+_listPdTablesAll[i].ToString()+@");
			}
			set {
				if(value==null) {
					"+_listPdTablesAll[i].ToString()+@"Xml=null;
					return;
				}
				"+_listPdTablesAll[i].ToString()+@"=XmlConverter.XmlToTable(value);
			}
		}
";
				firstRowGenerated=true;
			}//end of for loop
			str+=@"		#endregion Properties

		#region Methods - Public
		///<summary>Instead of ClearAll, you can clear specific lists to mark them as stale. It's usually easier to use ClearAll.</summary>
		public void Clear(params EnumPdTable[] pdTableArray){
			//No need to check MiddleTierRole; no call to db."+"\r\n";
			for(int i=0;i<_listPdTablesAll.Count;i++){
				if(_listPdTablesAll[i]==EnumPdTable.UserWebHasPortalAccess){
					continue;
				}
				str+="			if(pdTableArray.Contains(EnumPdTable."+_listPdTablesAll[i].ToString()+")){\r\n";
				if(_listPdTablesAll[i]==EnumPdTable.OrthoChart){
					str+="				ListOrthoChartRows=null;\r\n";
				}
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				if(pdFieldType==EnumPdFieldType.SingleObject){
					str+="				"+_listPdTablesAll[i].ToString()+"=null;\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.Table){
					str+="				"+_listPdTablesAll[i].ToString()+"=null;\r\n";
				}
				else{//list
					str+="				List"+GetPlural(_listPdTablesAll[i])+"=null;\r\n";
				}
				str+="			}\r\n";
			}
			str+=@"		}

";
			for(int i=0;i<Enum.GetValues(typeof(EnumPdComplexGetter)).Length;i++){
				if(i>0){
					str+="\r\n";
				}
				str+=GenerateFillIfNeeded((EnumPdComplexGetter)i);
			}
			str+=@"		#endregion Methods - Public

		#region Methods - Public Static
";
			for(int i=0;i<Enum.GetValues(typeof(EnumPdComplexGetter)).Length;i++){
				if(i>0){
					str+="\r\n";
				}
				str+=GenerateGetFromDb((EnumPdComplexGetter)i);

			}
			str+=@"		#endregion Methods - Public Static

		#region Methods - Private Static
";
			str+=GenerateGetFromDbHelper();
			str+=@"		#endregion Methods - Private Static

		#region Methods - Private
";
			str+=GenerateFillHelpers();
			str+=@"		#endregion Methods - Private
	}
}";
			File.WriteAllText(@"..\..\..\OpenDentBusiness\Db Multi Table\PatientDataGenerated.cs",str);
		}

		private static string GenerateFillIfNeeded(EnumPdComplexGetter complexGetter){
			string str="";
			if(complexGetter==EnumPdComplexGetter.None){
				str+=@"		///<summary>This is how you notify PatientData exactly what data you will need. If the specified Lists already have data, it will do nothing. If any are null, it will refresh those from db. After this, all the lists that you specified will be guaranteed to not be null.</summary>
		public void FillIfNeeded(params EnumPdTable[] pdTableArray){
";
			}
			if(complexGetter==EnumPdComplexGetter.ChartProgressNotes){
				str+=@"		///<summary>This is a version of FillIfNeeded that's specific to Chart module when getting Progress Notes table.</summary>
		public void FillIfNeededChart(bool isAuditMode,ChartModuleFilters chartModuleFilters,params EnumPdTable[] pdTableArray){
";
			}
			str+=@"			//No need to check MiddleTierRole; no call to db.
			if(PatNum==0){
				//this is fairly unlikely to happen. It would be more common to forget to change the PatNum, so it would still be using an old one.
				throw new ApplicationException(""Set PatNum first."");
			}
			List<EnumPdTable> listPdTablesFiltered=FilterPdTables(pdTableArray);
";
			if(complexGetter==EnumPdComplexGetter.None){
				str+="			PatientData patientData=GetFromDb(PatNum,listPdTablesFiltered);\r\n";
			}
			if(complexGetter==EnumPdComplexGetter.ChartProgressNotes){
				str+="			PatientData patientData=GetFromDbChartProgNotes(PatNum,listPdTablesFiltered,isAuditMode,chartModuleFilters);\r\n";
			}
			str+=@"			CopyDataToOurPd(patientData,listPdTablesFiltered);
		}
";
			return str;
		}

		private static string GenerateFillHelpers(){
			string str=@"		///<summary></summary>
		private List<EnumPdTable> FilterPdTables(EnumPdTable[] pdTableArray){
			List<EnumPdTable> listPdTables=new List<EnumPdTable>();"+"\r\n";
			for(int i=0;i<_listPdTablesAll.Count;i++){
				str+="			if(pdTableArray.Contains(EnumPdTable."+_listPdTablesAll[i].ToString()+")";
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				if(_listPdTablesAll[i]==EnumPdTable.UserWebHasPortalAccess){
					str+="){\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.SingleObject){
					str+=" && "+_listPdTablesAll[i].ToString()+" is null){\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.Table){
					str+=" && "+_listPdTablesAll[i].ToString()+" is null){\r\n";
				}
				else{//list
					str+=" && List"+GetPlural(_listPdTablesAll[i])+" is null){\r\n";
				}
				str+="				listPdTables.Add(EnumPdTable."+_listPdTablesAll[i].ToString()+");\r\n";
				str+="			}\r\n";
			}
			str+=@"			return listPdTables;
		}

		///<summary></summary>
		private void CopyDataToOurPd(PatientData patientData,List<EnumPdTable> listPdTables){
";
			for(int i=0;i<_listPdTablesAll.Count;i++){
				str+="			if(listPdTables.Contains(EnumPdTable."+_listPdTablesAll[i].ToString()+")){\r\n";
				if(_listPdTablesAll[i]==EnumPdTable.OrthoChart){
					str+="				ListOrthoChartRows=new List<OrthoChartRow>(patientData.ListOrthoChartRows);\r\n";
				}
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				if(pdFieldType==EnumPdFieldType.SingleObject){
					str+="				"+_listPdTablesAll[i].ToString()+"=patientData."+_listPdTablesAll[i].ToString()+";\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.Table){
					str+="				"+_listPdTablesAll[i].ToString()+"=patientData."+_listPdTablesAll[i].ToString()+";\r\n";
				}
				else{
					string plural=GetPlural(_listPdTablesAll[i]);
					str+="				List"+plural+"=new List<"+_listPdTablesAll[i].ToString()+">(patientData.List"+plural+");\r\n";
				}
				if(_listPdTablesAll[i]==EnumPdTable.Patient){
					str+="				Patient=ListPatients.Find(x=>x.PatNum==PatNum);\r\n";
					str+="				Family=new Family(ListPatients);\r\n";
				}
				str+="			}\r\n";
			}
			str+="		}\r\n";
			return str;
		}
		
		private static string GenerateGetFromDb(EnumPdComplexGetter complexGetter){
			string str="";
			if(complexGetter==EnumPdComplexGetter.None){
				str+=@"		///<summary>The PatientData that comes back here is a totally different one than the main PatientData. It will only have a few lists in it, and those lists will get copied over to the main PatientData. This just gets simpler data that doesn't need additional parameters.</summary>
		public static PatientData GetFromDb(long patNum,List<EnumPdTable> listPdTables){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<PatientData>(MethodBase.GetCurrentMethod(),patNum,listPdTables);
			}
";
			}
			if(complexGetter==EnumPdComplexGetter.ChartProgressNotes){
				str+=@"		///<summary>This is separate from GetFromDb because it requires additional parameters. It can also get any simple data that doesn't need complex parameters.</summary>
		public static PatientData GetFromDbChartProgNotes(long patNum,List<EnumPdTable> listPdTables,bool isAuditMode,ChartModuleFilters chartModuleFilters){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				return Meth.GetObject<PatientData>(MethodBase.GetCurrentMethod(),patNum,listPdTables,isAuditMode,chartModuleFilters);
			}
";
			}
			str+="			PatientData patientData=new PatientData();\r\n";
			if(complexGetter==EnumPdComplexGetter.ChartProgressNotes){
				str+="			patientData.TableProgNotes=ChartModules.GetProgNotes(patNum,isAuditMode,chartModuleFilters);//this must come before ChartModules.GetPlannedApt\r\n";
			}
			str+="			GetFromDbSimple(patNum,listPdTables,patientData);\r\n";
			str+=@"			return patientData;
		}	
";
			return str;
		}

		private static string GenerateGetFromDbHelper(){
			string str=@"///<summary>This gets all the simple lists that don't need additional parameters.</summary>
		public static void GetFromDbSimple(long patNum,List<EnumPdTable> listPdTables,PatientData patientData){
";
			for(int i=0;i<_listPdTablesAll.Count;i++){
				EnumPdComplexGetter complexGetter=GetComplexGetter(_listPdTablesAll[i]);
				if(complexGetter!=EnumPdComplexGetter.None){
					//we only get the simple data here. No complex getters.
					continue;
				}
				string parameters="patNum";
				if(_listPdTablesAll[i]==EnumPdTable.PatientNote){
					parameters="patNum,patientData.ListPatients[0].Guarantor";
				}
				if(_listPdTablesAll[i]==EnumPdTable.InsSub){
					parameters="patientData.ListPatients";
				}
				if(_listPdTablesAll[i]==EnumPdTable.InsPlan){
					parameters="patientData.ListInsSubs";
				}
				if(_listPdTablesAll[i]==EnumPdTable.Benefit){
					parameters="patientData.ListPatPlans,patientData.ListInsSubs";
				}
				if(_listPdTablesAll[i]==EnumPdTable.ClaimProcHist){
					parameters="patNum,patientData.ListBenefits,patientData.ListPatPlans,patientData.ListInsPlans,patientData.ListInsSubs";
				}
				str+="			if(listPdTables.Contains(EnumPdTable."+_listPdTablesAll[i].ToString()+")){\r\n";
				if(_listPdTablesAll[i]==EnumPdTable.OrthoChart){
					str+="				patientData.ListOrthoChartRows=OrthoChartRows.GetPatientData(patNum);\r\n";
				}
				EnumPdFieldType pdFieldType=GetPdFieldType(_listPdTablesAll[i]);
				string plural=GetPlural(_listPdTablesAll[i]);
				if(_listPdTablesAll[i]==EnumPdTable.PatientSuperFamHead){
					str+="				if(patientData.ListPatients[0].SuperFamily!=0){\r\n";
					str+="					patientData."+_listPdTablesAll[i].ToString()+"=Patients.GetPat(patientData.ListPatients[0].SuperFamily);\r\n";
					str+="				}\r\n";
				}
				else if(_listPdTablesAll[i]==EnumPdTable.UserWebHasPortalAccess){
					str+="				patientData."+_listPdTablesAll[i].ToString()+"=UserWebs.HasPatientPortalAccess("+parameters+");\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.SingleObject){
					str+="				patientData."+_listPdTablesAll[i].ToString()+"="+plural+".GetPatientData("+parameters+");\r\n";
				}
				else if(pdFieldType==EnumPdFieldType.Table){
					if(_listPdTablesAll[i]==EnumPdTable.TablePlannedAppts){
						str+="				patientData."+_listPdTablesAll[i].ToString()+"=ChartModules.GetPlannedApt("+parameters+");\r\n";
					}
					else{
						str+="				patientData."+_listPdTablesAll[i].ToString()+"="+plural+".GetPatientData("+parameters+");\r\n";
					}
				}
				else if(_listPdTablesAll[i]==EnumPdTable.ClaimProcHist){
					str+="				patientData.List"+plural+"=ClaimProcs.GetPatientData("+parameters+");\r\n";
				}
				else{//list
					str+="				patientData.List"+plural+"="+plural+".GetPatientData("+parameters+");\r\n";
				}
				str+="			}\r\n";
			}
			str+="		}\r\n";
			return str;
		}

		private static EnumPdFieldType GetPdFieldType(EnumPdTable pdTable){
				Type type=pdTable.GetType();
				MemberInfo[] memberInfoArray=type.GetMember(pdTable.ToString());
				List<Attribute> listAttributes=memberInfoArray[0].GetCustomAttributes(typeof(PdMeta)).ToList();
				EnumPdFieldType pdFieldType=EnumPdFieldType.List;
				if(listAttributes.Count>0 && listAttributes[0] is PdMeta pdMeta){
					pdFieldType=pdMeta.FieldType;
				}
				return pdFieldType;				
		}

		private static EnumPdComplexGetter GetComplexGetter(EnumPdTable pdTable){
				Type type=pdTable.GetType();
				MemberInfo[] memberInfoArray=type.GetMember(pdTable.ToString());
				List<Attribute> listAttributes=memberInfoArray[0].GetCustomAttributes(typeof(PdMeta)).ToList();
				EnumPdComplexGetter complexGetter=EnumPdComplexGetter.None;
				if(listAttributes.Count>0 && listAttributes[0] is PdMeta pdMeta){
					complexGetter=pdMeta.ComplexGetter;
				}
				return complexGetter;				
		}

		private static string GetPlural(EnumPdTable pdTable){
				Type type=pdTable.GetType();
				MemberInfo[] memberInfoArray=type.GetMember(pdTable.ToString());
				List<Attribute> listAttributes=memberInfoArray[0].GetCustomAttributes(typeof(PdMeta)).ToList();
				string plural=pdTable.ToString()+"s";
				if(listAttributes.Count>0 && listAttributes[0] is PdMeta pdMeta){
					if(pdMeta.Plural!=null){
						plural=pdMeta.Plural;
					}
				}
				return plural;				
		}

	}
}
