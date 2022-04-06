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

            Console.WriteLine("Names: {0}.", string.Join(", ", distinctNames));

            List<Person> under18Persons = persons
                .Where(person => person.Age < 18)
                .ToList();

            double averageAge = under18Persons
                .Select(person => person.Age)
                .Average();

            Console.WriteLine("Average age of persons under 18: {0:f02}", averageAge);

            Dictionary<string, double> averageAgesByName = persons
                .GroupBy(person => person.Name, person => person.Age)
                .ToDictionary(group => group.Key, group => group.Average());

            Console.WriteLine();
            Console.WriteLine("[Name, Average age]");

            foreach (KeyValuePair<string, double> entry in averageAgesByName)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine();
            Console.WriteLine("Names of persons from 20 to 45 years old in descending order:");

            List<Person> from45to20AgePersons = persons
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .OrderByDescending(person => person.Age)
                .Select(person =>
                {
                    Console.WriteLine(person.Name);
                    return person;
                })
                .ToList();
        }
    }
}
