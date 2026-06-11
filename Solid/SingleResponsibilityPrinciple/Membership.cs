namespace SOLID;

public class Membership
{

    public User CreateUser( string username, string password)
    {

        EncryptionUtility encryptionUtility = new EncryptionUtility();
        IdGenerator idGenerator = new IdGenerator();

        User user = new User();
        
        user.Id = idGenerator.GenerateId(username);
        user.UserName = username;
        user.Password = encryptionUtility.EncryptText(password);

        return user;
    }

}