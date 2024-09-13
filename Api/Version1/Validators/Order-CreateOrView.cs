using dot_dotnet_test_api.API.Version1.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.API.Version1.Validators;
public class OrderCreateOrViewValidator : AbstractValidator<OrderCreateOrViewDto>
{
  public OrderCreateOrViewValidator()
  {
    RuleFor(x => x.Items)
        .NotEmpty().WithMessage("items is required");

    RuleForEach(x => x.Items)
    .ChildRules(item =>
        item.RuleFor(x => x.MovieScheduleId)
          .NotEmpty().WithMessage("movie_schedule_id is required")
    );

    RuleForEach(x => x.Items)
    .ChildRules(item =>
      item.RuleFor(x => x.Qty)
        .GreaterThan(0).WithMessage("qty must greater than 0")
        .NotEmpty().WithMessage("qty is required")
    );
  }
}
