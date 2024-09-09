using System.Security.Cryptography;
using dot_dotnet_test_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace dot_dotnet_test_api.Helpers;

public class LowercaseContractResolver : DefaultContractResolver
{
  protected override string ResolvePropertyName(string propertyName)
  {
    // Convert the property name to lowercase
    return propertyName.ToLower();
  }
}

public class Response<T>: IResponse<T>
{
  public bool Success { get; set; } = true;
  public string[]? Errors { get; set; }

  public string? Message { get; set; }

  public T? Data { get; set; }

  public Response(T? data = default, string? message = default, string[]? errors = default)
  {
    Message = message;
    Data = data;
    if (errors != null)
    {
      Errors = errors;
    }
    Success = errors == null || errors?.Length < 1;
  }

  public ContentResult GetFormated(int statusCode = 200)
  {
    var jsonResponse = GetFormatedJsonString();
    return new ContentResult(){
        Content = jsonResponse,
        ContentType = "application/json",
        StatusCode = statusCode,
    };
  }

    public string GetFormatedJsonString()
  {
    var settings = new JsonSerializerSettings
    {
      ContractResolver = new LowercaseContractResolver(),
      NullValueHandling = NullValueHandling.Ignore
    };

    // Serialize the object to JSON
    var jsonResponse = JsonConvert.SerializeObject(this, settings);
    return jsonResponse;
  }
}

public class ValidationErrorResponseField
{
  public string? Property { get; set; }
  public List<string> Messages { get; set; } = [];

  public ValidationErrorResponseField(string PropertyName)
  {
    Property = PropertyName;
  }
}

// Dummy class to represent no data
public class Unit { }

public class ValidationErrorResponse : Response<Unit>
{
  public bool Success { get; set; } = false;
  public string Message { get; set; } = "Validation Failed";

  public List<ValidationErrorResponseField> Errors { get; set; } = [];

  public new ContentResult GetFormated(int statusCode = StatusCodes.Status422UnprocessableEntity) {
    return base.GetFormated(statusCode);
  }

}
