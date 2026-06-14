class Program
{
    static void Main(string[] args)
    {
        NotificationFactory factory = new EmailFactory();
        factory.SendNotification();
        // INotification notification = factory.CreateNotification();
        // notification.NotifyUser(); // 📧 Sending Email...

        // Runtime-a change
        factory = new SmsFactory();
        factory.SendNotification(); // 📱 Sending SMS...

        factory = new PushFactory();
        factory.SendNotification();
    }
}

public interface INotification
{
    void NotifyUser();
}

public class EmailNotification : INotification
{
    public void NotifyUser()
    {
        Console.WriteLine("📧 Sending Email Notification...");
    }
}

public class SmsNotification : INotification
{
    public void NotifyUser()
    {
        Console.WriteLine("📱 Sending SMS Notification...");
    }
}

public class PushNotification : INotification
{
    public void NotifyUser()
    {
        Console.WriteLine("🔔 Sending Push Notification...");
    }
}

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification();
    public void SendNotification()
    {
        INotification notification = CreateNotification();
        notification.NotifyUser();
    }
}
public class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification(); 
    }
}

public class SmsFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SmsNotification(); 
    }
}

public class PushFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification(); 
    }
}