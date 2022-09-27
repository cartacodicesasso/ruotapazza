using LanguageExt;
using Microsoft.AspNetCore.Mvc;

public static class WebApplicationExtensions
{
    public static RouteHandlerBuilder MapPost<TIn, TOut>(this IEndpointRouteBuilder endpoints, string pattern, Func<TIn, Either<ApiException, TOut>> handler) =>
        endpoints.MapPost(pattern, ([FromBody] TIn x) => handler(x).ToHttpResult());

    static IResult ToHttpResult<TOut>(this Either<ApiException, TOut> either) =>
        either.Match(
            Left: _ => Results.StatusCode(500),
            Right: r => Results.Ok(r)
        );
}