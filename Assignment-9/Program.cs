
class Assignment_9
{
    static void Main(string[] args)
    {
        Console.WriteLine("Grade Calculator: ");

        double input;
        Console.Write("Enter a valid input (0-100): ");
        input = Convert.ToDouble(Console.ReadLine());

        string grade = "";
        bool valid = true;

        if (input > 89 && input <= 100)
        {
            grade = "A";
        }
        else if (input > 79 && input < 90)
        {
            grade = "B";
        }
        else if (input > 69 && input < 80)
        {
            grade = "C";
        }
        else if (input > 59 && input < 70)
        {
            grade = "D";
        }
        else if (input >= 0 && input <= 59)
        {
            grade = "F";
        }
        else
        {
            valid = false;
        }

        if (valid)
        {
            Console.WriteLine($"letter grade is {grade}");
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }

        // int year;
        // Console.Write("Enter year: ");
        // year = Convert.ToInt32(Console.ReadLine());

        // if(year%400==0 || year%4==0 && year%100!=0){
        //     Console.WriteLine($"{year} is a Leap year");
        // }else{
        //     Console.WriteLine($"{year} is not a Leap year");
        // }


    }
}