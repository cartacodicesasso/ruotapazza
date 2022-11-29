using LanguageExt;

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
}
