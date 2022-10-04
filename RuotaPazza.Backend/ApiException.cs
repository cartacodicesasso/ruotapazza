public enum ApiExceptionType
{
    DeleteMeError
}

public record ApiException(ApiExceptionType Type);

public static class ApiExceptionTypeExtensions
{
    public static ApiException ToApiException(this ApiExceptionType type) => new ApiException(type);
}
