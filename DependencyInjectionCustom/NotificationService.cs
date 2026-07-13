public class NotificationService(IService service)
{
    public void NotifyUser(string userEmail, string message)
    {
        service.SendService(userEmail, "Notification", message);
    }
}

public interface IService
{
    public void SendService(string to, string subject, string body);
}

public class EmailService (): IService
{
    public void SendService(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to: {to}");
    }
}

// public class MessageService
// {
//     // public void SendService(string to, string subject, string body)
//     // {
//     //     Console.WriteLine($"Sending message to: {to}");
//     // }
//     public string GetMessge(string userEmail, string message)
//     {
//         return $"Sending Message to: {userEmail}";
//     }
// }