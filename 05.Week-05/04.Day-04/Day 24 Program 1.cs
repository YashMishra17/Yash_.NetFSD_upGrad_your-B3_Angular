/*Week-5 (DAY-4) (Day-24) Hands-On
Problem 1 – Level 1
Scenario:
A small organization wants to store simple log messages into a text file using a C# console application.
Requirements:
1. Accept a message from the user.
2. Write the message into a file using FileStream.
3. Append multiple messages to the same file.
4. Display confirmation after writing the data.
Technical Constraints:
• Use FileStream class.
• Use appropriate FileMode and FileAccess.
• Implement exception handling for file access errors.
Expectations:
The application should successfully write user messages to the file and allow multiple entries.
Learning Outcome:
Students will learn how to create and write data into files using FileStream. */

///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Text;

namespace ConsoleApp8
{
    class Program
    {
        static void Main()
        {
            // File path
            string filePath = @"C:\CSharp\LogFile.txt";

            try
            {
                // Create folder if it does not exist
                if (!Directory.Exists(@"C:\CSharp"))
                {
                    Directory.CreateDirectory(@"C:\CSharp");
                }

                // 1. Take message from user
                Console.Write("Enter message: ");
                string message = Console.ReadLine();

                // Convert message to bytes (FileStream needs bytes)
                byte[] data = Encoding.UTF8.GetBytes(message + "\n");

                // 2 & 3. Write into file using FileStream (Append mode)
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                fs.Write(data, 0, data.Length);

                // Close file
                fs.Close();

                // 4. Confirmation message
                Console.WriteLine("Message saved successfully!");
            }
            catch (Exception ex)
            {
                // Handle errors
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}



