using static ApiExceptionType;

public class DeleteMe_Tests
{
    [Fact]
    public void MapToString_ShouldReturnLeft()
    {
        var numbers = new int?[] { 2, 3, 4, 5, null, null, 4, 6, null };

        var result = DeleteMe.MapToString(numbers);

        Assert.True(result.IsLeft);

        result.Match(
            Left: l => Assert.Equal(DeleteMeError.ToApiException(), l),
            Right: _ => throw new Exception()
        );
    }

    [Fact]
    public void MapToString_ShouldReturnRight()
    {
        var numbers = new int?[] { 2, 3, 4, 5, 4, 6 };
        var expected = new string[] { "2", "3", "4", "5", "4", "6" };

        var result = DeleteMe.MapToString(numbers);

        Assert.True(result.IsRight);

        result.Match(
            Left: _ => throw new Exception(),
            Right: r => Assert.Equal(expected, r)
        );
    }
}