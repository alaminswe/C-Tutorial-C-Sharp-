public class OrderService
{
    private readonly IDatabase _database;
    public OrderService(IDatabase database)
    {
        _database = database;
    }
    public void Save()
    {
        Console.WriteLine($"Saved in : {_database.SaveData()}");
    }
}