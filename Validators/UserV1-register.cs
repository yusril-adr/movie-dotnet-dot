using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class UserV1RegisterDtoValidator : AbstractValidator<UserV1RegisterDto>
{
    public UserV1RegisterDtoValidator()
    {
        // Rule: Name should not be empty and must have at least 3 characters
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long");

        // Rule: Email should not be empty and must be a valid email format
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        // Rule: Password should not be empty and must contain at least 10 characters, 
        // at least one uppercase letter, one lowercase letter, and one number
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number");
    }
}
