namespace EventManagementPlatform.Application.Interfaces;

public interface IHasher
{
    string GetHash(string str);
}