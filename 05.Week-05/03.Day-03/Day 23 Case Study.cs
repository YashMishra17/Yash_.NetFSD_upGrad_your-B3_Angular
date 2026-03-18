using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Requirement 5: Use List<string> to store tasks
        List<string> tasks = new List<string>();

        int choice;

        do
        {
            // Requirement 4: Menu-driven interface
            Console.WriteLine("\nTo-Do List Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            // Requirement 4: Handle invalid menu input
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Requirement 1: Add Task
                    Console.Write("Enter task: ");
                    string task = Console.ReadLine();

                    // Constraint: Task description must be non-empty
                    if (string.IsNullOrWhiteSpace(task))
                    {
                        Console.WriteLine("Task cannot be empty.");
                        break;
                    }

                    // Requirement 1: Store in order of addition
                    tasks.Add(task.Trim());

                    // Requirement 1: Confirmation message
                    Console.WriteLine("Task added!");
                    break;

                case 2:
                    // Requirement 2: View Tasks
                    if (tasks.Count == 0)
                    {
                        // Requirement 2: If empty
                        Console.WriteLine("Task list is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\nTasks:");

                        // Requirement 2: Display in order with numbering starting from 1
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }
                    }
                    break;

                case 3:
                    // Requirement 3: Remove Task

                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks to remove.");
                        break;
                    }

                    Console.Write("Enter task number to remove: ");

                    // Requirement 6: Handle non-numeric input
                    if (!int.TryParse(Console.ReadLine(), out int taskNumber))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }

                    // Constraint: Task numbers are 1-based
                    // Requirement 3: Validate range
                    if (taskNumber < 1 || taskNumber > tasks.Count)
                    {
                        Console.WriteLine("Invalid task number.");
                        break;
                    }

                    // Requirement 3: Remove and display removed task
                    string removedTask = tasks[taskNumber - 1];
                    tasks.RemoveAt(taskNumber - 1);

                    Console.WriteLine("Removed: " + removedTask);
                    break;

                case 4:
                    // Requirement 4: Exit
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    // Requirement 4: Handle invalid menu choice
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}