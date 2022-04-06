using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person("Sayan", 17),
                new Person("Zhanna", 19),
                new Person("Vladimir", 14),
                new Person("Anna", 21),
                new Person("Nikolay", 25),
                new Person("Daniel", 56),
                new Person("Ekaterina", 42),
                new Person("Dmitry", 24),
                new Person("Aleksander", 16),
                new Person("Dmitry", 23),
                new Person("Anna", 20)
            };

            List<string> distinctNames = persons
                .Select(person => person.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Имена: {0}.", string.Join(", ", distinctNames));

            List<Person> under18Persons = persons
                .Where(person => person.Age < 18)
                .ToList();

            double averageAge = under18Persons
                .Select(person => person.Age)
                .Average();

            Console.WriteLine("Средний возраст людей, младше 18 лет: {0:f02}", averageAge);

            Dictionary<string, double> averageAgesByName = persons
                .GroupBy(person => person.Name, person => person.Age)
                .ToDictionary(group => group.Key, group => group.Average());

            Console.WriteLine();
            Console.WriteLine("[Имя, Средний возраст]");

            foreach (KeyValuePair<string, double> entry in averageAgesByName)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
