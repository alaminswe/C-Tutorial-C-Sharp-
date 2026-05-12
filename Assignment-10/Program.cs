
class Assignment_10
{
    static void Main(string[] args)
    {

        Console.WriteLine("Showing Weekday or weekend: ");
        Console.Write("Enter a day: ");
        string? day = Console.ReadLine();

        if (!string.IsNullOrEmpty(day))
        {
            day = day.ToLower();

            switch (day)
            {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                    Console.WriteLine($"{day} is a weekday.");
                    break;

                case "friday":
                case "saturday":
                    Console.WriteLine($"{day} is a weekend.");
                    break;

                case "sunday":
                    Console.WriteLine($"{day} is a weekday.");
                    break;

                default:
                    Console.WriteLine($"{day} is an invalid day.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Nullvalue");
        }

        // Console.WriteLine("Switch Uses: ");

        // char input;
        // Console.Write("Enter a valid input ('A-Z' || 'a-z'): ");
        // input = Convert.ToChar(Console.ReadLine()!);

        // input = char.ToLower(input);
        // //multiline swtich controlling
        // switch (input)
        // {
        //     case 'a':
        //     case 'e':
        //     case 'i':
        //     case 'o':
        //     case 'u':
        //         Console.WriteLine($"{input} is a vowel.");
        //         break;
        //     default:
        //         if (char.IsLetter(input))
        //         {
        //             Console.WriteLine($"{input} is consonent.");
        //             break;
        //         }
        //         else
        //         {
        //             Console.WriteLine($"{input} is not a valid input.");
        //         }
        //         break;
        // }

    }
}