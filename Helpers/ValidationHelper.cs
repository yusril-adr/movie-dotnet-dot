using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace dot_dotnet_test_api.Helpers;
public class ValidationHelper
{
  public static ContentResult ValidateResponseError(ValidationResult results, string message = "Validation Failed")
  {
    var errors = new List<ValidationErrorResponseField>();
    var properties = new List<string>();
    foreach (var failure in results.Errors)
    {
      if (properties.Exists(prop => prop == failure.PropertyName))
      {
        var error = errors.Find(e => e.Property == failure.PropertyName);
        var errorIdx = errors.FindIndex(e => e.Property == failure.PropertyName);
        error?.Messages.Add(failure.ErrorMessage);
        errors[errorIdx] = error;
      }
      else
      {
        var error = new ValidationErrorResponseField(PropertyName: failure.PropertyName);
        error.Messages.Add(failure.ErrorMessage);
        errors.Add(error);
        properties.Add(failure.PropertyName);
      }
    }

    var errorResponse = new ValidationErrorResponse
    {
      Errors = errors,
      Message = message
    };
    return errorResponse.GetFormated();
  }
}