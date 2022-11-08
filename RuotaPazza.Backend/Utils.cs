using System.Text.Json;
using LanguageExt;
using static ApiExceptionType;

public static class Utils
{
    public static Either<ApiException, PayPalCapture> ToCapture(this JsonDocument document)
    {
        try
        {
            var resource = document.RootElement.GetProperty("resource");
            var amount = resource.GetProperty("amount");

            var capture = new PayPalCapture
            {
                Id = resource.GetProperty("id").GetString() ?? throw new Exception(),
                Amount = decimal.Parse(amount.GetProperty("value").GetString() ?? throw new Exception()),
                Currency = amount.GetProperty("currency_code").GetString() ?? throw new Exception()
            };

            return capture;
        }
        catch
        {
            return Either<ApiException, PayPalCapture>.Left(PayPalCaptureParseError.ToApiException());
        }
    }
}