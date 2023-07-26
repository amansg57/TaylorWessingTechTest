namespace CompaniesAPI.Exceptions;
public class ExternalApiNotFoundException : ExternalApiException
{
    public ExternalApiNotFoundException() : base(404)
    {
    }

    public ExternalApiNotFoundException(string message) : base(message, 404)
    {
    }

    public ExternalApiNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
