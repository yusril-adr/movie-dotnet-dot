using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace dot_dotnet_test_api.Interfaces;
  public interface IPagination {
    [JsonProperty("page")]
    int Page { get; set; }

    [JsonProperty("per_page")]
    int PerPage { get; set; }
    [JsonProperty("total_item")]
    int TotalItem { get;set; }

    [JsonProperty("total_pages")]
    int totalPages { get; set; }

    [JsonProperty("next_page_link")]
    string? NextPageLink { get; set; }
    
    [JsonProperty("previous_page_link")]
    string? PreviousPageLink { get; set; }
  }

  public interface IResponse<T>
  {
    bool Success { get; set; }
    string? Error { get; set; }

    string? Message { get; set; }

    T? Data { get; set; }

    IPagination? Pagination { get; set; }
  }