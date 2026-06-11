public class OrderService
{
    private readonly IDatabase _database;

    // Constructor Injection 
    public OrderService(IDatabase database)
    {
        _database = database;
    }

    public void SaveOrder(Order order)
    {
        Console.WriteLine($"\nProcessing order for {order.CustomerName}...");
        _database.Save(order); 
        Console.WriteLine("Order processing complete!");
    }

    public void ShowAllOrders()
    {
        _database.ShowSaved();
    }
}
