using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    internal class Program
    {
        /* 1)Print All Employees In Ascending Order of the EmpName
           2)Print All Employees Group by the DeptName, and also display Employee Count for each DeptName
           3)Find out Sum of Salary for Employess per DeptName
           4)Print Employee with Max Salary Per DeptName
           5)Print Employee with Min Salary Per DeptName
           6)Print Average Salary Per DeptName
           7)Print Employees by Designation Group
           8)Display All EMployees those are Managers, Directors only
           9)Print All EMployees Having Salary in Range 25000 to 75000
          10)Print Employee with Second MAx Salary Per DeptName
          11)Print Employee with Second Max Salary
          12)Calculate Tax for Each Employee as followa
                       Salary from >=20K to <=40K is 0.05%
                       Salary from >40K to <=60K is 0.1%
                       Salary <20K is 0
                       Salary >60K is 0.15%
                          Print All these Salaries DeptName Wise
         */
        public static void Main()
        {
            Employees employees = new Employees();
            Emps emps = new Emps();
            Departments departments = new Departments();
            Console.WriteLine("Imperative LINQ\n");

            /*Assignment 09-Feb-2022*/

            //QueriesForAssignment.Question1(ref employees);

            //QueriesForAssignment.Question2(ref employees);

            //QueriesForAssignment.Question3(ref employees);

            //QueriesForAssignment.QuestionFourFiveSix(ref employees);

            //QueriesForAssignment.Question7(ref employees);

            //QueriesForAssignment.Question8(ref employees);

            //QueriesForAssignment.Question9(ref employees);

            //QueriesForAssignment.SecondMaxSalary(ref employees);// Question 10

            //QueriesForAssignment.secondMaxSalaryGroupByDept(ref employees); //Question 11

            QueriesForAssignment.DepartmentWiseEmployeeTax(ref employees); //Question 12


            /* #Create a Department Collection with 10 Records as
                DeptNo, DeptName, Location, Capacity
              
            #Modify the Employee Collection and use DeptNo instead of DeptName

           #List Employes as
               EmpNo, EmpName, Designation, DeptName, Location, Salary*/

            //QueriesForAssignment.InnerJoinDemonstration(ref emps,ref departments);

            /*Assignment 10-Feb-2022*/

            //EmployeeSalaryComputation.SalarySlipGeneration(ref employees);
























































            /*Console.WriteLine("Using the Select Statement");
            var res = from e in employees
                      select e;*/
            // QueryOutcomes.PrintResult(res);

            /*Console.WriteLine("Using a Where Condition to Display Employee by Specific Department");

            var res = from e in employees
                  where e.DeptName == "HR"
                  select e;
             QueryOutcomes.PrintResult(res);*/

            /* Console.WriteLine("All Employees Order By Salary in Ascending Order");

             var res = from e in employees
                   orderby e.Salary
                   select e;
             QueryOutcomes.PrintResult(res);*/


            /* Console.WriteLine("All Employees Order By Salary in Descending Order");

             res = from e in employees
                   orderby e.Salary descending
                   select e;*/

            //QueryOutcomes.PrintResult(res);

            /*Console.WriteLine("Print all Employees group by the DeptName");
            QueryOutcomes.DeptWiseGroup(ref employees);

            Console.WriteLine("Print Sum of Salary By each group");
            QueryOutcomes.DeptWiseSumSalary(ref employees);
            Console.WriteLine();

            Console.WriteLine("Using Join");
            Console.WriteLine();
            QueryOutcomes.UseJoin();

            Console.WriteLine("Using Join using Imoerative LINQ");
            QueryOutcomes.UseJoinImperative();*/



        }

    }   
}
    

