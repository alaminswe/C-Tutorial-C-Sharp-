using System.Reflection.Metadata.Ecma335;

class Assignment_4
{
    static void Main(string[] args)
    {
        //Assignment start from here
        Console.Write("Enter num1: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter num2: ");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter num3: ");
        int num3 = Convert.ToInt32(Console.ReadLine());

        int result = num1+num2+num3;
        Console.WriteLine($"Sum of three numbers: {num1} + {num2} = {result}");
        double avg = (double)result/3;
        Console.WriteLine("Avg of three numbers: " + avg.ToString("F2"));

        
        // int num1 = 10;
        // int num2 = 3;
        // int result;

        // result = num1 + num2;
        // Console.WriteLine("Addition: " + result);

        // result = num1 - num2;
        // Console.WriteLine("Subtraction: " + result);

        // result = num1 * num2;
        // Console.WriteLine("Multiplication: " + result);

        // // result = num1 / num2;
        // double div = (double)num1 / num2;
        // Console.WriteLine("Division: " + div.ToString("F3"));

        // result = num1 % num2;
        // Console.WriteLine("Remainder: " + result);

    }
}