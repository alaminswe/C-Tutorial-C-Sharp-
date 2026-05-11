
class Assignment_7
{
    static void Main(string[] args)
    {
        int num1;
        Console.Write("Enter a number: ");
        num1 = Convert.ToInt32(Console.ReadLine());

        if(num1%2!=0)
        {
            Console.WriteLine($"{num1} is odd number");
        }
        else
        {
            Console.WriteLine($"{num1} is even number");
        }

    }
}