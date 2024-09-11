using dot_dotnet_test_api.Dtos;
using FluentValidation;

namespace dot_dotnet_test_api.Validators;
public class MovieV1BackOfficeScheduleValidator : AbstractValidator<MovieV1BackOfficeScheduleDto>
{
    public MovieV1BackOfficeScheduleValidator()
    {
        RuleFor(x => x.MovieId)
            .NotEmpty().WithMessage("movie_id is required");
            
        RuleFor(x => x.StudioId)
            .NotEmpty().WithMessage("studio_id is required");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("start_time is required");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("end_time is required");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("price is required");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("date is required");
    }
}