using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class MovieV1BackOfficeListValidator : AbstractValidator<MovieV1BackOfficeListDto>
{
    public MovieV1BackOfficeListValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("page is required");
            

        RuleFor(x => x.PerPage)
            .NotEmpty().WithMessage("per_page is required");
    }
}
