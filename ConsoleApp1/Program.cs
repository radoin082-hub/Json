using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string filePath = "C:/Users/radoi/RiderProjects/ConsoleApp1/ConsoleApp1/a.json";

        // Read existing data from the JSON file
        List<Person> people = ReadJsonFile(filePath);

        // Display existing data
        Console.WriteLine("Existing Data:");
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
        }

        // Add a new person from user input
        Console.WriteLine("\nAdding a new person...");
        Console.Write("Enter ID: ");
        int newId = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string newName = Console.ReadLine();

        var newPerson = new Person
        {
            Id = newId,
            Name = newName
        };
        people.Add(newPerson);

        // Save the updated list back to the JSON file
        WriteJsonFile(filePath, people);

        Console.WriteLine("New person added and saved to file.");
    }

    static List<Person> ReadJsonFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Person>();
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Person>>(json) ?? new List<Person>();
    }

    static void WriteJsonFile(string filePath, List<Person> people)
    {
        string json = JsonConvert.SerializeObject(people, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}