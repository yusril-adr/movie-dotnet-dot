using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class UserV1LoginDtoValidator : AbstractValidator<UserV1LoginDto>
{
    public UserV1LoginDtoValidator()
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
