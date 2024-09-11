using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class TransactionV1OrderValidator : AbstractValidator<TransactionV1OrderDto>
{
    public TransactionV1OrderValidator()
    {
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("items is required");

        RuleForEach(x => x.Items).ChildRules(item => 
          item.RuleFor(x => x.MovieScheduleId)
            .NotEmpty().WithMessage("movie_schedule_id is required")
        );

        RuleForEach(x => x.Items).ChildRules(item => 
          item.RuleFor(x => x.Qty)
            .GreaterThan(0).WithMessage("qty must greater than 0")
            .NotEmpty().WithMessage("qty is required")
        );
    }
}
