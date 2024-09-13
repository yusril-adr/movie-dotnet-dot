using dot_dotnet_test_api.API.Version1.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {

        // Rule: Email should not be empty and must be a valid email format
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        // Rule: Password should not be empty
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
