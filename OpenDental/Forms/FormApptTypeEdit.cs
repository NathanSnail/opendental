using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenDentBusiness;
using OpenDentBusiness.UI;
using System.Linq;

namespace OpenDental {
	public partial class FormApptTypeEdit:FormODBase {
		public AppointmentType AppointmentTypeCur;
		private bool _isMouseDown;
		private Point _pointMouseOrigin;
		private Point _pointSliderOrigin;
		///<summary>The string time pattern in the current increment. Not in the 5 minute increment.</summary>
		private StringBuilder _stringBuilderTime;
		private System.Drawing.Color _colorProv;
		private List<ProcedureCode> _listProcedureCodes;

		public FormApptTypeEdit() {
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormApptTypeEdit_Load(object sender,EventArgs e) {
			textName.Text=AppointmentTypeCur.AppointmentTypeName;
			butColor.BackColor=AppointmentTypeCur.AppointmentTypeColor;
			checkIsHidden.Checked=AppointmentTypeCur.IsHidden;
			_listProcedureCodes=ProcedureCodes.GetFromCommaDelimitedList(AppointmentTypeCur.CodeStr);
			_colorProv=Color.Blue;
			_stringBuilderTime=new StringBuilder();
			if(AppointmentTypeCur.Pattern!=null) { //logic copied from FormApptEdit
				_stringBuilderTime=new StringBuilder(Appointments.ConvertPatternFrom5(AppointmentTypeCur.Pattern));
			}
			FillTime();
			RefreshListBoxProcCodes();
		}

		private void butColor_Click(object sender,EventArgs e) {
			using ColorDialog colorDialog=new ColorDialog();
			colorDialog.Color=butColor.BackColor;
			colorDialog.ShowDialog();
			butColor.BackColor=colorDialog.Color;
		}

		private void butColorClear_Click(object sender,EventArgs e) {
			butColor.BackColor=System.Drawing.Color.FromArgb(0);
		}

		private void butDelete_Click(object sender,EventArgs e) {
			if(AppointmentTypeCur.IsNew) {
				DialogResult=DialogResult.Cancel;
				return;
			}
			string msg=AppointmentTypes.CheckInUse(AppointmentTypeCur.AppointmentTypeNum);
			if(!string.IsNullOrWhiteSpace(msg)) {
				MsgBox.Show(this,msg);
				return;
			}
			if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Delete Appointment Type?")) {
				return;
			}
			AppointmentTypeCur=null;
			DialogResult=DialogResult.OK;
		}

		private void butSlider_MouseUp(object sender,System.Windows.Forms.MouseEventArgs e) {
			_isMouseDown=false;
		}
		private void butSlider_MouseDown(object sender,System.Windows.Forms.MouseEventArgs e) {
			_isMouseDown=true;
			_pointMouseOrigin=new Point(e.X+butSlider.Location.X,e.Y+butSlider.Location.Y);
			_pointSliderOrigin=butSlider.Location;
		}

		private void butSlider_MouseMove(object sender,System.Windows.Forms.MouseEventArgs e) {
			if(!_isMouseDown) {
				return;
			}
			//point represents the new location of button of smooth dragging.
			Point point=new Point(_pointSliderOrigin.X,_pointSliderOrigin.Y+(e.Y+butSlider.Location.Y)-_pointMouseOrigin.Y);
			int step=(int)(Math.Round((Decimal)(point.Y-tbTime.Location.Y)/14));
			if(step==_stringBuilderTime.Length) {
				return;
			}
			if(step<1) {
				return;
			}
			if(step>tbTime.MaxRows-1) {
				return;
			}
			if(step>_stringBuilderTime.Length) {
				_stringBuilderTime.Append('/');
			}
			if(step<_stringBuilderTime.Length) {
				_stringBuilderTime.Remove(step,1);
			}
			FillTime();
		}

		///<summary>Logic copied from FormApptEdit</summary>
		private void FillTime() {
			for(int i = 0;i<_stringBuilderTime.Length;i++) {
				tbTime.Cell[0,i]=_stringBuilderTime.ToString(i,1);
				tbTime.BackGColor[0,i]=Color.White;
			}
			for(int i = _stringBuilderTime.Length;i<tbTime.MaxRows;i++) {
				tbTime.Cell[0,i]="";
				tbTime.BackGColor[0,i]=Color.FromName("Control");
			}
			tbTime.Refresh();
			LayoutManager.MoveLocation(butSlider,new Point(tbTime.Location.X+2
				,(tbTime.Location.Y+_stringBuilderTime.Length*14+1)));
			if(_stringBuilderTime.Length>0) {
				textTime.Text=(_stringBuilderTime.Length*PrefC.GetInt(PrefName.AppointmentTimeIncrement)).ToString();
			}
			else {
				textTime.Text="Use procedure time pattern";
			}
		}

		private void tbTime_CellClicked(object sender,CellEventArgs e) {
			if(e.Row<_stringBuilderTime.Length) {
				if(_stringBuilderTime[e.Row]=='/') {
					_stringBuilderTime.Replace('/','X',e.Row,1);
				}
				else {
					_stringBuilderTime.Replace(_stringBuilderTime[e.Row],'/',e.Row,1);
				}
			}
			FillTime();
		}

		private void RefreshListBoxProcCodes() {
			listBoxProcCodes.Items.Clear();
			for(int i=0;i<_listProcedureCodes.Count;i++) {
				if(_listProcedureCodes[i].CodeNum==0) {//shouldn't happen but just in case
					continue;
				}
				listBoxProcCodes.Items.Add(_listProcedureCodes[i].ProcCode,_listProcedureCodes[i]);
			}
		}

		private void butAdd_Click(object sender,EventArgs e) {
			using FormProcCodes formProcCodes=new FormProcCodes();
			formProcCodes.IsSelectionMode=true;
			formProcCodes.AllowMultipleSelections=true;
			formProcCodes.ShowDialog();
			if(formProcCodes.DialogResult==DialogResult.OK) {
				_listProcedureCodes.AddRange(formProcCodes.ListSelectedProcCodes.Select(x => x.Copy()).ToList());
			}
			RefreshListBoxProcCodes();
		}

		private void butClear_Click(object sender,EventArgs e) {
			_stringBuilderTime.Clear();
			FillTime();
		}

		private void butRemove_Click(object sender,EventArgs e) {
			if(listBoxProcCodes.SelectedIndices.Count<1) {
				MsgBox.Show(this,"Please select the procedures you wish to remove.");
				return;
			}
			if(MsgBox.Show(this,MsgBoxButtons.OKCancel,"Remove selected procedure(s)?")) {
				List<ProcedureCode> listProcCodes=listBoxProcCodes.GetListSelected<ProcedureCode>();
				for(int i=0;i<listProcCodes.Count;i++) {
					_listProcedureCodes.Remove(listProcCodes[i]);
				}
				RefreshListBoxProcCodes();
			}
		}

		private void butOK_Click(object sender,EventArgs e) {
			AppointmentTypeCur.AppointmentTypeName=textName.Text;
			if(AppointmentTypeCur.AppointmentTypeColor!=butColor.BackColor) {
				AppointmentTypeCur.AppointmentTypeColor=butColor.BackColor;
				if(!AppointmentTypeCur.IsNew && MsgBox.Show(this,MsgBoxButtons.YesNo,"Would you like to update all future appointments of this type to the new color?")) {
					Appointments.UpdateFutureApptColorForApptType(AppointmentTypeCur);
				}
			}
			AppointmentTypeCur.IsHidden=checkIsHidden.Checked;
			AppointmentTypeCur.CodeStr=String.Join(",",_listProcedureCodes.Select(x => x.ProcCode));
			if(_stringBuilderTime.Length>0) {
				AppointmentTypeCur.Pattern=Appointments.ConvertPatternTo5(_stringBuilderTime.ToString());
			}
			else{
				AppointmentTypeCur.Pattern="";
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}