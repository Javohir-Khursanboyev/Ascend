using UserApp.Service.Helpers;

namespace UserApp.Service.Configurations;

public class PaginationParams
{
    public int PageIndex { get; set; } = EnvironmentHelper.DefaultPageIndex;
    public int PageSize { get; set; } = EnvironmentHelper.DefaultPageSize;
}