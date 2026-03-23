/*Week-5 (DAY-4) (Day-24) Hands-On
Problem 4 – Level 2
Scenario:
A development team wants to analyze all folders inside a project directory to understand the project structure.
Requirements:
1. Accept a root directory path.
2. Display all subdirectories inside the root folder.
3. Show the number of files present in each directory.
Technical Constraints:
• Use DirectoryInfo class.
• Use loops to iterate through directories.
• Implement exception handling.
Expectations:
The application should display folder names and file counts for each directory.
Learning Outcome:
Students will learn how to navigate directories and retrieve folder information using DirectoryInfo.
 */

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
                // 1. Accept root directory path
                Console.Write("Enter root directory path: ");
                string path = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Invalid directory path.");
                    return;
                }

                // Create DirectoryInfo object
                DirectoryInfo root = new DirectoryInfo(path);

                // 2. Get all subdirectories
                DirectoryInfo[] directories = root.GetDirectories();

                Console.WriteLine("\nFolder Details:");
                Console.WriteLine("-----------------------------------");

                // 3. Loop through each directory
                foreach (DirectoryInfo dir in directories)
                {
                    // Get files inside each directory
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine("Folder Name : " + dir.Name);
                    Console.WriteLine("File Count  : " + files.Length);
                    Console.WriteLine("-----------------------------------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied to folder.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}


