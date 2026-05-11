using System.Reflection.Metadata.Ecma335;

class Assignment_5
{
    static void Main(string[] args)
    {
        //Assignment area of circle
        Console.Write("Enter redius: ");
        double redius = Convert.ToDouble(Console.ReadLine());
        const double pi = 3.1416;
        
        double area = pi * redius * redius;
        Console.WriteLine($"area of circle: {area.ToString("F2")}");

        // //Assignment area of triangleArea
        // Console.Write("Enter base: ");
        // int baseLength = Convert.ToInt32(Console.ReadLine());

        // Console.Write("Enter height: ");
        // int height = Convert.ToInt32(Console.ReadLine());

        // const double con = 0.5;
        
        // double triangleArea = con * baseLength * height;
        // Console.WriteLine($"area of triangleArea: {triangleArea.ToString("F2")}");
        

    }
}