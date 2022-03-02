using System;
using CS_Directories.Logic;
namespace CS_Directories
{
    internal class Program
    {
        static DirectoryOperations dirOp;

        static void Main(string[] args)
        {
            dirOp = new DirectoryOperations();
            Console.WriteLine("USing Directories");
            //dirOp.CreateDirectoiry("C:\\New folder\\MyDir");
            // dirOp.ReadAllFileFromDirectory();
            // dirOp.ReadAllFileFromDirectoryWithLINQ();
            dirOp.ReadAllFiles("C:\\New folder\\Salaries"); //14-Feb-20222 Question 1,2&3 
            // Console.WriteLine("Done");
            //DirectoryOperations.FileInfoo();//14-Feb-20222 Question 4
        }
    }
}