/*Week-5 (DAY-4) (Day-24) Hands-On
Problem 2 – Level 1:
Scenario:
An administrator wants to check file properties stored in a particular folder for auditing purposes.
Requirements:
1. Accept a folder path from the user.
2. Display file name, file size, and creation date.
3. Count and display the total number of files.
Technical Constraints:
• Use FileInfo class.
• Handle invalid directory paths.
Expectations:
The program should list file details clearly in the console.
Learning Outcome:
Students will understand how to retrieve file metadata using FileInfo.. */

///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;

namespace ConsoleApp8
{
    class Program
    {
        static void Main()
        {
            try
            {
                // 1. Accept folder path from user
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid folder path.");
                    return;
                }

                // Get all files from the directory
                string[] files = Directory.GetFiles(folderPath);

                int count = 0;

                Console.WriteLine("\nFile Details:");
                Console.WriteLine("--------------------------------------");

                // 2. Display file details using FileInfo
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    Console.WriteLine("File Name   : " + fi.Name);
                    Console.WriteLine("File Size   : " + fi.Length + " bytes");
                    Console.WriteLine("Created On  : " + fi.CreationTime);
                    Console.WriteLine("--------------------------------------");

                    count++;
                }

                // 3. Total number of files
                Console.WriteLine("Total Files: " + count);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}


