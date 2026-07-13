
// public class ObjectFactory<T>
// {
//     public static T Get()
//     {
//         if (typeof(T)==typeof(NotificationService))
//         {
//             var emailService = ObjectFactory<EmailService>.Get();
//             return (T) (object) new NotificationService(emailService);
//         }

//         if (typeof(T)==typeof(EmailService))
//         {
//             var msgService = ObjectFactory<MessageService>.Get();
//             return (T)(object)new EmailService(msgService);
//         }

//         if (typeof(T) == typeof(MessageService))
//         {
//             return (T)(object)new MessageService();
//         }

//         throw new ArgumentException($"No implementation found for key: {typeof(T)}");
//     }
// }


