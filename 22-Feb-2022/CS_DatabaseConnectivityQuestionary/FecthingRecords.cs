using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CS_DatabaseConnectivityDisconnectedArchitecture.Model;

namespace CS_DatabaseConnectivityDisconnectedArchitecture
{
    internal class FecthingRecords
    {
        //SqlCommand sqlCommand;
        //SqlConnection sqlConnection;
        public static void fetchEmployees(ref List<Employee> employees)
        {
            Console.WriteLine("EmpNo      EmpName           Salary         Designation    DeptNo         EmailID");
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"{emp.EmpNo}      {emp.EmpName}           {emp.Salary}         {emp.Designation}    {emp.DeptNo}         {emp.Email}");
            }
        }
        public static void fetchEmployee(ref Employee employee)
        {
            Console.WriteLine("EmpNo      EmpName           Salary         Designation    DeptNo         EmailID");
            Console.WriteLine($"{employee.EmpNo}      {employee.EmpName}           {employee.Salary}         {employee.Designation}    {employee.DeptNo}         {employee.Email}");
        }
        public static void GetAllEmployeesByDeptName(string dname)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
                sqlConnection.Open();
                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand($"select DeptName, EmpNo, EmpName, Designation,Location From Department Inner Join Employee on Department.DeptNo = Employee.DeptNo where Employee.DeptNo in (select Department.DeptNo From Department where DeptName = '{dname}')", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.Read())
                {
                    Console.WriteLine($"No Record Found For Employee With Department {dname}");
                }
                else
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"DeptName: {sqlDataReader["DeptName"]}, EmpNo: {sqlDataReader["EmpNo"]},EmpName: {sqlDataReader["EmpName"]}, Designation: {sqlDataReader["Designation"]}, Location: {sqlDataReader["Location"]}");
                    }
                }
                sqlDataReader.Close();
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
        }

        public static void GetAllEmployeesWithMaxSalByDeptName(string dname)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
                sqlConnection.Open();
                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand($"select MAX(SALARY) as Salary From Employee Inner Join Department on Department.DeptNo = Employee.DeptNo where Employee.DeptNo in (select Department.DeptNo From Department where DeptName = '{dname}')", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"MAX(Salary) In Department {dname}:{sqlDataReader["Salary"]}");
                }
                sqlDataReader.Close();
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
        }

        public static void GetSumSalaryByDeptName(string dname)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
                sqlConnection.Open();
                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand($"select SUM(SALARY) as Salary From Employee Inner Join Department on Department.DeptNo = Employee.DeptNo where Employee.DeptNo in (select Department.DeptNo From Department where DeptName = '{dname}')", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"SUM(Salary) In Department {dname}:{sqlDataReader["Salary"]}");
                }
                sqlDataReader.Close();
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
        }

        public static void GetAllEmployeesByLocation(string location)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Enterprise;Integrated Security=SSPI");
                sqlConnection.Open();
                SqlCommand sqlCommand = null;
                sqlCommand = new SqlCommand($"select DeptName, EmpNo, EmpName, Designation,Location From Department Inner Join Employee on Department.DeptNo = Employee.DeptNo where Employee.DeptNo in (select Department.DeptNo From Department where Location = '{location}')", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.Read())
                {
                    Console.WriteLine($"No Record Found For Employee With Location {location}");
                }
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"DeptName: {sqlDataReader["DeptName"]}, EmpNo: {sqlDataReader["EmpNo"]},EmpName: {sqlDataReader["EmpName"]}, Designation: {sqlDataReader["Designation"]}, Location: {sqlDataReader["Location"]}");
                }
                sqlDataReader.Close();
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
        }
    }
}
