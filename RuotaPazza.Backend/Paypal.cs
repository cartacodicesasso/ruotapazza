using System.Text.Json;
using LanguageExt;

public static class PayPal
{
    public static Either<ApiException, Unit> HandleEvent(object context)
    {
        var json = JsonSerializer.Serialize(context, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);

        return new Unit();
    }
}