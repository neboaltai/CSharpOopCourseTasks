using System;

namespace HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> courseTasks = new HashTable<string>(20) { "Shapes", "Vector", "Matrix", "Csv", "List" };

            Console.WriteLine("Проверенные задачи: " + courseTasks);
            Console.WriteLine("Наличие среди них текущей задачи: " + courseTasks.Contains("HashTable"));
            Console.WriteLine("Наличие среди них задачи из прошлого курса: " + courseTasks.Contains("Csv"));

            courseTasks.Add("ArrayList");
            courseTasks.Add("HashTable");
            courseTasks.Add("Tree");
            courseTasks.Add("Temperature");
            courseTasks.Add("MinesweeperUI");

            Console.WriteLine($"Все задачи ({courseTasks.Count}): {courseTasks}");

            string[] allTasks = new string[14];

            allTasks[0] = "Range";
            allTasks[1] = "ArrayListHome";
            allTasks[2] = "Lambdas";
            allTasks[3] = "Graph";

            courseTasks.CopyTo(allTasks, 4);
            Console.WriteLine("Список заданий на курс: " + string.Join(", ", allTasks));

            Console.WriteLine("Зачтена задача Shapes: " + courseTasks.Remove("Shapes"));
            Console.WriteLine("Зачтена задача Vector: " + courseTasks.Remove("Vector"));
            Console.WriteLine("Зачтена задача Csv: " + courseTasks.Remove("Csv"));

            courseTasks.Add(null);
            Console.WriteLine("Проверка успешного добавления/удаления null: " + courseTasks.Remove(null));

            courseTasks.Clear();
            Console.WriteLine($"Список после очистки ({courseTasks.Count}): {courseTasks}");
        }
    }
}
