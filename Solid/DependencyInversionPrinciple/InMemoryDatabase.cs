public class InMemoryDatabase : IDatabase
{
    private List<object> _storage = new List<object>();

    public void Save(object entity)
    {
        _storage.Add(entity);
        Console.WriteLine($"[InMemory] Saved → {entity}");
    }

    public void ShowSaved()
    {
        Console.WriteLine("\n[InMemory] 📋 Saved Orders:");
        foreach (var item in _storage)
        {
            Console.WriteLine($"  → {item}");
        }
    }
}