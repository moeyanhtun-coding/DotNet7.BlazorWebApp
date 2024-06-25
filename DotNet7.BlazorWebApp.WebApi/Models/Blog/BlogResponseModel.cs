using DotNet7.BlazorWebApp.WebApi.Models.PageSetting;

namespace DotNet7.BlazorWebApp.WebApi.Models.Blog;

public class BlogResponseModel
{
    public List<BlogModel> DataList { get; set; }
    public PageSettingModel PageSettingModel { get; set; }
}