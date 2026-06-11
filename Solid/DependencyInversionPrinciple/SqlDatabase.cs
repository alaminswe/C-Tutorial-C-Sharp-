public class SqlDatabase : IDatabase
{
    private List<object> _storage = new List<object>();

    public void Save(object entity)
    {
        _storage.Add(entity); // List --> add
        Console.WriteLine($"[SQL Server] Saved → {entity}");
    }

    public void ShowSaved()
    {
        Console.WriteLine("\n[SQL Server] 📋 Saved Orders:");
        foreach (var item in _storage)
        {
            Console.WriteLine($"  → {item}");
        }
    }
}