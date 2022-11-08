public enum ApiExceptionType
{
    DeleteMeError,
    PayPalCaptureParseError,
}

public record ApiException(ApiExceptionType Type);

public static class ApiExceptionTypeExtensions
{
    public static ApiException ToApiException(this ApiExceptionType type) => new ApiException(type);
}
