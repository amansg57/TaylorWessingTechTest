namespace CompaniesAPI.Exceptions;
public class ExternalApiException : Exception
{
    public int StatusCode { get; } = 500;
    public ExternalApiException() : base()
    {
    }

    public ExternalApiException(int statusCode) : base()
    {
        StatusCode = statusCode;
    }

    public ExternalApiException(string message) : base(message)
    {
    }

    public ExternalApiException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public ExternalApiException(string message, Exception innerException) : base(message, innerException)
    {
    }
}