class Program
{
    static void Main(string[] args)
    {
        var laptop = new Laptop();
        var europeanPlug = new EuropeanPlug();
        var adapter = new SocketAdapter(europeanPlug);

        laptop.Charge(adapter);
    }
}

public class EuropeanPlug
{
    public string GetEuropeanSocket()
    {
        return "European Socket";
    }
}

// Target interface expected by client
public interface IUSASocket
{
    string GetUSASocket();
}

//Adepter Cls
public class SocketAdapter: IUSASocket
{
    private readonly EuropeanPlug _europeanPlug;

    public SocketAdapter(EuropeanPlug europeanPlug)
    {
        _europeanPlug = europeanPlug;
    }
    public string GetUSASocket()
    {
        return  $"Adapter converting: {_europeanPlug.GetEuropeanSocket()}";
    }
}

public class Laptop
{
    public void Charge(IUSASocket socket)
    {
        Console.WriteLine($"Cherger Pluged in : {socket.GetUSASocket()}");
    }
}