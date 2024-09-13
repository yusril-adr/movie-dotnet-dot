
using dot_dotnet_test_api.Interfaces;

namespace dot_dotnet_test_api.Types
{
  public class Pagination: IPagination {
    public int Page { get; set; }

    public int PerPage { get; set; }
    public int TotalItem { get;set; }

    public int TotalPages { get; set; }
  }
}