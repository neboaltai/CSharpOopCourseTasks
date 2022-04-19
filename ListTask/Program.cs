using System;

namespace ListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> companies = new SinglyLinkedList<string>("Sovcombank");

            companies.AddFirst("Movavi");
            companies.AddFirst("BKS");
            companies.AddFirst("Intabia");
            companies.Add(3, "Friday's Games");

            Console.WriteLine("Исходный список: " + companies);

            Console.WriteLine("Размер списка: " + companies.Count);

            Console.WriteLine("Значение первого элемента: " + companies.GetFirst());

            companies[1] = "CFT";
            Console.WriteLine($"Замена значения второго элемента значением \"{companies[1]}\"");

            Console.WriteLine("Удалён третий элемент со значением: " + companies.RemoveAt(2));

            companies.Reverse();
            Console.WriteLine("Получившийся список в обратном порядке: " + companies);

            string value = companies[1];

            Console.Write($"Удалён элемента по значению: \"{value}\"");

            if (companies.Remove(value))
            {
                Console.WriteLine(" прошло успешно");
            }
            else
            {
                Console.WriteLine(" не выполнено. Элемент не найден");
            }

            Console.WriteLine("Удаление первого элемента со значением: " + companies.RemoveFirst());

            SinglyLinkedList<string> copy = companies.Copy();

            Console.WriteLine("Копия получившегося списка: " + copy);
        }
    }
}
