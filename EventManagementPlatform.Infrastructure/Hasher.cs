using System.Security.Cryptography;
using System.Text;
using EventManagementPlatform.Application.Interfaces;

namespace EventManagementPlatform.Infrastructure;

public class Hasher : IHasher
{
    public string GetHash(string str)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        byte[] hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes);
    }
}