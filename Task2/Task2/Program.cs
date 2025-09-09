
using System;
using System.Collections.Generic;
//class Program
//{
//    public static void Main()
//    {
//        Student obj = new Student();
//        for (int i = 0; i < 2; i++)
//        {
//            Console.WriteLine("Enter student Name:");
//            obj.name = Console.ReadLine();
//            Console.WriteLine("Enter student age:");
//            obj.age = int.Parse(Console.ReadLine());
//            obj.PrintDetails();
//        }
//        Console.ReadKey();
//    }
//}

//class Student
//{
//    public int age; 
//    public string name; 
//        public void PrintDetails()
//        {
//            Console.WriteLine("Student Details");
//            Console.WriteLine($"Name: {name}");
//            Console.WriteLine($"Age:{age}");
//        }   
//}

class Program
{
    public static void Main()
    {
        Student obj = new Student();
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Enter student Name:");
            string name = Console.ReadLine();
            obj.name.Add(name);
            Console.WriteLine("Enter student age:");
            int age = int.Parse(Console.ReadLine());
            obj.age.Add(age);
            obj.PrintDetails();
        }
        //Console.ReadKey();
    }
}
public class Student
{
    //public int age;
    //public string name;

    public List<string> name = new List<string>();
    public List<int> age = new List<int>();
    public void PrintDetails()
    {
        Console.WriteLine("Student Details");
        foreach (var i in name)
        {
            Console.WriteLine($"Name: {i}");
        }
        foreach (var j in age)
        {
            Console.WriteLine($"Age: {j}");
        }
    }
}

