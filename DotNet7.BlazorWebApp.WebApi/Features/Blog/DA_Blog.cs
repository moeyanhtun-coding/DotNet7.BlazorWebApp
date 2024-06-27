using DotNet7.BlazorWebApp.WebApi.Database;
using DotNet7.BlazorWebApp.WebApi.Models.Blog;
using DotNet7.BlazorWebApp.WebApi.Models.PageSetting;
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
            (int totalCount, int pageCount) = await query.PageCountAsync(pageSize);
            var lst = await query.Pagination(pageNo, pageSize).ToListAsync();
            var data = lst.Select(x => x.Change()).ToList();

            model.DataList = data;
            model.PageSettingModel = new PageSettingModel(pageNo, pageSize, totalCount, pageCount);

            responseModel = Result<BlogResponseModel>.SuccessResult(model);
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogResponseModel>.FailureResult(ex.ToString());
        }
        return responseModel;
    }

    public async Task<Result<BlogModel>> GetBlog(int id)
    {
        var responseModel = new Result<BlogModel>();
        try
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                responseModel = Result<BlogModel>.FailureResult();
                goto Result;
            }
            responseModel = Result<BlogModel>.SuccessResult(item.Change());
        }
        catch (Exception ex)
        {
            responseModel = Result<BlogModel>.FailureResult(ex.ToString());
        }
        Result:
        return responseModel;
    }

    public async Task<Result<string>> CreateBlog(BlogModel reqModel)
    {
        var responseModel = new Result<string>();
        try
        {
            await _context.Blogs.AddAsync(reqModel.Change());
            var result = await _context.SaveChangesAsync();
            responseModel = Result<string>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            responseModel = Result<string>.FailureResult(ex.ToString());
        }
        return responseModel;
    }

    public async Task<Result<string>> UpdateBlog(int id, BlogModel reqModel)
    {
        var responseModel = new Result<string>();
        try
        {
            var item = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                responseModel = Result<string>.FailureResult();
                goto Result;
            }

            #region BlogModel Null Value Checking
            if (!string.IsNullOrEmpty(reqModel.BlogTitle))
                item.BlogTitle = reqModel.BlogTitle;
            if (!string.IsNullOrEmpty(reqModel.BlogAuthor))
                item.BlogAuthor = reqModel.BlogAuthor;
            if (!string.IsNullOrEmpty(reqModel.BlogContent))
                item.BlogContent = reqModel.BlogContent;
            #endregion

            _context.Entry(item).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();
            responseModel = Result<string>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            responseModel = Result<string>.FailureResult(ex.ToString());
        }
        Result:
        return responseModel;
    }

    public async Task<Result<string>> DeleteBlog(int id)
    {
        var responseModel = new Result<string>();
        try
        {
            var item = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item == null)
            {
                responseModel = Result<string>.FailureResult();
                goto Result;
            }
            _context.Blogs.Remove(item!);
            int result = await _context.SaveChangesAsync();
            responseModel = Result<string>.ExecuteResult(result);
        }
        catch (Exception ex)
        {
            responseModel = Result<string>.FailureResult(ex.ToString());
        }
        Result:
        return responseModel;
    }
}
