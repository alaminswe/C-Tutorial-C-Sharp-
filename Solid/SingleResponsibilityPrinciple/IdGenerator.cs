using System;

namespace SOLID;
public class IdGenerator
{
    public string GenerateId(string text)
    {
        Random random = new Random();
        return char.ToUpper(text[0]).ToString() + random.Next(1000, 9999);
    }

}