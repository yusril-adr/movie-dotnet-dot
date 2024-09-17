namespace dot_dotnet_test_api.Helpers;

public class CopiedFile
{
  public required string FilePath { get; set; }
  public required string SavedFileName { get; set; }
}

public class FileHelper()
{
    public static async Task<CopiedFile> CopyFile(IFormFile file, string path = "./files", string? prefix = null)
  {
    var splittedFileNames = file.FileName.Split(".");
    var fileExtension = splittedFileNames[^1];
    var filePath = Path.Combine(path, $"{Path.GetRandomFileName()}{(prefix != null ? $"-{prefix}" : "")}.{fileExtension}");

    using (var stream = File.Create(filePath))
    {
      await file.CopyToAsync(stream);
    }

    var savedSplitedFileNames = filePath.Split('/');
    var savedFileName = savedSplitedFileNames[^1];

    return new CopiedFile
    {
      SavedFileName = savedFileName,
      FilePath = filePath
    };
  }
}
