using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CS_Directories.Logic
{
    internal class DirectoryOperations
    {
        static string key = String.Empty;
        public void CreateDirectoiry(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            else
            {
                Console.WriteLine($"Directory {dirName} is already present");
            }
        }

        public void ReadAllFileFromDirectory()
        {
            // 3 Parameters
            // p1: The Directory Name
            // p2: The Pattern to Read files
            // p3: The Current Directory File or files from all of its Subdirectories
            var files = Directory.GetFiles("C:\\New folder", "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        public void ReadAllFileFromDirectoryWithLINQ()
        {
            // 3 Parameters
            // p1: The Directory Name
            // p2: The Pattern to Read files
            // p3: The Current Directory File or files from all of its Subdirectories
            // Change in .NET Frwk 4.0+
            var files = from file in Directory.GetFiles("C:\\New folder", "*.txt", SearchOption.AllDirectories)
                        select file;

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        public void ReadAllFiles(string dirName)
        {
            string filePath = null;
            string userPreferedFile = string.Empty;
            int choice = 0;
            var files = from file in Directory.GetFiles(dirName, "*.txt", SearchOption.AllDirectories)
                        select file.Substring(0);
            List<String> filesInDirectory = new List<String>();
            foreach (var file in files)
            {
                filesInDirectory.Add(file);
                //Console.WriteLine(file);
            }
            foreach (var file in filesInDirectory)
            {
                Console.WriteLine(file);
            }
            //Console.WriteLine(filesInDirectory.IndexOf($"{dirName}\\NewFile.txt"));

            do
            {
                Console.WriteLine("From Above Displyaed Files,Enter File Name With Extension Whose Data You Want To Read");
                userPreferedFile = Console.ReadLine();
                filePath = $"{dirName}\\{userPreferedFile}";
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Enter 1 to read entire file or 2 read perticular line from file");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {

                        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                        // 2. Create an Instance of StreamReader
                        StreamReader reader = new StreamReader(fs);
                        string data = reader.ReadToEnd();
                        Console.WriteLine(data);
                    }
                    else if (choice == 2)
                    {
                        ReadDataFromFile(userPreferedFile, dirName);
                    }
                    else
                    {
                        Console.WriteLine("Oh oh! Invalid choice");
                    }
                }
                else
                {
                    Console.WriteLine("File Doesn't Exist");
                }
                Console.WriteLine("Do you want to read another file? Enter any key to continue. If not then Enter No");
                key = Console.ReadLine();
                if (key.ToUpper().Contains("NO"))
                {
                    return;
                }
            } while (true);
        }

        void ReadDataFromFile(string userPreferedFileName, string FolderPath)
        {
            int line;
            string filePath = $"{FolderPath}\\{userPreferedFileName}";
            key = string.Empty;

            do
            {
                Console.WriteLine("Enter The Line Number You Wish Read Data From That!");
                try
                {
                    line = int.Parse(Console.ReadLine());

                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                    // 2. Create an Instance of StreamReader
                    StreamReader reader = new StreamReader(fs);

                    //char[] data = reader.ReadLine().Skip(2).Take(1).ToArray(); 15-1
                    string data = File.ReadLines(filePath).Skip(line - 1).Take(1).FirstOrDefault();//limit x, offset y
                    reader.Close();
                    if (data != null)
                    {
                        Console.WriteLine($"Data from specified line:\n{data}");
                    }
                    else
                    {
                        Console.WriteLine("Hmmm!Looks Like An Empty Line!");
                    }
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Do you want to read another line? Enter any key to put up specific line. If not then Enter No");
                key = Console.ReadLine();
                if (key.ToUpper().Contains("NO"))
                {
                    return;
                }
            } while (true);
        }


        public static void FileInformation(/*string userPreferedFileName, string FolderPath*/)
        {
            //int line;
            /*string filePath = $"{FolderPath}\\{userPreferedFileName}";
            key = string.Empty;*/

            System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\");
            // Get the root directory and print out some information about it.
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            foreach (System.IO.FileInfo fi in fileNames)
            {
                Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
            }

            // Get the subdirectories directly that is under the root.
            // See "How to: Iterate Through a Directory Tree" for an example of how to
            // iterate through an entire tree.
            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }
        }

        public static void FileInfoo()
        {
            string filePath = "C:\\New folder\\Salaries";
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath); //Assuming C:\New folder\Salaries is your Folder

            FileInfo[] Files = directoryInfo.GetFiles("*.txt"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                Console.WriteLine(file);
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Extension);
                Console.WriteLine(file.LastAccessTime);
                Console.WriteLine($"Size of File {file.Name} In Bytes:{file.Length}\n");
            }            
        }
    }
}