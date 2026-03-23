/*Week-5 (DAY-4) / Day - 26
 * Hands-On
Problem 5 – Level 2
Scenario:
An IT administrator wants to monitor disk storage and identify drives that are running out of space.
Requirements:
1. Retrieve all system drives.
2. Display drive name, drive type, total size, and available free space.
3. Display a warning if free space is below 15%.
Technical Constraints:
• Use DriveInfo class.
• Ensure the drive is ready before accessing properties.
• Use loops to process multiple drives.
Expectations:
The program should display drive health information and warn the user about low disk space.
Learning Outcome:
Students will learn how to retrieve and analyze system storage information using DriveInfo.*/

///////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Get all drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive Name: " + drive.Name);

                // Check if drive is ready
                if (drive.IsReady)
                {
                    Console.WriteLine("Drive Type: " + drive.DriveType);
                    Console.WriteLine("Total Size: " + drive.TotalSize + " bytes");
                    Console.WriteLine("Free Space: " + drive.AvailableFreeSpace + " bytes");

                    // Calculate free space percentage
                    double freePercent = (double)drive.AvailableFreeSpace / drive.TotalSize * 100;

                    Console.WriteLine("Free Space (%): " + freePercent.ToString("F2") + "%");

                    // Warning if less than 15%
                    if (freePercent < 15)
                    {
                        Console.WriteLine("⚠ Warning: Low disk space!");
                    }
                }
                else
                {
                    Console.WriteLine("Drive not ready.");
                }

                Console.WriteLine("---------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
