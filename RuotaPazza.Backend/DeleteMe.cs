using LanguageExt;

public static class DeleteMe
{
    public static Either<ApiException, IEnumerable<string>> MapToString(IEnumerable<int?> nums) => nums
        .Select(n => n.ToOption())
        .Traverse(o => o.ToString())
        .ToEither((ApiException)new BadRequestApiException());
}