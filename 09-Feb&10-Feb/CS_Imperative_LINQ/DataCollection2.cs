using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Imperative_LINQ
{

    internal class Emps : List<Emp>
    {
        public Emps()
        {
            Add(new Emp() { EmpNo = 101, EmpName = "Mahesh", DeptNo = 10, Designation = "Manager", Salary = 511000 });
            Add(new Emp() { EmpNo = 102, EmpName = "Tejas", DeptNo = 20, Designation = "Engineer", Salary = 612000 });
            Add(new Emp() { EmpNo = 103, EmpName = "Nandu", DeptNo = 30, Designation = "Director", Salary = 713000 });
            Add(new Emp() { EmpNo = 107, EmpName = "Anil", DeptNo = 10, Designation = "Admin", Salary = 814000 });
            Add(new Emp() { EmpNo = 105, EmpName = "Jaywant", DeptNo = 10, Designation = "Manager", Salary = 910000 });
            Add(new Emp() { EmpNo = 106, EmpName = "Abhay", DeptNo = 20, Designation = "Engineer", Salary = 1009000 });
            Add(new Emp() { EmpNo = 104, EmpName = "Anil", DeptNo = 30, Designation = "Director", Salary = 1118000 });
            Add(new Emp() { EmpNo = 108, EmpName = "Shyam", DeptNo = 10, Designation = "Admin", Salary = 1227000 });
            Add(new Emp() { EmpNo = 109, EmpName = "Vikram", DeptNo = 20, Designation = "Manager", Salary = 1336000 });
            Add(new Emp() { EmpNo = 111, EmpName = "Suprotim", DeptNo = 30, Designation = "Engineer", Salary = 1445000 });
            Add(new Emp() { EmpNo = 112, EmpName = "Suprotim1", DeptNo = 10, Designation = "Director", Salary = 1445000 });
            Add(new Emp() { EmpNo = 113, EmpName = "Suprotim2", DeptNo = 20, Designation = "Admin", Salary = 1445000 });
            Add(new Emp() { EmpNo = 114, EmpName = "Suprotim3", DeptNo = 30, Designation = "Manager", Salary = 1445000 });
            Add(new Emp() { EmpNo = 115, EmpName = "Suprotim4", DeptNo = 10, Designation = "Engineer", Salary = 1445000 });
            Add(new Emp() { EmpNo = 116, EmpName = "Suprotim5", DeptNo = 20, Designation = "Director", Salary = 1445000 });
            Add(new Emp() { EmpNo = 117, EmpName = "Suprotim6", DeptNo = 30, Designation = "Admin", Salary = 1445000 });
            Add(new Emp() { EmpNo = 118, EmpName = "Suprotim7", DeptNo = 10, Designation = "Manager", Salary = 1445000 });
            Add(new Emp() { EmpNo = 119, EmpName = "Suprotim8", DeptNo = 20, Designation = "Engineer", Salary = 1445000 });
            Add(new Emp() { EmpNo = 120, EmpName = "Suprotim9", DeptNo = 30, Designation = "Director", Salary = 1445000 });
            Add(new Emp() { EmpNo = 121, EmpName = "Onkar", DeptNo = 10, Designation = "Admin", Salary = 1445000 });
            Add(new Emp() { EmpNo = 122, EmpName = "Suprotim11", DeptNo = 20, Designation = "Manager", Salary = 1445000 });
            Add(new Emp() { EmpNo = 123, EmpName = "Suprotim12", DeptNo = 30, Designation = "Engineer", Salary = 1445000 });
            Add(new Emp() { EmpNo = 124, EmpName = "Suprotim13", DeptNo = 10, Designation = "Director", Salary = 1445000 });
            Add(new Emp() { EmpNo = 125, EmpName = "Suprotim14", DeptNo = 20, Designation = "Admin", Salary = 1445000 });
            Add(new Emp() { EmpNo = 126, EmpName = "Suprotim15", DeptNo = 30, Designation = "Manager", Salary = 1445000 });
            Add(new Emp() { EmpNo = 127, EmpName = "Suprotim16", DeptNo = 10, Designation = "Engineer", Salary = 1445000 });
            Add(new Emp() { EmpNo = 128, EmpName = "Suprotim17", DeptNo = 200, Designation = "Director", Salary = 1445000 });
            Add(new Emp() { EmpNo = 129, EmpName = "Suprotim18", DeptNo = 300, Designation = "Admin", Salary = 1445000 });
            Add(new Emp() { EmpNo = 130, EmpName = "Suprotim19", DeptNo = 10, Designation = "Manager", Salary = 1445000 });
            /*Add(new Employee() { EmpNo = 131, EmpName = "Suprotim20", DeptName = "SL", Designation = "Director", Salary = 1445000 });
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
            Add(new Employee() { EmpNo = 150, EmpName = "Suprotimu", DeptName = "SL", Designation = "Engineer", Salary = 1445000 });*/
        }

    }

        internal class Departments : List<Department>
        {
            public Departments()
            {
                Add(new Department() { DeptNo = 10, DeptName = "IT", Location = "Barshi", Capacity = 100 });
                Add(new Department() { DeptNo = 20, DeptName = "HR", Location = "Latur", Capacity = 100 });
                Add(new Department() { DeptNo = 30, DeptName = "SL", Location = "Nanded", Capacity = 100 });
                Add(new Department() { DeptNo = 40, DeptName = "Acc", Location = "Barshi", Capacity = 100 });
                Add(new Department() { DeptNo = 50, DeptName = "D-50", Location = "Latur", Capacity = 100 });
                Add(new Department() { DeptNo = 60, DeptName = "D-60", Location = "Nanded", Capacity = 100 });
                Add(new Department() { DeptNo = 70, DeptName = "D-70", Location = "Barshi", Capacity = 100 });
                Add(new Department() { DeptNo = 80, DeptName = "D-80", Location = "Latur", Capacity = 100 });
                Add(new Department() { DeptNo = 90, DeptName = "D-90", Location = "Nanded", Capacity = 100 });
                Add(new Department() { DeptNo = 100, DeptName = "D-100", Location = "Barshi", Capacity = 100 });
            }

        }

        internal class Emp
        {
            public int EmpNo { get; set; }
            public string EmpName { get; set; }
            //public string DeptName { get; set; }
            public int DeptNo { get; set; }
            public string Designation { get; set; }
            public float Salary { get; set; }
        }

        internal class Department
        {
            public int DeptNo { get; set; }
            public String DeptName { get; set; }
            public String Location { get; set; }
            public int Capacity { get; set; }
        }
    }

