using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. Using Model and Database Namespaces
using System.Data;
using System.Data.SqlClient;
using CS_DatabaseConnectivityDisconnectedArchitecture.Model;

namespace CS_DatabaseConnectivityDisconnectedArchitecture.DataAccess
{
    internal class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        static string DeptName = string.Empty;
        static string Location = string.Empty;
        SqlConnection sqlConnection;
        SqlDataAdapter EmployeeDataAdapter;
        DataSet datasetForEmployee;

        public EmployeeDataAccess()
        {
            sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
            EmployeeDataAdapter = new SqlDataAdapter("Select * from Employee", sqlConnection);

            // 3. Create a DataSet Instance
            datasetForEmployee = new DataSet();
            
            // 3.a. Lets Convert UnTyped DataSet Into the Typed DataSet
            // This will be required to search records based on Primary key
            // using the Find() method of the DaraRowCollection

            EmployeeDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            // 4. Fill data in DataSet
            // The Name of the Table on Db Server is given to table created 
            // in dataset
            // This will be UnTyped DataSet By Default

            EmployeeDataAdapter.Fill(datasetForEmployee, "Employee");
        }
        public Employee Create(Employee emp)
        {
            Employee employee = new Employee();
            try
            {            
                // 1. Create a new Row in the Department DataTable in DataSet
                DataRow DrNew = datasetForEmployee.Tables["Employee"].NewRow();
                
                // 2. Set data for all columns for the row
                DrNew["EmpNO"] = emp.EmpNo;
                DrNew["EmpName"] = emp.EmpName;
                DrNew["Salary"] = emp.Salary;
                DrNew["Designation"] = emp.Designation;
                DrNew["DeptNo"] = emp.DeptNo;
                DrNew["Email"] = emp.Email;

                // 3. Add the Row into the Table
                datasetForEmployee.Tables["Employee"].Rows.Add(DrNew);

                // 4. Define a Command Builder to Ask the Adpater to Update Record in Database Table
                
                SqlCommandBuilder bldr1 = new SqlCommandBuilder(EmployeeDataAdapter);
                
                // 5. Call Update
                int res=EmployeeDataAdapter.Update(datasetForEmployee, "Employee");

                Console.WriteLine(res);
                if (res == 0)
                {
                    employee = null;
                }
                else
                {
                    employee= emp;
                }

            }
            // for one try there can be multiple catch
            // make sure that the specific catch appears before 
            // the general catch (i.e. Exception class)
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employee;
        }

        IEnumerable<Employee> IDataAccess<Employee, int>.GetData()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                
                DataRowCollection dataRowsInEmployee = datasetForEmployee.Tables["Employee"].Rows;

                foreach(DataRow row in dataRowsInEmployee)
                {
                    employees.Add(
                          new Employee()
                          {
                              //EmpNo=int.Parse(Reader["DeptNo"])
                              EmpNo = Convert.ToInt32(row["EmpNo"]),
                              EmpName = row["EmpName"].ToString(),
                              Salary = Convert.ToInt32(row["Salary"]),
                              Designation = row["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(row["DeptNo"]),
                              Email = row["Email"].ToString()
                          }
                        );
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employees;
        }

        Employee IDataAccess<Employee, int>.GetData(int id)
        {
            Employee employee = new Employee();
            try
            {
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = datasetForEmployee.Tables["Employee"].Rows.Find(id);
                if(DrFind != null)
                {
                    employee.EmpNo = Convert.ToInt32(DrFind["EmpNo"]);
                    employee.EmpName = DrFind["EmpName"].ToString();
                    employee.Salary = Convert.ToInt32(DrFind["Salary"]);
                    employee.Designation = DrFind["Designation"].ToString();
                    employee.DeptNo = Convert.ToInt32(DrFind["DeptNo"]);
                    employee.Email = DrFind["Email"].ToString();

                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        Employee IDataAccess<Employee, int>.Update(int id, Employee entity)
        {
            Employee employee = new Employee();
            try
            {               
                DataRow DrFind = datasetForEmployee.Tables["Employee"].Rows.Find(id);
                if( DrFind != null)
                {
                    // 2. Update its Values
                    DrFind["EmpName"] = entity.EmpName;
                    DrFind["Salary"] = entity.Salary;
                    DrFind["Designation"] = entity.Designation;
                    DrFind["DeptNo"] = entity.DeptNo;
                    DrFind["Email"] = entity.Email;

                    // 3. Command Build and Update
                    SqlCommandBuilder bldr2 = new SqlCommandBuilder(EmployeeDataAdapter);
                    int res = EmployeeDataAdapter.Update(datasetForEmployee, "Employee");
                    Console.WriteLine(res);
                    if (res == 0)
                    {
                        employee = null;
                    }
                    else
                    {
                        employee = entity;
                    }
                }
                else
                {
                    Console.WriteLine("No Record Found For EmpNo: {0}", id); 
                    employee = null;
                }
                
            }
            // for one try there can be multiple catch
            // make sure that the specific catch appears before 
            // the general catch (i.e. Exception class)
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employee;
        }
        Employee IDataAccess<Employee, int>.Delete(int id)
        {
            Employee employee = new Employee();
            try
            {              
                //1. Search Record BAsed on Primary Key
                DataRow DrFind = datasetForEmployee.Tables["Employee"].Rows.Find(id);
                if(DrFind != null)
                {
                    // 2. Call Delete() method on the searched record
                    DrFind.Delete();

                    // 3. Command Build and Update
                    SqlCommandBuilder bldr2 = new SqlCommandBuilder(EmployeeDataAdapter);
                    int res = EmployeeDataAdapter.Update(datasetForEmployee, "Employee");

                    if (res == 0)
                    {                       
                        employee = null;
                    }
                }
                else
                {
                    Console.WriteLine("No Record Found For EmpNo: {0}", id);
                    employee = null;
                }
            }
            // for one try there can be multiple catch
            // make sure that the specific catch appears before 
            // the general catch (i.e. Exception class)
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employee;
        }
    }
}
