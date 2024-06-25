namespace DotNet7.BlazorWebApp.WebApi.Models.PageSetting;

public class PageSettingModel
{
    public PageSettingModel(int pageNo, int pageSize, int totalCount, int pageCount)
    {
        PageNo = pageNo;
        PageSize = pageSize;
        TotalCount = totalCount;
        PageCount = pageCount;
    }

    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public bool IsEndOfPage
    {
        get { return PageNo == PageCount; }
    }
}