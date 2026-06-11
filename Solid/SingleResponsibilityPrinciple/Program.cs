using System;
using SOLID;

class Program
{
    static void Main(string[] args)
    {
        Membership membership = new Membership();
        User user = membership.CreateUser("Alamin", "Ridoy");

        Console.WriteLine("User created successfully:");
        Console.WriteLine($"Id: {user.Id}");
        Console.WriteLine($"UserName: {user.UserName}");
        Console.WriteLine($"Password: {user.Password}");
    }
}
