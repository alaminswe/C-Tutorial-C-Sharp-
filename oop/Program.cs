
using System.Collections.Concurrent;
using System.ComponentModel;



class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
        // Create an instance of Bank (from separate Bank.cs file)
        Bank myBank = new Bank();
        myBank.BankMethod();
       
        Bank b = new Bank();
        b.BankMethod();

    }
}