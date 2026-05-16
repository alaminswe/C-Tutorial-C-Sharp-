// Task: Create an array of 3 integers.
// Use a for loop to iterate through the array and print each value multiplied by 2
class Arrays_Loops
{
    static void Main(string[] args)
    {
        int[] myNumbers = new int[3];
        for(int i = 0; i < 3; i++)
        {
            myNumbers[i] = int.Parse(Console.ReadLine());
        }

        // 2. Use a for loop to iterate and print (value * 2) [5]
        for (int i = 0; i < myNumbers.Length; i++) 
        {
            Console.Write($"{myNumbers[i]*2} ");
        }
        Console.WriteLine();

        
        int[] listA = { 1, 2, 3 };
        int[] listB = listA; 
        // To change a value in the array, assign to an element, e.g.:
        listB[0] = 999;
        // To print the array contents:
        Console.WriteLine(string.Join(", ", listA));
    }
}