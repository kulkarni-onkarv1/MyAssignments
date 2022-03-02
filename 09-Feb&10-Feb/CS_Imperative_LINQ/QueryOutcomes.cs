using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    internal class QueryOutcomes
    {
        internal static void PrintResult(IEnumerable<Employee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Salary}");
            }
        }
        internal static void PrintResult(IEnumerable<Employee> emps,float Ratio)
        {
            Console.WriteLine($"EmpNo:   EmpName:    Designation    Tax");
            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo}      {item.EmpName}       {item.Designation}        {item.Salary*Ratio}");
            } 
        }

        internal static void DeptWiseGroup(ref Employees emps)
        {
            var res1 = (from e in emps
                        orderby e.Salary descending
                        group e by e.DeptName into deptgroup                      
                        select new  // The Group Data is Stored in the Anonymous Type 
                        {
                            DeptName = deptgroup.Key, // Key aka the Property on WHich the Group is created
                            Records = deptgroup.ToList() // List of Records per Group
                        }); 

            foreach (var record in res1)
            {
                Console.WriteLine($"Dapartment = {record.DeptName}");
                PrintResult(record.Records);
                Console.WriteLine();
            }
        }

        internal static void DeptWiseSumSalary(ref Employees emps)
        {
            var res1 = (from e in emps
                        group e by e.DeptName into deptgroup
                        select new
                        {
                            DeptName = deptgroup.Key,
                            SumSalary = deptgroup.Sum(x => x.Salary)
                        });

            foreach (var record in res1)
            {
                Console.WriteLine($"Group Key = {record.DeptName} and Sum of Salary {record.SumSalary}");
            }
        }

        /// <summary>
        /// The dJsoin() is by default an Inner Join that will read all matching record from 
        /// the Collection using ikn Join from Outer Collection (Students) to 
        /// Inner collection (Standards)
        /// </summary>
        internal static void UseJoin()
        {
            var Students = new List<Student>()
            {
              new Student(){StandardID=1, StudentName="S1", StudentID=1 },
              new Student(){StandardID=2, StudentName="S2", StudentID=2 },
              new Student(){StandardID=1, StudentName="S3", StudentID=3 },
              new Student(){StandardID=2, StudentName="S4", StudentID=4 },
              new Student(){StandardID=1, StudentName="S5", StudentID=5 },
              new Student(){StandardID=2, StudentName="S6", StudentID=6 }
            };

            var Standards = new List<Standard>()
            {
              new Standard(){ StandardID=1, StandardName="Std1"},
              new Standard(){ StandardID=2, StandardName="Std2"},
              new Standard(){ StandardID=3, StandardName="Std3"}
            };

            // Declarative Query using Join() method
            // Outer Sequence Students from which a join will start executing
            var join = Students.Join(
                           Standards, // inner sequence on which the Join will be applied
                           student => student.StandardID, // Outer Key to apply on inner matched key
                           standrard => standrard.StandardID, // the Inner Key to check with outer key 
                           (student, standard) => new {
                               StudentName = student.StudentName,
                               StandardName = standard.StandardName
                           }
                        );
            foreach (var value in join)
            {
                Console.WriteLine($"{value.StudentName} and {value.StandardName}");
            }
        }


        internal static void UseJoinImperative()
        {
            var Students = new List<Student>()
            {
              new Student(){StandardID=1, StudentName="S1", StudentID=1 },
              new Student(){StandardID=2, StudentName="S2", StudentID=2 },
              new Student(){StandardID=1, StudentName="S3", StudentID=3 },
              new Student(){StandardID=2, StudentName="S4", StudentID=4 },
              new Student(){StandardID=1, StudentName="S5", StudentID=5 },
              new Student(){StandardID=2, StudentName="S6", StudentID=6 }
            };

            var Standards = new List<Standard>()
            {
              new Standard(){ StandardID=1, StandardName="Std1"},
              new Standard(){ StandardID=2, StandardName="Std2"},
              new Standard(){ StandardID=3, StandardName="Std3"}
            };

            var join = from s in Students  // Outer Sequence 
                       join st in Standards // Inner Sequence
                       on s.StandardID equals st.StandardID // Key match
                       select new
                       {
                           StudentName = s.StudentName,
                           StandardName = st.StandardName
                       };


            foreach (var value in join)
            {
                Console.WriteLine($"{value.StudentName} and {value.StandardName}");
            }
        }
    }
}
