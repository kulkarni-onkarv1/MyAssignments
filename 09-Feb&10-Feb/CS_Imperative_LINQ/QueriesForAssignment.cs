using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    internal class QueriesForAssignment
    {
        public static void Question1(ref Employees employees)
        {
            Console.WriteLine("All Employees Order By Name in Ascending Order");

            var res = from e in employees   //If there is duplication of name then will select First Apperance
                      orderby e.EmpName
                      select e;
            QueryOutcomes.PrintResult(res);
        }

        public static void AllEmpOrderBySalaryInDesc(ref Employees employees)
        {
            Console.WriteLine("All Employees Order By Salary in Descending Order");

            var res = from e in employees   //If there is duplication of name then will select First Apperance
                      orderby e.Salary descending
                      select e;
            QueryOutcomes.PrintResult(res);
        }

        //2)Print All Employees Group by the DeptName, and also display Employee Count for each DeptName
        public static void Question2(ref Employees employees)
        {
            Console.WriteLine("All Employees Group by the DeptName, and also display Employee Count for each DeptName");

            var res1 = (from e in employees
                        group e by e.DeptName into deptgroup
                        select new  // The Group Data is Stored in the Anonymous Type 
                        {
                            DeptName = deptgroup.Key, // Key aka the Property on WHich the Group is created
                            Records = deptgroup.ToList(), // List of Records per Group
                            Count = deptgroup.Count()
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Department Name = {record.DeptName}");
                QueryOutcomes.PrintResult(record.Records);
                Console.WriteLine("Count of Employee in Department:{0}\n", record.Count);
            }

        }

        //3)Find out Sum of Salary for Employess per DeptName
        public static void Question3(ref Employees employees)
        {
            Console.WriteLine("Find out Sum of Salary for Employess per DeptName");
            var res = (from e in employees
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            SumSalary = deptgroup.Sum(x => x.Salary)
                        });

            foreach (var record in res)
            {
                Console.WriteLine($"Department = {record.DeptName} and Sum of Salary {record.SumSalary}");
            }
        }

        //4,5,6)Print Employee with Max,Min,Avg Salary Per DeptName

        public static void QuestionFourFiveSix(ref Employees employees)
        {
            var res = (from e in employees
                       group e by e.DeptName into deptgroup
                       select new
                       {
                           DeptName = deptgroup.Key,
                           MaxSalary = deptgroup.Max(x => x.Salary),
                           MinSalary=deptgroup.Min(x=>x.Salary),
                           AverageSalary=deptgroup.Average(p=>p.Salary)
                      });

            foreach (var record in res)
            {
                Console.WriteLine($"Department: {record.DeptName}\nHighest Salary Within Department: {record.MaxSalary}" +
                    $"\nLowest Salary Within Department: {record.MinSalary}\nAvagerage Salary Within Department: {record.AverageSalary}\n");
            }
        }

        //7)Print Employees by Designation Group

        internal static void Question7(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.Designation into designationGroup
                        select new  // The Group Data is Stored in the Anonymous Type 
                        {
                            DeptName = designationGroup.Key, // Key aka the Property on WHich the Group is created
                            Records = designationGroup.ToList() // List of Records per Group
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Designation = {record.DeptName}");
                QueryOutcomes.PrintResult(record.Records);
                Console.WriteLine();
            }
        }

        //Display All EMployees those are Managers, Directors only
        public static void Question8(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.Designation into Designationgroup
                        where (Designationgroup.Key=="Manager" || Designationgroup.Key=="Admin")
                        select new  // The Group Data is Stored in the Anonymous Type 
                        {
                            Designation = Designationgroup.Key, // Key aka the Property on WHich the Group is created
                            Records = Designationgroup.ToList() // List of Records per Group
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Designation = {record.Designation}");
                QueryOutcomes.PrintResult(record.Records);
                Console.WriteLine();
            }
        }
        //9)Print All EMployees Having Salary in Range 25000 to 75000
        public static void Question9(ref Employees employees)
        {
            var res = (from e in employees where (e.Salary<=11000 && e.Salary>=6000) 
                       select e);
            QueryOutcomes.PrintResult(res);

            /*foreach(var record in res)
            {
                Console.WriteLine("Salary={0}", record.Salary);
            }*/
        }

        //10)Print Employee with Second Max Salary

        public static void SecondMaxSalary(ref Employees employees)
        {
            /*foreach(var record in employees)
            {
                Console.WriteLine("Salary: {0}",record.Salary);
            }*/
            Employees em = new Employees();
            AllEmpOrderBySalaryInDesc(ref em);

            var res = employees.OrderByDescending(x => x.Salary)
                     .Select(x => x.Salary).Distinct().Take(3) //limit x,offset y
                     .Skip(2).FirstOrDefault();
           Console.WriteLine("\n3rd Maximum Salary is: " + res);

            /*foreach(var record in res)
            {
                Console.WriteLine(record);//To get next n records after skiping(n-1) records
            }*/

            var res1 = (from e in employees orderby e.Salary descending select e).Distinct().Take(2) //limit x,offset y
                     .Skip(1).FirstOrDefault();
            Console.Write("2Nd Maximum Salary is: " + res1.Salary);
           
        }

        public static void secondMaxSalaryGroupByDept(ref Employees employees)
        {
            Employees em = new Employees();
            var res2 = (from e in employees
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            secondMaxSalary = deptgroup.OrderByDescending(x => x.Salary)
                      .Select(x => x.Salary).Distinct().Take(3) //limit x,offset y
                      .Skip(1).FirstOrDefault(),
                        });

            //QueryOutcomes.DeptWiseGroup(ref em);
            foreach (var record in res2)
            {
                Console.WriteLine($"Department = {record.DeptName} and Second Max Salary In Department: {record.secondMaxSalary}");
            }
        }

        public static void InnerJoinDemonstration(ref Emps emps,ref Departments depts)
        {
            // Declarative Query using Join() method
            // Outer Sequence Emps from which a join will start executing
            var join = emps.Join(
                           depts, // inner sequence on which the Join will be applied
                           emps => emps.DeptNo, // Outer Key to apply on inner matched key
                           depts => depts.DeptNo, // the Inner Key to check with outer key 
                           (emps, depts) => new {
                               EmpNo=emps.EmpNo,
                               EmpName=emps.EmpName,
                               DeptName=depts.DeptName,
                               Designation=emps.Designation,
                               Location=depts.Location,

                           }
                        );
            Console.WriteLine("EmpNo:   EmpName:   Department:   Designation  LOcation");
            foreach (var value in join)
            {
                Console.WriteLine($"{value.EmpNo}    {value.EmpName}    {value.DeptName} " +
                    $"{value.Designation}    {value.Location}");
            }
        }

        public static void DepartmentWiseEmployeeTax(ref Employees employees)
        {
            float Index1 = 0.005f;
            float Index2 = 0.01f;
            float Index0 = 0;
            Employees em = new Employees();

            var res2 = (from e in employees
                        where e.Salary >= 500000 && e.Salary < 1000000
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            Records = deptgroup.ToList()
                        }) ;
            Console.WriteLine("Tax Index Is 0.05 % of Total Salary For Employee With Salary In Range 500000 To 999999");
            foreach (var value in res2)
            {
                Console.WriteLine($"Department:{value.DeptName}");
                QueryOutcomes.PrintResult(value.Records,Index1);
                Console.WriteLine();
            }

            var res3 = (from e in employees
                        where e.Salary >= 1000000 && e.Salary < 3000000
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            Records = deptgroup.ToList()
                        });
            Console.WriteLine("Tax Index Is 0.1% of Total Salary For Employee With Salary In Range 1000000 To 1999999");
            foreach (var value in res3)
            {
                Console.WriteLine($"Department:{value.DeptName}");
                QueryOutcomes.PrintResult(value.Records, Index2);
                Console.WriteLine();
            }

            var res4 = (from e in employees
                        where e.Salary < 500000
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            Records = deptgroup.ToList()
                        });
            Console.WriteLine("Tax Index Is 0% of Total Salary For Employee With Salary Less Than 500000");
            foreach (var value in res4)
            {
                Console.WriteLine($"Department:{value.DeptName}");
                QueryOutcomes.PrintResult(value.Records,Index0);
                Console.WriteLine();
            }
        }
    }
}
