namespace DotNet7.BlazorWebApp.WebApi;

public static class DevCode
{
    public static IQueryable<TSource> Pagination<TSource>(
        this IQueryable<TSource> source,
        int pageNo,
        int pageSize
    )
    {
        return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
    }
}
