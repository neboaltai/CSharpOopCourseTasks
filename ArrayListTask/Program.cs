using System;

namespace ArrayListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(3) { 1, 2, 3 };

            Console.WriteLine("List of integers: " + list);

            Console.WriteLine("List capacity: " + list.Capacity);

            Console.WriteLine("Count of list items: " + list.Count);

            list.Add(4);

            list.Insert(list.Count - 1, 5);

            Console.WriteLine($"Add the integer 4 to the end and then insert integer 5 at index {list.Count - 1}: {list}");

            Console.WriteLine("List capacity: " + list.Capacity);

            if (list[list.Count - 1] != list.Count)
            {
                Console.Write("List in wrong order, ");

                if (list.Contains(list.Count))
                {
                    list.RemoveAt(list.IndexOf(list.Count));

                    list.Add(list.Count + 1);
                }
            }

            Console.WriteLine("correct list: " + list);

            string line = list.Remove(6) ? "has been removed" : "was not removed";
            Console.WriteLine("The integer 6 " + line);

            list.TrimExcess();
            Console.WriteLine("List capacity after TrimExcess(): " + list.Capacity);

            list.Capacity += list[0];
            Console.WriteLine($"Increase capacity by {list[0]}: {list.Capacity}");

            int[] integers = new int[4];
            Console.WriteLine("Array size: " + integers.Length);

            list.CopyTo(integers, 1);
            Console.WriteLine("Copy list to array starting index 1: " + string.Join(", ", integers));

            list.Clear();
            Console.WriteLine("Count of list after Clear(): " + list.Count);
        }
    }
}
