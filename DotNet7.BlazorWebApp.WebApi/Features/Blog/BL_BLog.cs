using System.Diagnostics;
using DotNet7.BlazorWebApp.WebApi.Models.Blog;
using DotNet7.BlazorWebApp.WebApi.ResponseModel;

namespace DotNet7.BlazorWebApp.WebApi.Features.Blog;

public class BL_BLog
{
    private readonly DA_Blog _dA_Blog;

    public BL_BLog(DA_Blog dA_Blog)
    {
        _dA_Blog = dA_Blog;
    }

    public async Task<Result<List<BlogModel>>> GetBlog(int pageNo, int pageSize)
    {
        var responseModel = new Result<List<BlogModel>>();
        try
        {
            if (pageNo < 0)
                throw new Exception("PageNo Invalid!");
            if (pageSize < 0)
                throw new Exception("PageSize Invalid");
            responseModel = await _dA_Blog.GetBlog(pageNo, pageSize);
        }
        catch (Exception ex)
        {
            responseModel = Result<List<BlogModel>>.FailureResult(ex.ToString());
        }
        return responseModel;
    }

    public async Task<Result<BlogModel>> GetBlog(int id)
    {
        var responseModel = new Result<BlogModel>();
        try
        {
            if (id <= 0)
            {
                responseModel = Result<BlogModel>.FailureResult();
                goto Result;
            }
            responseModel = await _dA_Blog.GetBlog(id);
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
            IsValidate(reqModel);
            responseModel = await _dA_Blog.CreateBlog(reqModel);
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
            if (id <= 0)
            {
                responseModel = Result<string>.FailureResult();
                goto Result;
            }
            responseModel = await _dA_Blog.UpdateBlog(id, reqModel);
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
            if(id <= 0)
            {
                responseModel = Result<string>.FailureResult(); goto Result;
            }
            responseModel = await _dA_Blog.DeleteBlog(id);
        }
        catch (Exception ex)
        {
            responseModel = Result<string>.FailureResult(ex.ToString());
        }
        Result:
        return responseModel;
    }

    #region BlogModel Validation
    private static void IsValidate(BlogModel model)
    {
        if (model is null)
            throw new Exception("Mode can't be null!");
        if (string.IsNullOrEmpty(model.BlogTitle))
            throw new Exception("Blog Title can't be null!");
        if (string.IsNullOrEmpty(model.BlogAuthor))
            throw new Exception("Blog Author can't be null!");
        if (string.IsNullOrEmpty(model.BlogContent))
            throw new Exception("Blog Content can't be null!");
    }
    #endregion
}
