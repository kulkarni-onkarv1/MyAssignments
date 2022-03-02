using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_DatabaseConnectivityConnectedArchitecture.DataAccess;
using CS_DatabaseConnectivityConnectedArchitecture.Model;

namespace CS_DatabaseConnectivityConnectedArchitecture
{
    internal class Program
    {

        static int choice = 0;
        static int IdChoice = 0;
        static string Name = string.Empty;
        static int salary = 0;
        static string designation = string.Empty;
        static string email = string.Empty;
        static int DeptNO = 0;
        static int EmployeeID = 0;
        static void Main(string[] args)
        {
            do
            {
                List<Employee> employeesList = new List<Employee> { };
                try
                {
                    Console.WriteLine("Enter\n1 To Get Entire Records\n2 To Fetch Existing Record\n3 To Delete Existing Record\n4 To Update Existing Record\n5 To Add Employee\n6 To Exit");
                    choice = int.Parse(Console.ReadLine());

                    IDataAccess<Employee, int> employeeData = new EmployeeDataAccess();
                    if (choice == 1)
                    {
                        var employees = employeeData.GetData();
                        foreach(Employee employee in employees)
                        {
                            employeesList.Add(employee);
                        }
                        FecthingRecords.fetchEmployees(ref employeesList);
                        employeesList.Clear();
                    }
                    else if (choice == 2)
                    {
                        /*Console.WriteLine("Enter Employee Number Whose Record You Want!");
                        IdChoice = int.Parse(Console.ReadLine());*/
                        var employee = employeeData.SearchData();
                        if (employee.EmpNo!=0)
                        {
                            FecthingRecords.fetchEmployee(ref employee);
                        }
                        
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Enter Employee Number Whose Record You Want To Delete!");
                        IdChoice = int.Parse(Console.ReadLine());
                        var resDelete = employeeData.Delete(IdChoice);
                        if (resDelete != null)
                        {
                            Console.WriteLine($"Record with EmpNo: {IdChoice} Deleted Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Either No Record Exists for EmpNo:{0} Or Unconsious Error Occured!", IdChoice);
                            Console.WriteLine("Database Is Unchanged");
                        }
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Enter Employee Number Whose Record You Want To Update!");
                        IdChoice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Entry For Employee Name");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter New Entry For Employee Salary");
                        salary = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Entry For Employee Designation");
                        designation = Console.ReadLine();
                        Console.WriteLine("Enter New Entry For Employee DeptNo");
                        DeptNO = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter New Entry For Employee Email");
                        email = Console.ReadLine();
                        Console.WriteLine("Updating new Record");
                        var employeeNew = new Employee()
                        {
                            //EmpNo = IdChoice,
                            EmpName = Name,
                            Salary = salary,
                            Designation = designation,
                            DeptNo = DeptNO,
                            Email = email
                        };
                        Console.WriteLine("Passing");
                        var result = employeeData.Update(IdChoice, employeeNew);

                        if (result == null)
                        {
                            Console.WriteLine("Upate Faild");
                        }
                        else
                        {
                            Console.WriteLine("Update Success");
                        }
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Enter Employee Number");
                        EmployeeID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Employee Name");
                        Name = Console.ReadLine();
                        Console.WriteLine("Enter Employee Salary");
                        salary = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Employee Designation");
                        designation = Console.ReadLine();
                        Console.WriteLine("Enter For Employee DeptNo");
                        DeptNO = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Employee Email");
                        email = Console.ReadLine();
                        Console.WriteLine("Creating new Record");
                        var employeeNew = new Employee()
                        {
                            EmpNo = EmployeeID,
                            EmpName = Name,
                            Salary = salary,
                            Designation = designation,
                            DeptNo = DeptNO,
                            Email = email
                        };
                        Console.WriteLine("Passing");
                        var result = employeeData.Create(employeeNew);

                        if (result == null)
                        {
                            Console.WriteLine("Insertion Faild");
                        }
                        else
                        {
                            Console.WriteLine("Insertion Success");
                        }
                    }
                    else if (choice == 6)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Oh Oh! Invalid Choice, Redirecting Tou To Main Menu");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nRedirecting You To Main Menu");
                }
            } while (true);
        }
    }
}

