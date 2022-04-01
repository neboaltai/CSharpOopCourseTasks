using System;

namespace ListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> companies = new SinglyLinkedList<string>(new SinglyLinkedListNode<string>("Sovcombank"));

            companies.AddFirst(new SinglyLinkedListNode<string>("Movavi"));
            companies.AddFirst(new SinglyLinkedListNode<string>("BKS"));
            companies.AddFirst(new SinglyLinkedListNode<string>("Intabia"));
            companies.Add(3, new SinglyLinkedListNode<string>("Friday's Games"));

            Console.WriteLine("Исходный список: ");

            for (SinglyLinkedListNode<string> node = companies.Head; node != null; node = node.Next)
            {
                Console.WriteLine("\t" + node.Data);
            }

            Console.WriteLine("Размер списка: " + companies.Count);

            Console.WriteLine("Значение первого элемента: " + companies.GetFirstValue());

            Console.WriteLine($"Замена значения \"{companies.SetValue(1, "CFT")}\" второго элемента значением \"{companies.GetValue(1)}\"");

            Console.WriteLine("Удалён третий элемент со значением: " + companies.RemoveAt(2));

            companies.Reverse();
            Console.WriteLine("Получившийся список в обратном порядке:");

            for (SinglyLinkedListNode<string> node = companies.Head; node != null; node = node.Next)
            {
                Console.WriteLine("\t" + node.Data);
            }

            string value = companies.GetValue(1);

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

            Console.WriteLine("Копия получившегося список: ");

            for (SinglyLinkedListNode<string> node = copy.Head; node != null; node = node.Next)
            {
                Console.WriteLine("\t" + node.Data);
            }
        }
    }
}
