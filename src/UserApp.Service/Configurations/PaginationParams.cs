namespace UserApp.Service.Configurations;

public class PaginationParams
{
    public PaginationParams(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
    public PaginationParams() { }
 
    public int PageIndex { get; set; }
    public int PageSize { get; set; } 
}