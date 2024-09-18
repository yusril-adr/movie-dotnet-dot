using dot_dotnet_test_api.API.Version1.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class DateOnlyValidator : AbstractValidator<DateOnlyRangeDto>
{
    public DateOnlyValidator()
    {
        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("page is required");
            

        RuleFor(x => x.PerPage)
            .NotEmpty().WithMessage("per_page is required");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("start_date is required");
            

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("end_date is required");
    }
}
