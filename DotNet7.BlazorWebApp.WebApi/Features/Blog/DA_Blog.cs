using DotNet7.BlazorWebApp.WebApi.Database;
using DotNet7.BlazorWebApp.WebApi.Models.Blog;
using DotNet7.BlazorWebApp.WebApi.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.BlazorWebApp.WebApi.Features.Blog;

public class DA_Blog
{
    private readonly AppDbContext _context;

    public DA_Blog(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<BlogResponseModel>> GetBlog(int pageNo, int pageSize)
    {
        var model = new BlogResponseModel();
        var responseModel = new Result<BlogResponseModel>();
        try
        {
            var query = _context.Blogs.AsNoTracking();
        }
        catch (Exception ex)
        {
           throw;
        }
    }
}