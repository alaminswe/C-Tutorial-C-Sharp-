public class Program
{
    public static void Main()
    {
        Console.WriteLine("========== SQL Database ==========");

        IDatabase sqlDb = new SqlDatabase();
        OrderService sqlService = new OrderService(sqlDb);

        sqlService.SaveOrder(new Order
        {
            Id = 1,
            ProductName = "Laptop",
            Amount = 75000,
            CustomerName = "Rahim"
        });

        sqlService.SaveOrder(new Order
        {
            Id = 2,
            ProductName = "Mouse",
            Amount = 500,
            CustomerName = "Karim"
        });

        sqlService.ShowAllOrders();

        Console.WriteLine("\n========== MongoDB ==========");

        IDatabase mongoDb = new MongoDatabase();
        OrderService mongoService = new OrderService(mongoDb);

        mongoService.SaveOrder(new Order
        {
            Id = 3,
            ProductName = "Phone",
            Amount = 25000,
            CustomerName = "Jamal"
        });

        mongoService.SaveOrder(new Order
        {
            Id = 4,
            ProductName = "Headphone",
            Amount = 2000,
            CustomerName = "Ritu"
        });

        mongoService.ShowAllOrders();

        Console.WriteLine("\n========== InMemory (Testing) ==========");

        IDatabase inMemoryDb = new InMemoryDatabase();
        OrderService testService = new OrderService(inMemoryDb);

        testService.SaveOrder(new Order
        {
            Id = 5,
            ProductName = "Keyboard",
            Amount = 1500,
            CustomerName = "Sadia"
        });

        testService.ShowAllOrders();
    }
}