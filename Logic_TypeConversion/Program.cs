// Task: You have a string input from a user. 
// Convert it to an int using the Convert class, 
// and then use an if/else block to print "Positive" if the number is greater than 0 and "Negative or Zero" otherwise
class Logic_TypeConversion
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number > 0)
        {
            Console.WriteLine("Positive");
        }
        else
        {
            Console.WriteLine("Negative or Zero");
        }
    }
}