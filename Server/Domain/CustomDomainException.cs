namespace Server.Domain;

public class CustomDomainException : Exception
{
    public CustomDomainException(string message) : base(message)
    {
    }
}