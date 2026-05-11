class Assignment_3
{
    static void Main(string[] args)
    {
        
        string? studentName;
        int studentAge;
        double studentGpa;
        bool isRegistured;

        Console.Write("Enter your name: ");
        studentName = Console.ReadLine();

        Console.Write("Enter your age: ");
        studentAge = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your gpa: ");
        studentGpa= Convert.ToDouble(Console.ReadLine());

        Console.Write("Is student registered ? : ");
        isRegistured= Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine("Name: " + studentName);
        Console.WriteLine("Age: " + studentAge);
        Console.WriteLine("Gpa: " + studentGpa);
        Console.WriteLine("student registered: " + isRegistured);

    }
}