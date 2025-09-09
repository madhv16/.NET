using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();

        for (int i = 0; i < 2; i++)
        {
            Console.Write("Enter student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student Age: ");
            int age = int.Parse(Console.ReadLine());

            students.Add(new Student { Name = name, Age = age });
        }

        Console.WriteLine("All Student Details:");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        }

      
        var adults = students.Where(s => s.Age >= 18).ToList();

        Console.WriteLine("Students aged 18 or older:");
        foreach (var student in adults)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        }
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
