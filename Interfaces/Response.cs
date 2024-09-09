namespace dot_dotnet_test_api.Interfaces
{
  public interface IResponse<T>
  {
    bool Success { get; set; }
    string[]? Errors { get; set; }

    string? Message { get; set; }

    T? Data { get; set; }
  }
}