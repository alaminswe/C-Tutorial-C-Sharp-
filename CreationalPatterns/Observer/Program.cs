class Program
{
    static void Main(string[] args)
    {
        var channel1 = new NewsChannel("NTV");
        var channel2 = new NewsChannel("Somoy TV");
        var mobileApp = new MobileApp();

        var agency = new NewsAgency();

        agency.Subscribe(channel1);
        agency.Subscribe(channel2);
        agency.Subscribe(mobileApp);


        agency.SetNews("The Observer Pattern works!");

        Console.WriteLine();
        agency.Unsubscribe(channel2);

        agency.SetNews("Breaking: Bangladesh wins!");
    }
}

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void NotifyAll(string message);
}

public class NewsChannel : IObserver
{
    private string _channelName;

    public NewsChannel(string name)
    {
        _channelName = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"📺 [{_channelName}] Breaking: {message}");
    }
}

public class MobileApp : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"📱 [Mobile App] Push Alert: {message}");
    }
}

public class NewsAgency : ISubject
{
    private readonly List<IObserver> _observers = new();
    private string _latestNews;

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"✅ New subscriber ! Total: {_observers.Count}");
    }
    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"❌ Unsubscribed! Remaining: {_observers.Count}");
    }
    public void NotifyAll(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public void SetNews(string news)
    {
        _latestNews = news;
        Console.WriteLine($"\n🗞️ NewsAgency published: '{news}'");
        NotifyAll(news);
    }
}