/*Week-6 (DAY-1) / Day - 25
 * Hands-On
Problem 5 Level-2: Application Tracing for Order Processing
Scenario
An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
Requirements
Create a console application that simulates order processing.
The order processing should include the following steps:
oValidate Order
oProcess Payment
oUpdate Inventory
oGenerate Invoice
Use Trace class to log messages at each step of the process.
Display trace messages showing the execution flow.
Technical Constraints
Use System.Diagnostics.Trace.
Write trace messages using:
oTrace.WriteLine()
oTrace.TraceInformation()
Configure a TextWriterTraceListener to store trace logs in a file.
Implement the solution using .NET console application.
Expectations
The application should log messages for each stage of order processing.
Trace logs should help developers identify where failures occur.
The trace output should be stored in a log file.
Learning Outcome
Students will learn how to:
Implement application tracing using System.Diagnostics.
Monitor application flow using Trace listeners.
Use trace logs to diagnose runtime issues in real-world applications.

*/

///////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static async Task Main()
        {
            // Configure Trace to write into a file
            Trace.Listeners.Add(new TextWriterTraceListener(@"C:\CSharp\OrderLog.txt"));
            Trace.AutoFlush = true;

            try
            {
                Trace.WriteLine("Order Processing Started");

                await ValidateOrder();
                await ProcessPayment();
                await UpdateInventory();
                await GenerateInvoice();

                Trace.TraceInformation("Order processed successfully.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error occurred: " + ex.Message);
            }

            Console.WriteLine("Process completed. Check log file.");
            Console.ReadLine();
        }

        static async Task ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating Order...");
            await Task.Delay(1000); // NON-BLOCKING
            Trace.TraceInformation("Order validated successfully.");
        }

        static async Task ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing Payment...");
            await Task.Delay(1000);

            // Simulate failure (change to false to test)
            bool paymentSuccess = true;

            if (!paymentSuccess)
            {
                throw new Exception("Payment failed.");
            }

            Trace.TraceInformation("Payment processed successfully.");
        }

        static async Task UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating Inventory...");
            await Task.Delay(1000);
            Trace.TraceInformation("Inventory updated.");
        }

        static async Task GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating Invoice...");
            await Task.Delay(1000);
            Trace.TraceInformation("Invoice generated.");
        }
    }
}
