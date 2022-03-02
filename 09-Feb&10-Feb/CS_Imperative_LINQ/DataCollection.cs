using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{
    
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT",Designation="Manager",Salary = 411000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Engineer", Salary = 612000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Designation = "Director", Salary = 713000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Designation = "Admin", Salary = 814000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Designation = "Manager", Salary = 910000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Designation = "Engineer", Salary = 1009000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Designation = "Director", Salary = 1118000 });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Designation = "Admin", Salary = 1227000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Designation = "Manager", Salary = 1336000 });
            Add(new Employee() { EmpNo = 111, EmpName = "Suprotim", DeptName = "IT", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 112, EmpName = "Suprotim1", DeptName = "HR", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Suprotim2", DeptName = "SL", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Suprotim3", DeptName = "IT", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Suprotim4", DeptName = "HR", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Suprotim5", DeptName = "SL", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Suprotim6", DeptName = "IT", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Suprotim7", DeptName = "HR", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Suprotim8", DeptName = "SL", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 120, EmpName = "Suprotim9", DeptName = "IT", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 121, EmpName = "Onkar", DeptName = "HR", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 122, EmpName = "Suprotim11", DeptName = "SL", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 123, EmpName = "Suprotim12", DeptName = "IT", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 124, EmpName = "Suprotim13", DeptName = "HR", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 125, EmpName = "Suprotim14", DeptName = "SL", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 126, EmpName = "Suprotim15", DeptName = "IT", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 127, EmpName = "Suprotim16", DeptName = "HR", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Suprotim17", DeptName = "SL", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 129, EmpName = "Suprotim18", DeptName = "IT", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Suprotim19", DeptName = "HR", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 131, EmpName = "Suprotim20", DeptName = "SL", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Suprotim21", DeptName = "IT", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Suprotim01", DeptName = "HR", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Suprotim02", DeptName = "IT", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Suprotim03", DeptName = "SL", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 136, EmpName = "Suprotim04", DeptName = "IT", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Suprotim05", DeptName = "HR", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Suprotim06", DeptName = "SL", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Suprotim07", DeptName = "IT", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Suprotim08", DeptName = "HR", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 141, EmpName = "Suprotim09", DeptName = "SL", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Suprotimm", DeptName = "IT", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Suprotimn", DeptName = "HR", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Suprotimo", DeptName = "SL", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 145, EmpName = "Suprotimp", DeptName = "IT", Designation = "Manager", Salary = 1445000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Suprotimq", DeptName = "HR", Designation = "Engineer", Salary = 1445000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Suprotimr", DeptName = "SL", Designation = "Director", Salary = 1445000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Suprotims", DeptName = "IT", Designation = "Admin", Salary = 1445000 });
            Add(new Employee() { EmpNo = 149, EmpName = "Suprotimt", DeptName = "HR", Designation = "Managerr", Salary = 1445000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Suprotimu", DeptName = "SL", Designation = "Engineer", Salary = 1445000 });
        }      
        
    }
    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public int DeptNo { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; }
    }  
    internal class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }

    internal class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
