using DotNet7.BlazorWebApp.WebApi.Models.Blog;
using DotNet7.BlazorWebApp.WebApi.ResponseModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

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

    public static async Task<(int, int)> PageCountAsync<T>(this IQueryable<T> query, int pageSize)
    {
        int totalCount = await query.CountAsync();
        var pageCount = totalCount / pageSize;
        if (totalCount % pageSize > 0)
        {
            pageCount++;
        }
        return (totalCount, pageCount);
    }
}
