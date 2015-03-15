using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //need this for any system input

namespace Assignment_5___File_IO___Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MenuMethod();

        }

        //Menu Method++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void MenuMethod()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; //declear the current path as a pathName
            string fileName = "GradeFile.txt"; //declear the file name

            int choice = 0; //declear local variable for choice

            while (choice != 2) //while loop menu
            {
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+           Menu          +");
                Console.WriteLine("+     1.Display Grades    +");
                Console.WriteLine("+     2.Exit              +");
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.Write("Enter your choice: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    choice = 0;
                    Console.WriteLine(error.Message);
                }
                switch (choice)
                {
                    case 1:
                        WriteFileMethod(pathName,fileName); //created the text file
                        CheckFile(); //check file if exist
                        ReadFileMethod(pathName, fileName); //display the file on console
                        break;
                    case 2://select to exit
                        Console.WriteLine();
                        break;
                    default: //display incorrect input message
                        Console.WriteLine();
                        Console.WriteLine("Incorrect input, please try again!");
                        Console.WriteLine();
                        WaitForKey(); //if incorrect input, then display wait for key info
                        break;
                }
                Console.Clear(); //clear the screen

            }
        }

        //CheckFile Method++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void CheckFile()
        {
            string prompt;
            Console.Write("Please enter a file name: ");
            prompt = Console.ReadLine();
            Console.WriteLine();

            if (File.Exists(prompt))
            {
                Console.WriteLine("The File Exists");
                Console.WriteLine();
                Console.WriteLine("File Stats:");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Create Time: " + File.GetCreationTime(prompt));
                Console.WriteLine("Last Access: " + File.GetLastAccessTime(prompt));
                Console.WriteLine("Last Write : " + File.GetLastWriteTime(prompt));
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            }
            else
            {
                Console.WriteLine("No such file");
            }
            WaitForKey();
        }


        //WriteFile Method++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void WriteFileMethod(string pathName, string fileName)
        {

            try
            {
                FileStream outFile = new FileStream(pathName + fileName, FileMode.Create, FileAccess.Write); //created a outFile in current path
                StreamWriter writer = new StreamWriter(outFile); //declear a wirter variable

                //data variable
                string[] firstName = { "Jones", "Johnson", "Smith" };
                string[] lastName = { "Bob", "Sarah", "Sam" };
                int[] ID = { 1, 2, 3 };
                string[] classes = { "Introduction to Computer Science", "Data Structures", "Data Structures" };
                string[] grade = { "A-", "B+", "C" };

                //wite data to the outFIle
                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine("{0}, {1}: {2} {3}, {4}", firstName[i], lastName[i], ID[i], classes[i], grade[i]);
                }

                writer.Close(); // closes the file
                outFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("Your code caused a darn error!!!");
                Console.WriteLine("Error: {0} ", error.Message);
            }
        }

        //ReadFile Method++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void ReadFileMethod(string pathName, string fileName)
        {
            string fileData = "";
            string[] fileArray = new string[10];
            try
            {
                FileStream inFile = new FileStream(pathName + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                for (int row = 0; row < 10; row++)
                {
                    fileData = reader.ReadLine();
                    fileArray[row] = fileData;

                    Console.WriteLine("Your Data: {0}", fileData);
                } // Read one record (line of data)
                reader.Close(); // closes the file
                inFile.Close(); // closes the  file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("Your code caused a darn error!!!");
                Console.WriteLine("Error: {0} ", error.Message);

            }
        }


        // UTILITY METHODS++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }



    }
}
