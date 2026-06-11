using System;
using System.Security.Cryptography;
using System.Text;

namespace SOLID;
public class EncryptionUtility
{
    public string EncryptText(string plainText)
    {
        using MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}