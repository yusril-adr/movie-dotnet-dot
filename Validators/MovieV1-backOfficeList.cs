using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class MovieV1BackOfficeList : AbstractValidator<MovieV1BackOfficeListDto>
{
    public MovieV1BackOfficeList()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("page is required");
            

        RuleFor(x => x.PerPage)
            .NotEmpty().WithMessage("per_page is required");
    }
}
