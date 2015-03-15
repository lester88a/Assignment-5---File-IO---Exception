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
            int choice = 0; //declear local variable for choice
           
            while (choice!=2) //while loop menu
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
                }
                switch (choice)
                {
                    case 1:
                       
                        
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect input, please try again!");
                        Console.WriteLine();
                        break;
                }
                Console.Clear(); //clear the screen

            }
        }
    }
}
