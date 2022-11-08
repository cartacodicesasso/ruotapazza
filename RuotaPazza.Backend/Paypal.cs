using System.Text.Json;
using LanguageExt;

public static class PayPal
{
    public static Either<ApiException, Unit> HandleEvent(JsonDocument document) =>
        document
            .ToCapture()
            .Map(capture =>
            {
                /*
                TODO:
                - TEST
                - Get donor e-mail address from PayPal
                - Save shit to DB
                */
                Console.WriteLine(capture);
                return new Unit();
            });
}

public record PayPalCapture
{
    public string Id { get; init; } = null!;
    public string Currency { get; init; } = null!;
    public decimal Amount { get; init; }
}