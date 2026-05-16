// Task: Create a class named Product with two public fields: Name (string) and Price (double).
// Add a parameterized constructor to initialize these fields when a new object is created
class Classes_Constructors
{
    static void Main(string[] args)
    {
        Product p1 = new Product("Laptop", 999.99);
        p1.Display();

    }
}

class Product 
{
    public string Name{get;set;}
    public double Price{get;set;}

    // 2. Create a parameterized constructor 
    public Product(string name, double price) 
    {
        // Initialize fields
        Name = name;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"Product name: {Name} and Price: {Price}");
    }
}