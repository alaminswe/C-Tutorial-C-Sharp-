
class TemperatureConverter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Temperature Converter Started");
        Console.WriteLine("Choice 1. Fahrenheit to Celsius");
        Console.WriteLine("Choice 2. Celsius to Fahrenheit");

        int choice = Convert.ToInt32(Console.ReadLine());
        double fahrenheit, celsius;
        switch (choice)
        {
            case 1:
                Console.Write("Enter Fahrenheit Temperature: ");
                fahrenheit = Convert.ToDouble(Console.ReadLine());
                celsius = (fahrenheit - 32) / 1.8;
                Console.WriteLine($"Temperature in celsius : {celsius:F2} degress");
                break;
            case 2:
                Console.Write("Enter celsius Temperature: ");
                celsius = Convert.ToDouble(Console.ReadLine());

                fahrenheit = (1.8 * celsius) + 32;
                Console.WriteLine($"Temperature in fahrenheit : {fahrenheit:F2} degress");
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }

    }
}