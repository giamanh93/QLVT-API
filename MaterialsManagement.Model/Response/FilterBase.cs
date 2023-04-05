namespace MaterialsManagement.Model.Response
{
    public class FilterBase
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public FilterBase()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public FilterBase(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
