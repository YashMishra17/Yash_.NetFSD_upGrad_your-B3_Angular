/*Week-6 (DAY-1) / Day - 25
 * Hands-On
Level-2 Problem 4: Asynchronous Order Processing System
Scenario:
 An e-commerce system processes customer orders. Each order requires multiple steps such as payment verification, inventory check, and order confirmation. These steps involve delays and should be handled asynchronously.
 
Requirements:
 - Create asynchronous methods:
   - VerifyPaymentAsync()
   - CheckInventoryAsync()
   - ConfirmOrderAsync()
 - Simulate processing delays using Task.Delay().
 - Execute steps asynchronously while maintaining the logical order of operations.
Technical Constraints:
 - Use async and await.
 - Use Task-based asynchronous methods.
 - Implement using a console application.
 
Expectations:
 - Each processing step should run asynchronously.
 - The program should display messages indicating the progress of order processing.
 
Learning Outcome:
 Students will understand how to design real-world workflows using asynchronous methods with async/await.*/

///////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Order Processing Started...\n");

            try
            {
                // Step 1 → Payment
                await VerifyPaymentAsync();

                // Step 2 → Inventory
                await CheckInventoryAsync();

                // Step 3 → Confirmation
                await ConfirmOrderAsync();

                Console.WriteLine("\nOrder processed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        // Step 1: Payment Verification
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000); // simulate delay
            Console.WriteLine("Payment verified.");
        }

        // Step 2: Inventory Check
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(3000); // simulate delay
            Console.WriteLine("Inventory available.");
        }

        // Step 3: Order Confirmation
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(1500); // simulate delay
            Console.WriteLine("Order confirmed.");
        }
    }
}