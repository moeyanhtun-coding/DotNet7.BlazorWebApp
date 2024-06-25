using DotNet7.BlazorWebApp.WebApi.Database;
using DotNet7.BlazorWebApp.WebApi.Models.Blog;

namespace DotNet7.BlazorWebApp.WebApi;

public static class MapperServices
{
    public static TblBlogs Change(this BlogModel reqModel)
    {
        var model = new TblBlogs()
        {
            BlogTitle = reqModel.BlogTitle,
            BlogAuthor = reqModel.BlogAuthor,
            BlogContent = reqModel.BlogContent
        };
        return model;
    }
    
    public static BlogModel Change(this TblBlogs reqModel)
    {
        var model = new BlogModel()
        {
            BlogTitle = reqModel.BlogTitle,
            BlogAuthor = reqModel.BlogAuthor,
            BlogContent = reqModel.BlogContent
        };
        return model;
    }
}