using System.Reflection.Metadata.Ecma335;

class Assignment_6
{
    static void Main(string[] args)
    {
        // //fahrenheit to celsius
        // double fahrenheit, celsius;
        // Console.Write("fahrenheit: ");
        // fahrenheit = Convert.ToDouble(Console.ReadLine());
        
        // celsius = (fahrenheit-32)/1.8;
        // Console.WriteLine($"celsius : {celsius:F2} degress");

        //assignment celsius to fahrenheit
        double fahrenheit, celsius;
        Console.Write("celsius: ");
        celsius = Convert.ToDouble(Console.ReadLine());
        
        fahrenheit = (1.8*celsius)+32;
        Console.WriteLine($"fahrenheit : {fahrenheit:F2} degress");

    }
}