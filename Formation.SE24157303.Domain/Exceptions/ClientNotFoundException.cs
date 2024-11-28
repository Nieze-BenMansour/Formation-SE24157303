namespace Formation.SE24157303.Domain.Exceptions;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException(string? message) : base(message)
    {
    }
}
