//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EmployeeCrud {
		///<summary>Gets one Employee object from the database using the primary key.  Returns null if not found.</summary>
		public static Employee SelectOne(long employeeNum) {
			string command="SELECT * FROM employee "
				+"WHERE EmployeeNum = "+POut.Long(employeeNum);
			List<Employee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Employee object from the database using a query.</summary>
		public static Employee SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Employee> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Employee objects from the database using a query.</summary>
		public static List<Employee> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Employee> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Employee> TableToList(DataTable table) {
			List<Employee> retVal=new List<Employee>();
			Employee employee;
			foreach(DataRow row in table.Rows) {
				employee=new Employee();
				employee.EmployeeNum  = PIn.Long  (row["EmployeeNum"].ToString());
				employee.LName        = PIn.String(row["LName"].ToString());
				employee.FName        = PIn.String(row["FName"].ToString());
				employee.MiddleI      = PIn.String(row["MiddleI"].ToString());
				employee.IsHidden     = PIn.Bool  (row["IsHidden"].ToString());
				employee.ClockStatus  = PIn.String(row["ClockStatus"].ToString());
				employee.PhoneExt     = PIn.Int   (row["PhoneExt"].ToString());
				employee.PayrollID    = PIn.String(row["PayrollID"].ToString());
				employee.WirelessPhone= PIn.String(row["WirelessPhone"].ToString());
				employee.EmailWork    = PIn.String(row["EmailWork"].ToString());
				employee.EmailPersonal= PIn.String(row["EmailPersonal"].ToString());
				employee.IsFurloughed = PIn.Bool  (row["IsFurloughed"].ToString());
				employee.IsWorkingHome= PIn.Bool  (row["IsWorkingHome"].ToString());
				employee.ReportsTo    = PIn.Long  (row["ReportsTo"].ToString());
				retVal.Add(employee);
			}
			return retVal;
		}

		///<summary>Converts a list of Employee into a DataTable.</summary>
		public static DataTable ListToTable(List<Employee> listEmployees,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Employee";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EmployeeNum");
			table.Columns.Add("LName");
			table.Columns.Add("FName");
			table.Columns.Add("MiddleI");
			table.Columns.Add("IsHidden");
			table.Columns.Add("ClockStatus");
			table.Columns.Add("PhoneExt");
			table.Columns.Add("PayrollID");
			table.Columns.Add("WirelessPhone");
			table.Columns.Add("EmailWork");
			table.Columns.Add("EmailPersonal");
			table.Columns.Add("IsFurloughed");
			table.Columns.Add("IsWorkingHome");
			table.Columns.Add("ReportsTo");
			foreach(Employee employee in listEmployees) {
				table.Rows.Add(new object[] {
					POut.Long  (employee.EmployeeNum),
					            employee.LName,
					            employee.FName,
					            employee.MiddleI,
					POut.Bool  (employee.IsHidden),
					            employee.ClockStatus,
					POut.Int   (employee.PhoneExt),
					            employee.PayrollID,
					            employee.WirelessPhone,
					            employee.EmailWork,
					            employee.EmailPersonal,
					POut.Bool  (employee.IsFurloughed),
					POut.Bool  (employee.IsWorkingHome),
					POut.Long  (employee.ReportsTo),
				});
			}
			return table;
		}

		///<summary>Inserts one Employee into the database.  Returns the new priKey.</summary>
		public static long Insert(Employee employee) {
			return Insert(employee,false);
		}

		///<summary>Inserts one Employee into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Employee employee,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				employee.EmployeeNum=ReplicationServers.GetKey("employee","EmployeeNum");
			}
			string command="INSERT INTO employee (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmployeeNum,";
			}
			command+="LName,FName,MiddleI,IsHidden,ClockStatus,PhoneExt,PayrollID,WirelessPhone,EmailWork,EmailPersonal,IsFurloughed,IsWorkingHome,ReportsTo) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(employee.EmployeeNum)+",";
			}
			command+=
				 "'"+POut.String(employee.LName)+"',"
				+"'"+POut.String(employee.FName)+"',"
				+"'"+POut.String(employee.MiddleI)+"',"
				+    POut.Bool  (employee.IsHidden)+","
				+"'"+POut.String(employee.ClockStatus)+"',"
				+    POut.Int   (employee.PhoneExt)+","
				+"'"+POut.String(employee.PayrollID)+"',"
				+"'"+POut.String(employee.WirelessPhone)+"',"
				+"'"+POut.String(employee.EmailWork)+"',"
				+"'"+POut.String(employee.EmailPersonal)+"',"
				+    POut.Bool  (employee.IsFurloughed)+","
				+    POut.Bool  (employee.IsWorkingHome)+","
				+    POut.Long  (employee.ReportsTo)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				employee.EmployeeNum=Db.NonQ(command,true,"EmployeeNum","employee");
			}
			return employee.EmployeeNum;
		}

		///<summary>Inserts one Employee into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Employee employee) {
			return InsertNoCache(employee,false);
		}

		///<summary>Inserts one Employee into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Employee employee,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO employee (";
			if(!useExistingPK && isRandomKeys) {
				employee.EmployeeNum=ReplicationServers.GetKeyNoCache("employee","EmployeeNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EmployeeNum,";
			}
			command+="LName,FName,MiddleI,IsHidden,ClockStatus,PhoneExt,PayrollID,WirelessPhone,EmailWork,EmailPersonal,IsFurloughed,IsWorkingHome,ReportsTo) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(employee.EmployeeNum)+",";
			}
			command+=
				 "'"+POut.String(employee.LName)+"',"
				+"'"+POut.String(employee.FName)+"',"
				+"'"+POut.String(employee.MiddleI)+"',"
				+    POut.Bool  (employee.IsHidden)+","
				+"'"+POut.String(employee.ClockStatus)+"',"
				+    POut.Int   (employee.PhoneExt)+","
				+"'"+POut.String(employee.PayrollID)+"',"
				+"'"+POut.String(employee.WirelessPhone)+"',"
				+"'"+POut.String(employee.EmailWork)+"',"
				+"'"+POut.String(employee.EmailPersonal)+"',"
				+    POut.Bool  (employee.IsFurloughed)+","
				+    POut.Bool  (employee.IsWorkingHome)+","
				+    POut.Long  (employee.ReportsTo)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				employee.EmployeeNum=Db.NonQ(command,true,"EmployeeNum","employee");
			}
			return employee.EmployeeNum;
		}

		///<summary>Updates one Employee in the database.</summary>
		public static void Update(Employee employee) {
			string command="UPDATE employee SET "
				+"LName        = '"+POut.String(employee.LName)+"', "
				+"FName        = '"+POut.String(employee.FName)+"', "
				+"MiddleI      = '"+POut.String(employee.MiddleI)+"', "
				+"IsHidden     =  "+POut.Bool  (employee.IsHidden)+", "
				+"ClockStatus  = '"+POut.String(employee.ClockStatus)+"', "
				+"PhoneExt     =  "+POut.Int   (employee.PhoneExt)+", "
				+"PayrollID    = '"+POut.String(employee.PayrollID)+"', "
				+"WirelessPhone= '"+POut.String(employee.WirelessPhone)+"', "
				+"EmailWork    = '"+POut.String(employee.EmailWork)+"', "
				+"EmailPersonal= '"+POut.String(employee.EmailPersonal)+"', "
				+"IsFurloughed =  "+POut.Bool  (employee.IsFurloughed)+", "
				+"IsWorkingHome=  "+POut.Bool  (employee.IsWorkingHome)+", "
				+"ReportsTo    =  "+POut.Long  (employee.ReportsTo)+" "
				+"WHERE EmployeeNum = "+POut.Long(employee.EmployeeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Employee in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Employee employee,Employee oldEmployee) {
			string command="";
			if(employee.LName != oldEmployee.LName) {
				if(command!="") { command+=",";}
				command+="LName = '"+POut.String(employee.LName)+"'";
			}
			if(employee.FName != oldEmployee.FName) {
				if(command!="") { command+=",";}
				command+="FName = '"+POut.String(employee.FName)+"'";
			}
			if(employee.MiddleI != oldEmployee.MiddleI) {
				if(command!="") { command+=",";}
				command+="MiddleI = '"+POut.String(employee.MiddleI)+"'";
			}
			if(employee.IsHidden != oldEmployee.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(employee.IsHidden)+"";
			}
			if(employee.ClockStatus != oldEmployee.ClockStatus) {
				if(command!="") { command+=",";}
				command+="ClockStatus = '"+POut.String(employee.ClockStatus)+"'";
			}
			if(employee.PhoneExt != oldEmployee.PhoneExt) {
				if(command!="") { command+=",";}
				command+="PhoneExt = "+POut.Int(employee.PhoneExt)+"";
			}
			if(employee.PayrollID != oldEmployee.PayrollID) {
				if(command!="") { command+=",";}
				command+="PayrollID = '"+POut.String(employee.PayrollID)+"'";
			}
			if(employee.WirelessPhone != oldEmployee.WirelessPhone) {
				if(command!="") { command+=",";}
				command+="WirelessPhone = '"+POut.String(employee.WirelessPhone)+"'";
			}
			if(employee.EmailWork != oldEmployee.EmailWork) {
				if(command!="") { command+=",";}
				command+="EmailWork = '"+POut.String(employee.EmailWork)+"'";
			}
			if(employee.EmailPersonal != oldEmployee.EmailPersonal) {
				if(command!="") { command+=",";}
				command+="EmailPersonal = '"+POut.String(employee.EmailPersonal)+"'";
			}
			if(employee.IsFurloughed != oldEmployee.IsFurloughed) {
				if(command!="") { command+=",";}
				command+="IsFurloughed = "+POut.Bool(employee.IsFurloughed)+"";
			}
			if(employee.IsWorkingHome != oldEmployee.IsWorkingHome) {
				if(command!="") { command+=",";}
				command+="IsWorkingHome = "+POut.Bool(employee.IsWorkingHome)+"";
			}
			if(employee.ReportsTo != oldEmployee.ReportsTo) {
				if(command!="") { command+=",";}
				command+="ReportsTo = "+POut.Long(employee.ReportsTo)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE employee SET "+command
				+" WHERE EmployeeNum = "+POut.Long(employee.EmployeeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Employee,Employee) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Employee employee,Employee oldEmployee) {
			if(employee.LName != oldEmployee.LName) {
				return true;
			}
			if(employee.FName != oldEmployee.FName) {
				return true;
			}
			if(employee.MiddleI != oldEmployee.MiddleI) {
				return true;
			}
			if(employee.IsHidden != oldEmployee.IsHidden) {
				return true;
			}
			if(employee.ClockStatus != oldEmployee.ClockStatus) {
				return true;
			}
			if(employee.PhoneExt != oldEmployee.PhoneExt) {
				return true;
			}
			if(employee.PayrollID != oldEmployee.PayrollID) {
				return true;
			}
			if(employee.WirelessPhone != oldEmployee.WirelessPhone) {
				return true;
			}
			if(employee.EmailWork != oldEmployee.EmailWork) {
				return true;
			}
			if(employee.EmailPersonal != oldEmployee.EmailPersonal) {
				return true;
			}
			if(employee.IsFurloughed != oldEmployee.IsFurloughed) {
				return true;
			}
			if(employee.IsWorkingHome != oldEmployee.IsWorkingHome) {
				return true;
			}
			if(employee.ReportsTo != oldEmployee.ReportsTo) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Employee from the database.</summary>
		public static void Delete(long employeeNum) {
			string command="DELETE FROM employee "
				+"WHERE EmployeeNum = "+POut.Long(employeeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many Employees from the database.</summary>
		public static void DeleteMany(List<long> listEmployeeNums) {
			if(listEmployeeNums==null || listEmployeeNums.Count==0) {
				return;
			}
			string command="DELETE FROM employee "
				+"WHERE EmployeeNum IN("+string.Join(",",listEmployeeNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}