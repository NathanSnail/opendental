using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenDental.UI;
using OpenDentBusiness;

namespace OpenDental {
	public partial class FormMultiVisitGroup:FormODBase {

		/// <summary> If true, then this form removed one or more ProcMultiVisit items from the db </summary>
		public bool Changed=false;
		public List<ProcMultiVisit> ListChartModulePMV;
		public List<DataRow> ListDataRows;
		/// <summary> The function that builds a grid row for display, given an input DataRow </summary>
		public Func<DataRow,GridRow> FuncBuildGridRow;
		public List<GridColumn> GridColumns;
		public List<DisplayField> ListGridDisplayFields;
		public string GridTitle;

		public FormMultiVisitGroup() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormMultiVisitGroup_Load(object sender,EventArgs e) {
			FillGrid();
		}

		private void FillGrid() {
			gridGroupedProcs.BeginUpdate();
			gridGroupedProcs.ListGridRows.Clear();
			gridGroupedProcs.Columns.Clear();
			gridGroupedProcs.Title=GridTitle;
			for(int i=0;i<GridColumns.Count;i++) {
				gridGroupedProcs.Columns.Add(GridColumns[i]);
			}
			for(int i=0;i<ListDataRows.Count;i++) {
				GridRow gridRowFromDataRow=FuncBuildGridRow(ListDataRows[i]);
				gridGroupedProcs.ListGridRows.Add(gridRowFromDataRow);
			}
			gridGroupedProcs.EndUpdate();
			gridGroupedProcs.SetAll(true);//So the user can ungroup all when opening the form
		}

		private void gridGroupedProcs_Click(object sender,EventArgs e) {
			if(gridGroupedProcs.SelectedIndices.Length==0) {
				butUngroup.Enabled=false;
			}
			else {
				butUngroup.Enabled=true;
			}
		}

		private void butUngroup_Click(object sender,EventArgs e) {
			Changed=true;
			if(gridGroupedProcs.ListGridRows.Count-gridGroupedProcs.SelectedIndices.Length==1) {//One is not selected
				//Select all procedures in the form
				for(int i=0;i<gridGroupedProcs.ListGridRows.Count;i++) {
					gridGroupedProcs.SetSelected(i,true);
				}
			}
			//Get ProcNum of every procedure on the grid
			long[] arrayProcNumsAll=new long[gridGroupedProcs.ListGridRows.Count];
			for(int i = 0;i<gridGroupedProcs.ListGridRows.Count;i++) {
				DataRow row=(DataRow)gridGroupedProcs.ListGridRows[i].Tag;
				arrayProcNumsAll[i]=PIn.Long(row["ProcNum"].ToString());
			}
			List<ProcMultiVisit> listProcMultiVisitsForGroup=ProcMultiVisits.GetGroupsForProcsFromDb(arrayProcNumsAll);
			bool isGroupInProcessOld=ProcMultiVisits.IsGroupInProcess(listProcMultiVisitsForGroup);
			long groupProcMultiVisitNum=listProcMultiVisitsForGroup.First().GroupProcMultiVisitNum;
			//Get the ProcNum of each selected procedure
			long[] arraySelectedProcNums=new long[gridGroupedProcs.SelectedIndices.Length];
			for(int i=0;i<gridGroupedProcs.SelectedIndices.Length;i++) {
				DataRow row=(DataRow)gridGroupedProcs.ListGridRows[gridGroupedProcs.SelectedIndices[i]].Tag;
				arraySelectedProcNums[i]=PIn.Long(row["ProcNum"].ToString());
			}
			bool isInvalid=false;
			//Get the ProcMultiVisit associated with each procedure
			List<ProcMultiVisit> listProcMVs=listProcMultiVisitsForGroup.FindAll(x=>arraySelectedProcNums.Contains(x.ProcNum));
			for(int i=0;i<arraySelectedProcNums.Length;i++) {
				ProcMultiVisit pmv=listProcMVs.FirstOrDefault(x => x.ProcNum==arraySelectedProcNums[i]);
				if(pmv!=null) {//Could have been already ungrouped in another window/pc, possibly
					ProcMultiVisits.Delete(pmv.ProcMultiVisitNum);
					listProcMultiVisitsForGroup.RemoveAll(x => x.ProcMultiVisitNum==pmv.ProcMultiVisitNum);
					ListChartModulePMV.RemoveAll(x => x.ProcMultiVisitNum==pmv.ProcMultiVisitNum);
					isInvalid=true;
				}
				//Remove the procedure rows from this form
				ListDataRows.RemoveAll(row => PIn.Long(row["ProcNum"].ToString())==arraySelectedProcNums[i]);
			}
			//Check to see if the group is still in process after removals, updating the pmvs if so
			bool isGroupInProcess=ProcMultiVisits.IsGroupInProcess(listProcMultiVisitsForGroup);
			if(isGroupInProcessOld != isGroupInProcess) {
				ProcMultiVisits.UpdateInProcessForGroup(groupProcMultiVisitNum,isGroupInProcess);
			}
			//Signal that one or more ProcMultiVisit objects were removed from the DB
			if(isInvalid) {
				Signalods.SetInvalid(InvalidType.ProcMultiVisits);
			}
			ProcMultiVisits.RefreshCache();
			//Change status of claims if necessary
			List<ClaimProc> listClaimProcs=ClaimProcs.GetForProcs(arrayProcNumsAll.ToList());
			List<Claim> listClaims=Claims.GetClaimsFromClaimNums(listClaimProcs.Select(x=>x.ClaimNum).ToList());
			for(int i=0;i<listClaims.Count;i++) {
				Claim claimOld=listClaims[i].Copy();
				List<ClaimProc> listClaimProcsForClaim=ClaimProcs.RefreshForClaim(listClaims[i].ClaimNum);
				if(listClaimProcsForClaim.Count==0) {//This is rare but still happens.  See DBM. 
					break;
				}
				bool isProcsInProcess=listClaimProcsForClaim.Exists(x=>ProcMultiVisits.IsProcInProcess(x.ProcNum));
				if(isProcsInProcess) {
					listClaims[i].ClaimStatus="I";
				}
				else {
					listClaims[i].ClaimStatus="W";
					if(listClaims[i].ClaimType != "P") { //If this claim isn't primary, we need to see if a primary one is also attached to this procedure
						List<long> listProcNums=listClaimProcsForClaim.Select(x=>x.ProcNum).ToList();
						List<ClaimProc> listClaimProcsForProc=ClaimProcs.GetForProcs(listProcNums);
						List<Claim> listClaimsForClaimProcs=Claims.GetClaimsFromClaimNums(listClaimProcsForProc.Select(x=>x.ClaimNum).Distinct().ToList());
						if(listClaimsForClaimProcs.Exists(x=>x.ClaimType=="P")) { //If a primary claim is also attached
							listClaims[i].ClaimStatus="H"; //Set the status to Hold Until Pri Received instead of Waiting to Send
						}
					}
				}
				Claims.Update(listClaims[i],claimOld);
			}
			if(ListDataRows.Count==0) {
				MsgBox.Show(this,"All procedures removed from group.");
				Close();
			}
			else {
				MsgBox.Show(this,"Procedure(s) removed from group.");
				FillGrid();
			}
		}

		private void butClose_Click(object sender,EventArgs e) {
			Close();
		}
	}
}