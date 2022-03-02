using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    internal class EmployeeSalaryComputation
    {
        static Employees employee=new Employees();
        static string EmpNo=String.Empty;
        static string Managers = "MANAGER";
        static string Directors = "DIRECTOR";
        static string Admins = "ADMIN";
        static string Engineers = "ENGINEER";
        static float HRA;
        static float TS;
        static float DA;
        public static void SalarySlipGeneration(ref Employees employees)
        {
            Console.WriteLine("Process Started!\n");
            var res = from e in employees   //If there is duplication of name then will select First Apperance
                      orderby e.EmpNo
                      select e;
            //QueryOutcomes.PrintResult(res);
            Console.WriteLine("Calculating Flexible Benifit Plans For Each Employee\n");
            foreach(var emp in res)
            {
                if (emp.Designation.ToUpper() == Managers)
                {
                    Console.WriteLine("Calculating FBP For Employee Number {0} With Designation {1} And Generating Their Salary Slip",emp.EmpNo,emp.Designation);
                    SalaryBreakupCalculation.FlexibleBenefitPlanForManager(ref HRA, ref TS, ref DA,emp.Salary);
                    EmployeeSalarySlips.CreateEmployeeSalarySlip(emp.EmpNo, emp.EmpName, emp.DeptName, emp.Designation,emp.Salary,HRA,TS,DA);
                }
                else if (emp.Designation.ToUpper() == Directors)
                {
                    Console.WriteLine("Calculating FBP For Employee Number {0} With Designation {1} And Generating Their Salary Slip", emp.EmpNo, emp.Designation);
                    SalaryBreakupCalculation.FlexibleBenefitPlanForDirector(ref HRA, ref TS, ref DA, emp.Salary);
                    EmployeeSalarySlips.CreateEmployeeSalarySlip(emp.EmpNo, emp.EmpName, emp.DeptName, emp.Designation,emp.Salary,HRA,TS,DA);
                }
                else if (emp.Designation.ToUpper() == Admins)
                {
                    Console.WriteLine("Calculating FBP For Employee Number {0} With Designation {1} And Generating Their Salary Slip", emp.EmpNo, emp.Designation);
                    SalaryBreakupCalculation.FlexibleBenefitPlanForAdmin(ref HRA, ref TS, ref DA, emp.Salary);
                    EmployeeSalarySlips.CreateEmployeeSalarySlip(emp.EmpNo, emp.EmpName, emp.DeptName, emp.Designation, emp.Salary, HRA, TS, DA);
                }
                else if(emp.Designation.ToUpper() == Engineers)
                {
                    Console.WriteLine("Calculating FBP For Employee Number {0} With Designation {1} And Generating Their Salary Slip", emp.EmpNo, emp.Designation);
                    SalaryBreakupCalculation.FlexibleBenefitPlanForEngineer(ref HRA, ref TS, ref DA, emp.Salary);
                    EmployeeSalarySlips.CreateEmployeeSalarySlip(emp.EmpNo, emp.EmpName, emp.DeptName, emp.Designation, emp.Salary, HRA, TS, DA);
                }
            }

            Console.WriteLine("\nDone!Salary Slips Are Bing Stored In Folder C:\\New folder\\Salaries");
        }      
    }
}
