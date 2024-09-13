using Coravel.Queuing.Interfaces;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Models;

namespace dot_dotnet_test_api.API.Version1.Services;

public class MovieScheduleService(
  IConfiguration configuration,
  MovieRepository movieRepository,
  StudioRepository studioRepository,
  MovieScheduleRepository movieScheduleRepository,
  ILogger<MovieScheduleService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly MovieRepository _movieRepository = movieRepository;
  private readonly StudioRepository _studioRepository = studioRepository;
  private readonly MovieScheduleRepository _movieScheduleRepository = movieScheduleRepository;

  private readonly ILogger<MovieScheduleService> _logger = logger;

  public async Task<ContentResult> CreateMovieSchedule(MovieScheduleCreateDto movieScheduleCreateDto)
  {

    var foundedMovie = await _movieRepository.FindById((long) movieScheduleCreateDto.MovieId!);
    if (foundedMovie == null)
    {
      return new Response<object>(
          error: "Movie Not Found",
          message: "Add Schedule Movie Failed"
      ).GetFormated(statusCode: StatusCodes.Status404NotFound);
    }

    var foundedStudio = await _studioRepository.FindById((long) movieScheduleCreateDto.StudioId!);
    if (foundedStudio == null)
    {
      return new Response<object>(
          error: "Studio Not Found",
          message: "Add Schedule Movie Failed"
      ).GetFormated(statusCode: StatusCodes.Status404NotFound);
    }

    var dtoDate = DateOnly.FromDateTime((DateTime)movieScheduleCreateDto.Date!);
    var foundedScheduler = await _movieScheduleRepository.FindAvailableScheduleByDate(
      movieId: (long) foundedMovie.Id!,
      studioId: (long) foundedStudio.Id!,
      date: dtoDate
    );

    string? error = null;

    // Check Schedule Availability by Date
    foundedScheduler.ForEach(scheduler =>
    {
      var startTime = DateTime.Parse($"{scheduler.Date} {scheduler.StartTime}");
      var endTime = DateTime.Parse($"{scheduler.Date} {scheduler.EndTime}");

      var dtoTime = DateTime.Parse($"{DateOnly.FromDateTime((DateTime)movieScheduleCreateDto.Date)} {movieScheduleCreateDto.StartTime}");

      if (dtoTime >= startTime && dtoTime <= endTime)
      {
        error = $"Schedule conflict with id {scheduler.Id}";
      }
    });

    if (error != null)
    {
      return new Response<object>(
          error: error,
          message: "Add Schedule Movie Failed"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var createdSchedule = new MovieSchedule
    {
      Movie = foundedMovie,
      Studio = foundedStudio,
      StartTime = movieScheduleCreateDto.StartTime!,
      EndTime = movieScheduleCreateDto.EndTime!,
      Date = DateOnly.FromDateTime((DateTime)movieScheduleCreateDto.Date),
      Price = (int)movieScheduleCreateDto.Price!,
      RemainingSeat = foundedStudio.SeatCapacity,
    };

    await _movieScheduleRepository.Create(createdSchedule);

    return new Response<CreateMovieScheduleResult>(
        data: CreateMovieScheduleResult.MapJson(createdSchedule),
        message: "Add Schedule Movie Success"
    ).GetFormated(StatusCodes.Status201Created);

  }
}
