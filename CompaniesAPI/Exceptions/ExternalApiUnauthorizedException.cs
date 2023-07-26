namespace CompaniesAPI.Exceptions;
public class ExternalApiUnauthorizedException : ExternalApiException
{
    public ExternalApiUnauthorizedException() : base(401)
    {
    }

    public ExternalApiUnauthorizedException(string message) : base(message, 401)
    {
    }

    public ExternalApiUnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
