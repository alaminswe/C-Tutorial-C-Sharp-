
class Assignment_8
{
    static void Main(string[] args)
    {
        int num1, num2;
        Console.Write("Enter a number: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a number: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        if(num1>num2)
        {
            Console.WriteLine($"{num1} is bigger than {num2}");
        }
        else if(num2>num1)
        {
            Console.WriteLine($"{num2} is bigger than {num1}");
        }
        else
        {
            Console.WriteLine($"{num2} is equal {num1}");
        }

    }
}