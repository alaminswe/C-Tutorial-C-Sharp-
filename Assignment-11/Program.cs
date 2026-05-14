
using System.Diagnostics.CodeAnalysis;

class Assignment_11_Student_Management_System
{
    static void Main(string[] args)
    {

        try
        {
            Student alamin = new Student("Alamin",new DateTime (2001,01,25),"24");
            alamin.Display();
            Console.WriteLine($"{alamin.Name}'s age is : {alamin.Age}");
            Student ridoy = new Student("Ridoy",new DateTime (2021,6,27),"23");
            ridoy.Display();
            Console.WriteLine($"{ridoy.Name}'s age is : {ridoy.Age}");
        }catch(Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
        
    }
}
class Student
{

    public Student(string name, DateTime dateOfBirth, string roll)
    {
        CheckingError(name,  dateOfBirth, roll);
        
        Name = name;
        DateOfBirth = dateOfBirth;
        RollNumber = roll;
    }

    public string Name
    {
        get ;

        private set ;
    }
    public string RollNumber
    {
        get ;

        private set ;
    }
    public DateTime DateOfBirth
    {
        get ;

        private set ;
    }

    private int CalculateAge()
    {
        // if (DateOfBirth==null)
        // {
        //     return 0;
        // }
        int age = DateTime.Now.Year - DateOfBirth.Year;
        if (DateTime.Now<DateOfBirth.AddYears(age))
        {
            age--;
        }
        return age;
    }

    public int Age
    {
        get{ return CalculateAge(); }
    }

    public void Display()
    {
        Console.WriteLine($"Student Name: {Name}");
        Console.WriteLine($"Student Date of bith: {DateOfBirth}");
        Console.WriteLine($"Student Roll: {RollNumber}");

    //     Console.WriteLine($"Student Name: {_name}");
    //     Console.WriteLine($"Student Date of bith: {_dateOfBirth}");
    //     Console.WriteLine($"Student Roll: {_rollNumber}");
    }

    private static void CheckingError(string name, DateTime dateOfBirth, string roll)
    {
        if (DateTime.Now < dateOfBirth)
        {
            throw new ArgumentException("Date of birth can not be in the future.");
        }

        if (dateOfBirth==default)
        {
            throw new ArgumentException("Date of birth can not be null.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name Can not be nul.");
        }

        if (string.IsNullOrEmpty(roll))
        {
            throw new ArgumentException("roll Can not be nul.");
        }
    }

}