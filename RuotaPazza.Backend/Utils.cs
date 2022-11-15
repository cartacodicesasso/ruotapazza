using System.Text.Json;
using LanguageExt;
using static ApiExceptionType;

public static class Utils
{
    public static Either<E, A> TryCatch<E, A>(Func<A> func, Func<Exception, E> onError)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return Either<E, A>.Left(onError(e));
        }
    }

    public static Either<ApiException, PayPalCapture> ToCapture(this JsonDocument document) =>
        TryCatch(() =>
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
        }, (_) =>
        {
            Console.WriteLine("Wrong capture payload.");
            Console.WriteLine(JsonSerializer.Serialize(document));

            return PayPalCaptureParseError.ToApiException();
        });
}