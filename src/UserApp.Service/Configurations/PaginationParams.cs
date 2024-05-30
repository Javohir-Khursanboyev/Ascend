using UserApp.Service.Helpers;

namespace UserApp.Service.Configurations;

public class PaginationParams
{
    public PaginationParams()
    {
        PageIndex = EnvironmentHelper.DefaultPageIndex;
        PageSize =  EnvironmentHelper.DefaultPageSize;
    }

    public int PageIndex { get; set; } 
    public int PageSize { get; set; } 
}