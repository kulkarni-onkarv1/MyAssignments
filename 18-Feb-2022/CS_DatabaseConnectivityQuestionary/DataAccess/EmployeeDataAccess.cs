using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. Using Model and Database Namespaces
using System.Data;
using System.Data.SqlClient;
using CS_DatabaseConnectivityConnectedArchitecture.Model;

namespace CS_DatabaseConnectivityConnectedArchitecture.DataAccess
{
    internal class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        static int choice = 0;
        static int IdChoice = 0;
        static string DeptName = string.Empty;
        static string Location = string.Empty;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        /// <summary>
        /// Instantite the SqlConnection by passing ConnectionString to
        /// Constructor of the SqlConnection
        /// </summary>
        public EmployeeDataAccess()
        {
            sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
        }
        public Employee Create(Employee entity)
        {
            Employee employee = new Employee();
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                // Create paramerized query
                sqlCommand.CommandText = "Insert into Enterprise..Employee values(@EmpNo,@EmpName,@Salary,@Designation,@DeptNo,@Email)";

                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = entity.EmpNo;

                SqlParameter pEmpName = new SqlParameter();
                pEmpName.ParameterName = "@EmpName";
                pEmpName.SqlDbType = SqlDbType.VarChar;
                pEmpName.Size = 200;
                pEmpName.Direction = ParameterDirection.Input;
                pEmpName.Value = entity.EmpName;

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@Salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Direction = ParameterDirection.Input;
                pSalary.Value = entity.Salary;

                SqlParameter pDesignation = new SqlParameter();
                pDesignation.ParameterName = "@Designation";
                pDesignation.SqlDbType = SqlDbType.VarChar;
                pDesignation.Size = 200;
                pDesignation.Direction = ParameterDirection.Input;
                pDesignation.Value = entity.Designation;

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = entity.DeptNo;

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@Email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Size = 200;
                pEmail.Direction = ParameterDirection.Input;
                pEmail.Value = entity.Email;

                // Add parameters into the Parameters Collection of the Command object
                sqlCommand.Parameters.Add(pEmpNo);
                sqlCommand.Parameters.Add(pEmpName);
                sqlCommand.Parameters.Add(pSalary);
                sqlCommand.Parameters.Add(pDesignation);
                sqlCommand.Parameters.Add(pDeptNo);
                sqlCommand.Parameters.Add(pEmail);

                // Call the execute method
                int res = sqlCommand.ExecuteNonQuery();
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
                // Open
                sqlConnection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Select * from Enterprise..Employee";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Iterate over the Reader for Department Rows
                while (sqlDataReader.Read())
                {
                    // Read each row using the Reader
                    // and add it into the departments list by storing
                    // each column value of the record into the Department object
                    employees.Add(
                          new Employee()
                          {
                              //EmpNo=int.Parse(Reader["DeptNo"])
                              EmpNo = Convert.ToInt32(sqlDataReader["EmpNo"]),
                              EmpName = sqlDataReader["EmpName"].ToString(),
                              Salary = Convert.ToInt32(sqlDataReader["Salary"]),
                              Designation = sqlDataReader["Designation"].ToString(),
                              DeptNo = Convert.ToInt32(sqlDataReader["DeptNo"]),
                              Email = sqlDataReader["Email"].ToString()
                          }
                        );
                }
                sqlDataReader.Close();
                // Close
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employees;
        }

        Employee IDataAccess<Employee, int>.SearchData()
        {
            Employee employees = new Employee();
            try
            {
                // Open
                sqlConnection.Open();
                // We can also pass the Command Tetx and Commection Object to the Constrctor

                /*sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Select * from Enterprise..Employee";*/

                Console.WriteLine("Enter \n1 To Fecth Record By EmpNo\n2 To Get All Employees By DeptName\n3 To Get Employee Record With MaxSal In Department\n4 To Get SumSalary In Department\n5 To Get All Employees In Perticular Location");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter Employee Number Whose Record You Want!");
                    IdChoice = int.Parse(Console.ReadLine());
                    sqlCommand = new SqlCommand($"Select * from Enterprise..Employee where EmpNo={IdChoice}", sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        //EmpNo=int.Parse(Reader["DeptNo"])
                        employees.EmpNo = Convert.ToInt32(sqlDataReader["EmpNo"]);
                        employees.EmpName = sqlDataReader["EmpName"].ToString();
                        employees.Salary = Convert.ToInt32(sqlDataReader["Salary"]);
                        employees.Designation = sqlDataReader["Designation"].ToString();
                        employees.DeptNo = Convert.ToInt32(sqlDataReader["DeptNo"]);
                        employees.Email = sqlDataReader["Email"].ToString();
                    }
                    sqlDataReader.Close();
                    if(employees.EmpNo == 0)
                    {
                        Console.WriteLine("No Record Found For EmpNo:{0}", IdChoice);
                    }
                    return employees;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter Employee Department Name Whose Record You Want To Fetch!");
                    DeptName = Console.ReadLine();
                    FecthingRecords.GetAllEmployeesByDeptName(DeptName);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter Employee Department Name Max(Salary) You Want To Fetch!");
                    DeptName = Console.ReadLine();
                    FecthingRecords.GetAllEmployeesWithMaxSalByDeptName(DeptName);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter Department Name Whose Sum(Salary) You Want To Fetch!");
                    DeptName = Console.ReadLine();
                    FecthingRecords.GetSumSalaryByDeptName(DeptName);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter Department Location Whose Employees' Record You Want To Fetch!");
                    Location = Console.ReadLine();
                    FecthingRecords.GetAllEmployeesByLocation(Location);
                }
                else
                {
                    Console.WriteLine("Oh Oh! Invalid Choice, Redirecting Tou To Main Menu");
                }
                // Close
                sqlConnection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally // this will be executed irrespective of try or catch block
            {
                // if the Connection is still open the close it
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return employees;
        }

        Employee IDataAccess<Employee, int>.Update(int id, Employee entity)
        {
            Employee employee = new Employee();
            try
            {
                // check if id and the DeptNo value of the entity is same

                sqlConnection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                // Create paramerized query
                sqlCommand.CommandText = "Update Employee Set EmpName=@EmpName, Salary=@Salary, Designation=@Designation,DeptNo=@DeptNo,Email=@Email where EmpNo=@EmpNo";

                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;

                SqlParameter pEmpName = new SqlParameter();
                pEmpName.ParameterName = "@EmpName";
                pEmpName.SqlDbType = SqlDbType.VarChar;
                pEmpName.Size = 200;
                pEmpName.Direction = ParameterDirection.Input;
                pEmpName.Value = entity.EmpName;

                SqlParameter pSalary = new SqlParameter();
                pSalary.ParameterName = "@Salary";
                pSalary.SqlDbType = SqlDbType.Int;
                pSalary.Direction = ParameterDirection.Input;
                pSalary.Value = entity.Salary;

                SqlParameter pDesignation = new SqlParameter();
                pDesignation.ParameterName = "@Designation";
                pDesignation.SqlDbType = SqlDbType.VarChar;
                pDesignation.Size = 200;
                pDesignation.Direction = ParameterDirection.Input;
                pDesignation.Value = entity.Designation;

                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = entity.DeptNo;

                SqlParameter pEmail = new SqlParameter();
                pEmail.ParameterName = "@Email";
                pEmail.SqlDbType = SqlDbType.VarChar;
                pEmail.Size = 200;
                pEmail.Direction = ParameterDirection.Input;
                pEmail.Value = entity.Email;

                // Add parameters into the Parameters Collection of the Command object
                sqlCommand.Parameters.Add(pEmpNo);
                sqlCommand.Parameters.Add(pEmpName);
                sqlCommand.Parameters.Add(pSalary);
                sqlCommand.Parameters.Add(pDesignation);
                sqlCommand.Parameters.Add(pDeptNo);
                sqlCommand.Parameters.Add(pEmail);

                // Call the execute method
                int res = sqlCommand.ExecuteNonQuery();
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
                sqlConnection.Open();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "Delete From Employee where EmpNo=@EmpNo";

                // Create paramerized query
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;

                // Add parameters into the Parameters Collection of the Command object
                sqlCommand.Parameters.Add(pEmpNo);

                // Call the execute method
                int res = sqlCommand.ExecuteNonQuery();

                if (res == 0)
                {
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
