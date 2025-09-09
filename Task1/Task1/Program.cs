// See https://aka.ms/new-console-template for more information
Console.Write("Enter your name:");
string name = Console.ReadLine();
Console.WriteLine(name);
Console.Write("enter your age:");
int age = int.Parse(Console.ReadLine());


Console.Write($"Hi {name},");
Console.WriteLine($"Your age is:{age}");

