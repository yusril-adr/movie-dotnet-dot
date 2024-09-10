
using dot_dotnet_test_api.Interfaces;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Types
{
  public class Pagination: IPagination {
    public int Page { get; set; }

    public int PerPage { get; set; }
    public int TotalItem { get;set; }

    public int totalPages { get; set; }

    public string? NextPageLink { get; set; } = null;
    
    public string? PreviousPageLink { get; set; } = null;
  }
}