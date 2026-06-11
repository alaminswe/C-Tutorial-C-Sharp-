class Program
{
    static void Main(string[] args)
    {
        var calculator = new AreaCalculator();


        var rectangle = new Rectangle { Width = 5.0, Height = 4.0 };
        Console.WriteLine(rectangle);
        var circle = new Circle { Radius = 3.0 };
        Console.WriteLine(circle);
        Console.WriteLine(calculator.CalculateArea(rectangle));
        Console.WriteLine(calculator.CalculateArea(circle));
    }
}
