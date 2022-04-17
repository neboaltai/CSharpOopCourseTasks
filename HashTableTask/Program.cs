using System;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> courseTasks = new HashTable<string>(20) { "Shapes", "Vector", "Matrix", "Csv", "List" };

            Console.WriteLine("Verified tasks: " + courseTasks);
            Console.WriteLine("The presence of the current task among them: " + courseTasks.Contains("HashTable"));
            Console.WriteLine("The presence of tasks from the previous course among them: " + courseTasks.Contains("Csv"));

            courseTasks.Add("ArrayList");
            courseTasks.Add("HashTable");
            courseTasks.Add("Tree");
            courseTasks.Add("Temperature");
            courseTasks.Add("MinesweeperUI");

            Console.WriteLine($"All tasks ({courseTasks.Count}): {courseTasks}");

            string[] allTasks = new string[14];

            allTasks[0] = "Range";
            allTasks[1] = "ArrayListHome";
            allTasks[2] = "Lambdas";
            allTasks[3] = "Graph";

            courseTasks.CopyTo(allTasks, 4);
            Console.WriteLine("List of tasks and homeworks for the course: " + string.Join(", ", allTasks));

            Console.WriteLine("Task Shapes passed: " + courseTasks.Remove("Shapes"));
            Console.WriteLine("Task Vector passed: " + courseTasks.Remove("Vector"));
            Console.WriteLine("Task Csv passed: " + courseTasks.Remove("Csv"));

            courseTasks.Add(null);
            Console.WriteLine("Checking successful adding/removing null: " + courseTasks.Remove(null));

            courseTasks.Clear();
            Console.WriteLine($"List after cleaning ({courseTasks.Count}): {courseTasks}");
        }
    }
}
