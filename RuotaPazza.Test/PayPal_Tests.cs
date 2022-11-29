using System.Text.Json;
using LanguageExt;
using static ApiExceptionType;

public class PayPal_Tests
{
    private JsonDocument json = JsonDocument.Parse(@"
        {
            ""resource"": {
                ""id"": ""12A34567BC123456S"",
                ""amount"": {
                    ""currency_code"": ""EUR"",
                    ""value"": ""10.00""
                }
            }
        }
    ");

    [Fact]
    public void ToCapture_ShouldWork()
    {
        var result = json.ToCapture();

        Assert.True(result.IsRight);

        result.Match(
            Left: _ => throw new Exception(),
            Right: capture =>
            {
                Assert.Equal("12A34567BC123456S", capture.Id);
                Assert.Equal("EUR", capture.Currency);
                Assert.Equal(10, capture.Amount);
            }
        );
    }

    [Fact]
    public void PayPal_ShouldWork()
    {
        var result = PayPal.HandleEvent(json);

        Assert.True(result.IsRight);

        result.Match(
            Left: _ => throw new Exception(),
            Right: r => Assert.Equal(new Unit(), r)
        );
    }

    [Fact]
    public void PayPal_ShouldFailSafely()
    {
        var result = PayPal.HandleEvent(JsonDocument.Parse("{}"));

        Assert.True(result.IsLeft);

        result.Match(
            Right: _ => throw new Exception(),
            Left: l => Assert.Equal(PayPalCaptureParseError.ToApiException(), l)
        );
    }
}