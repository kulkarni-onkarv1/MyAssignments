using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Humanizer;

namespace CS_Imperative_LINQ
{
    internal class EmployeeSalarySlips
    {
        static string fileName=string.Empty;
        static string filePath=string.Empty;
        static string EmpNoInString=string.Empty;
        static float Gross;
        static float Tax;
        static int NetSalary;
        public static void CreateEmployeeSalarySlip(int EmpNo,string EmpName,string DeptName,string Designation,float Salary,float HRA,float TS,float DA)
        {
             Gross = Salary + HRA + TS + DA;
             SalaryBreakupCalculation.IncomeWiseTaxCalculation(Gross,out Tax);
             NetSalary = (int)Gross - (int)Tax;
             EmpNoInString =EmpNo.ToString();
             fileName = $"Salary-for-Feb-2022-{EmpNoInString}.txt";
             filePath = $"C:\\New folder\\Salaries\\{fileName}";

            // 1. Create a FileStream Object
            // The File will be Open if it exists: FileMode.OpenOrCreate

            // The File is Opened for the Write Operations: FileAccess.Write  
            //FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

            /* // 2. Create an Instance of StreamWriter
             StreamWriter writer = new StreamWriter(fs);

             // 3. Write Data to Stream
             writer.WriteLine("" +
        "------------------------Salary Slip for Month of Feb---------------------------" +
     $"\n| EmpNo: {EmpNo}          EmpName: {EmpName}         DeptName: {DeptName}     |" +
     $"\n| Designation:  {Designation}                                                 |" +
     "\n|------------------------------------------------------------------------------|" +
     "\n|Income (Rs.)					| Deduction (Rs.)				              |" +
     "\n|------------------------------- |---------------------------------------------|" +
     $"\n|Basic Salary:	{Salary}		|								              |" +
     $"\n|HRA:			{HRA}			|								              |" +
     $"\n|TA:            {TS}			|								              |" +
     $"\n|DA:            {DA}			|								              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n| Gross:        {Gross}         |								              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n|                                Tax:			{Tax}			              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n|NetSalary:		{NetSalary}		|								              |" +
     "\n|------------------------------------------------------------------------------|" +
     $"\n|NetSalary In Words:{NetSalary.ToWords()}				              |" +
     "\n|------------------------------------------------------------------------------|");

             // 4. Close Stream to Make sure that the Stream of data is commited to file
             writer.Close();

             // 5. Close Stream to Commit the File
             fs.Close();*/


            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream= new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] content = new UTF8Encoding(true).GetBytes(
                          "------------------------Salary Slip for Month of Feb---------------------------" +
     $"\n| EmpNo: {EmpNo}          EmpName: {EmpName}         DeptName: {DeptName}     |" +
     $"\n| Designation:  {Designation}                                                 |" +
     "\n|------------------------------------------------------------------------------|" +
     "\n|Income (Rs.)					| Deduction (Rs.)				              |" +
     "\n|------------------------------- |---------------------------------------------|" +
     $"\n|Basic Salary:	{Salary}		|								              |" +
     $"\n|HRA:			{HRA}			|								              |" +
     $"\n|TA:            {TS}			|								              |" +
     $"\n|DA:            {DA}			|								              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n| Gross:        {Gross}         |								              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n|                                Tax:			{Tax}			              |" +
     "\n|--------------------------------|---------------------------------------------|" +
     $"\n|NetSalary:		{NetSalary}		|								              |" +
     "\n|------------------------------------------------------------------------------|" +
     $"\n|NetSalary In Words:{NetSalary.ToWords()}				                                         |" +
     "\n|------------------------------------------------------------------------------|");

            formatter.Serialize(fs, content);
            fs.Close();
        }
    }
}
