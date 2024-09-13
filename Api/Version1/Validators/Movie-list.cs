using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class MovieListValidator : AbstractValidator<MovieListDto>
{
    public MovieListValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("page is required");
            
        RuleFor(x => x.PerPage)
            .NotEmpty().WithMessage("per_page is required");
    }
}
