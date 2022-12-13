using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using CodeBase;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormInsHistSetup:FormODBase {
		private Patient _patient;
		///<summary></summary>
		private Dictionary<PrefName,Procedure> _dictionaryPrefNameProcedures;
		private InsSub _insSub;
		///<summary></summary>
		private List<ClaimProc> _listClaimProcs;
		private const string NO_INSHIST="No History";
		private const string NO_INSHISTSET="Not Set";

		//1. Find claiprocs for current plan
		//2. Find EO and C procs for claimprocs on current plan
		//3. Only have procs on this insplan that are EO and C
		//4. Fill in date info based on EO or C proc list
		//5. On OK click, fetch all claimprocs for EO and C procs
			//5a. Date filled, no matching EO or C proc - User entered date themselves, make new proc with claimproc status inshist
			//5b. Date filled, matching EO or C proc and user changed the date.- 
				//Modify proc and claimproc for that category ONLY if the proc has a status of EO to be the date specified
				//If the proc has a status of C and the new date is greater than the the current ProcDate, create a new EO procedure and InsHist ClaimProc with the new date entered.
			//5c. No date, no proc - Do nothing
			//5d. No date, matching EO or C proc - User erased the date, delete proc/claimproc ONLY if proc has a status of EO.


		public FormInsHistSetup(long patNum,InsSub insSub) {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
			_patient=Patients.GetPat(patNum);
			_insSub=insSub;
			_dictionaryPrefNameProcedures=Procedures.GetDictInsHistProcs(patNum,insSub.InsSubNum,out _listClaimProcs);
		}

		private void FormInsHistSetup_Load(object sender,EventArgs e) {
			FillDates();
		}

		/// <summary>Returns the text box control corresponding to the given procType</summary>
		private void FillDates() {
			List<Pref> listPrefs= Prefs.GetInsHistPrefs();
			string text=NO_INSHIST;
			List<PrefName> listPrefNames = Prefs.GetInsHistPrefNames();
			for(int i=0;i<listPrefNames.Count;i++){
				Procedure procedure=_dictionaryPrefNameProcedures[listPrefNames[i]];
				ClaimProc claimProc=null;
				if(procedure!=null) {
					claimProc=_listClaimProcs.Find(x => x.InsSubNum==_insSub.InsSubNum && x.Status.In(ClaimProcStatus.InsHist,ClaimProcStatus.Received)
						&& x.ProcNum==procedure.ProcNum);
				}
				if(claimProc!=null && procedure!=null && procedure.ProcDate.Year>1880) {
					text=procedure.ProcDate.ToShortDateString();
				}
				else {
					text = NO_INSHIST;
				}
				bool isPrefSet=listPrefs.Exists(x => x.PrefName==listPrefNames[i].ToString() && !string.IsNullOrWhiteSpace(x.ValueString));
				TextBox textBox=GetControlForPrefName(listPrefNames[i]);
				if(!isPrefSet) {
					text=NO_INSHISTSET;
					textBox.Enabled=false;
				}
				textBox.Text=text;
			}
		}
		
		///<summary>Returns the text box control corresponding to the given procType</summary>
		private TextBox GetControlForPrefName(PrefName prefName) {
			switch(prefName) {
				case PrefName.InsHistExamCodes:
					return textDateExam;
				case PrefName.InsHistProphyCodes:
					return textDateProphy;
				case PrefName.InsHistBWCodes:
					return textDateBW;
				case PrefName.InsHistPanoCodes:
					return textDateFmxPano;
				case PrefName.InsHistPerioURCodes:
					return textDatePerioScalingUR;
				case PrefName.InsHistPerioULCodes:
					return textDatePerioScalingUL;
				case PrefName.InsHistPerioLRCodes:
					return textDatePerioScalingLR;
				case PrefName.InsHistPerioLLCodes:
					return textDatePerioScalingLL;
				case PrefName.InsHistPerioMaintCodes:
					return textDatePerioMaint;
				case PrefName.InsHistDebridementCodes:
					return textDateDebridgement;
				default:
					return null;
			}
		}

		///<summary></summary>
		private bool IsValid() {
			DateTime dateEntry;
			List<PrefName> listPrefNames = Prefs.GetInsHistPrefNames();
			for(int i=0;i<listPrefNames.Count;i++){
				TextBox textBox=GetControlForPrefName(listPrefNames[i]);
				//Continue if no date is entered or the date entered is valid.
				if(!textBox.Enabled || string.IsNullOrEmpty(textBox.Text) || textBox.Text.Trim()==NO_INSHIST) {
					continue;
				}
				if(!DateTime.TryParse(textBox.Text,out dateEntry)) {
					//Invalid date entered.
					MsgBox.Show(this,"Invalid date");
					return false;
				}
				if(dateEntry.Year<1880 || dateEntry.Year>2100) {
					MsgBox.Show("Invalid date. Valid dates between 1880 and 2100");
					return false;
				}
			}
			return true;
		}

		private void TextBoxValidating(object sender,System.ComponentModel.CancelEventArgs e) {
			if(sender.GetType()!=typeof(TextBox)) {
				return;
			}
			TextBox textBox=(TextBox)sender;
			//If its disabled, empty or the default text return.
			if(!textBox.Enabled || string.IsNullOrEmpty(textBox.Text) || textBox.Text.Trim()==NO_INSHIST) {
				return;
			}
			bool allNums=true;
			for(int i=0;i<textBox.Text.Length;i++) {
				if(!Char.IsNumber(textBox.Text,i)) {
					allNums=false;
				}
			}
			if(CultureInfo.CurrentCulture.TwoLetterISOLanguageName=="en") {
				if(allNums) {
					if(textBox.Text.Length==6) {
						textBox.Text=textBox.Text.Substring(0,2)+"/"+textBox.Text.Substring(2,2)+"/"+textBox.Text.Substring(4,2);
					}
					else if(textBox.Text.Length==8) {
						textBox.Text=textBox.Text.Substring(0,2)+"/"+textBox.Text.Substring(2,2)+"/"+textBox.Text.Substring(4,4);
					}
				}
			}
			try {
				textBox.Text=DateTime.Parse(textBox.Text).ToString("d");//will throw exception if invalid
			}
			catch(Exception ex) {
				//We don't want a full exception, just a popup.  OK_Click will block them from putting invalid data in the db.
				ex.DoNothing();
				MsgBox.Show(this,"Invalid date.");
				return;
			}
			if(DateTime.Parse(textBox.Text).Year<1880 || DateTime.Parse(textBox.Text).Year>2100) {
				MsgBox.Show("Valid dates between 1880 and 2100");
				return;
			}
		}

		private void butOK_Click(object sender,EventArgs e) {
			if(!IsValid()) {
				return;
			}
			string error="";
			List<Procedure> listProcedures=new List<Procedure>();
			List<PrefName> listPrefNames = Prefs.GetInsHistPrefNames();
			for(int i=0;i<listPrefNames.Count;i++){
				TextBox textBox=GetControlForPrefName(listPrefNames[i]);
				if(!textBox.Enabled || textBox.Text.Trim()==NO_INSHIST) {
					continue;
				}
				Procedure procedure=_dictionaryPrefNameProcedures[listPrefNames[i]];
				if(string.IsNullOrWhiteSpace(textBox.Text)) {
					if(procedure!=null && procedure.ProcStatus==ProcStat.EO) {//Only delete EO procedures
						listProcedures.Add(procedure);//Delete proc if user deleted procedure date from textbox.
					}
					continue;
				}
				DateTime dateEntered=PIn.Date(textBox.Text);
				List<ClaimProc> listClaimProcs=new List<ClaimProc>();
				if(procedure!=null) {
					//Get all of the claimprocs for this procedure.
					listClaimProcs=_listClaimProcs.FindAll(x => x.ProcNum==procedure.ProcNum);
				}
				if(ProcedureCodes.GetByInsHistPref(listPrefNames[i]).CodeNum==0) {
					error="One or more insurance history preferences has an invaid procedure code. Please check in the Treatment Plan module preferences for any invalid codes.";
					continue;//Don't create an Existing Other procedure log for an invalid code
				}
				Procedures.InsertOrUpdateInsHistProcedure(_patient,listPrefNames[i],dateEntered,_insSub.PlanNum,_insSub.InsSubNum,procedure,listClaimProcs);
			}
			if(listProcedures.Count>0
				&& !MsgBox.Show(this,MsgBoxButtons.YesNo,"Deleting the last procedure date for a category will delete the Existing Other procedure with that date for this patient.  Continue?"))
			{
				return;
			}
			for(int i=0;i<listProcedures.Count;i++){
				try {
					Procedures.Delete(listProcedures[i].ProcNum);
				}
				catch(Exception ex) {
					//Tried deleting the procedure. Do nothing. 
					ex.DoNothing();
				}
			}
			if(!error.IsNullOrEmpty()) {
				MsgBox.Show(error);
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}