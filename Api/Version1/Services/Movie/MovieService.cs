using Coravel.Queuing.Interfaces;
using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Contexts;
using NuGet.Protocol;

namespace dot_dotnet_test_api.API.Version1.Services;

public class MovieService(
  IConfiguration configuration,
  MovieRepository movieRepository,
  StudioRepository studioRepository,
  MovieScheduleRepository movieScheduleRepository,
  TagRepository tagRepository,
  ILogger<MovieService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly MovieRepository _movieRepository = movieRepository;
  private readonly StudioRepository _studioRepository = studioRepository;
  private readonly MovieScheduleRepository _movieScheduleRepository = movieScheduleRepository;
  private readonly TagRepository _tagRepository = tagRepository;

  private readonly ILogger<MovieService> _logger = logger;

  private static async Task<PosterFileResult> CopyPosterFile(IFormFile poster)
  {
    var splittedFileNames = poster.FileName.Split(".");
    var fileExtension = splittedFileNames[splittedFileNames.Length - 1];
    var filePath = Path.Combine("./files/images/poster", Path.GetRandomFileName() + "-movie" + "." + fileExtension);

    using (var stream = File.Create(filePath))
    {
      await poster.CopyToAsync(stream);
    }

    var savedSplitedFileNames = filePath.Split('/');
    var savedFileName = savedSplitedFileNames[^1];

    return new PosterFileResult
    {
      SavedFileName = savedFileName,
      FilePath = filePath
    };
  }

  private static string GetDeployedPosterPath(Movie movie, HttpRequest request)
  {
    var baseUri = $"{request.Scheme}://{request.Host}";

    var deployedFilePath = $"{baseUri}/images/poster/{movie.Poster!.Split("/")[^1]}";
    return deployedFilePath;
  }

  private List<Movie> MapPosterPath(List<Movie> movieList, HttpRequest request)
  {
    List<Movie> mappedResult = movieList;

    int idx = 0;
    foreach (var movie in movieList.ToList())
    {
      if (movie.Poster!.StartsWith("./"))
      {
        movie.Poster = GetDeployedPosterPath(movie, request);
        mappedResult[idx] = movie;
      }

      idx++;
    }

    return mappedResult;
  }

  public async Task<ContentResult> GetMovieList(PaginationDto paginationDto, HttpRequest request)
  {
    var page = paginationDto.Page;
    var perPage = paginationDto.PerPage;
    var movieCount = await _movieRepository.Count();
    var totalPage = (int)Math.Ceiling((double)movieCount / perPage);

    if (page > totalPage)
    {
      return new Response<object>(
          message: "Get Box Office Movies Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var movieList = await _movieRepository.FindAllPagination(page, perPage);
    movieList = MapPosterPath(movieList, request);

    return new PaginationResponse<MovieListResult[]>(
        items: movieList.Select(MovieListResult.MapJson).ToArray(),
        message: "Get Back Office Movies Success",
        pagination: new Pagination
        {
          Page = page,
          PerPage = perPage,
          TotalItem = movieCount,
          TotalPages = totalPage,
        }
    ).GetFormated();

  }

  public async Task<ContentResult> GetMovieListWithSchedules(MovieListDto movieListDto, HttpRequest request)
  {
    var page = movieListDto.Page;
    var perPage = movieListDto.PerPage;
    var movieCount = await _movieRepository.FindAllWithScheduleCount(movieListDto.Keyword, movieListDto.Date);

    var totalPage = (int)Math.Ceiling((double) movieCount / perPage);
    if (page > totalPage && totalPage != 0 && page > 1)
    {
      return new Response<object>(
          message: "Get Box Office Movies Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var movieList = await _movieRepository.FindAllWithSchedulePagination(page, perPage, movieListDto.Keyword, movieListDto.Date);
    movieList = MapPosterPath(movieList, request);

    return new PaginationResponse<MovieListWithScheduleResult[]>(
        items: movieList.Select(MovieListWithScheduleResult.MapJson).ToArray(),
        message: "Get Back Office Movies Success",
        pagination: new Pagination
        {
          Page = page,
          PerPage = perPage,
          TotalItem = movieCount,
          TotalPages = totalPage,
        }
    ).GetFormated();
  }
  public async Task<ContentResult> UpdateMovie(
    long movieId, MovieBackOfficeUpdateDto movieV1BackOfficeUpdateDto, HttpRequest request
  )
  {
    var foundedMovie = await _movieRepository.FindById(movieId);

    if (foundedMovie == null)
    {
      return new Response<object>(
          error: "Movie Not Found",
          message: "Update Movie Failed"
      ).GetFormated(statusCode: StatusCodes.Status404NotFound);
    }

    var movieTags = new MovieTags[movieV1BackOfficeUpdateDto.Tags!.Length];

    // Validate tag is exist by id
    int i = 0;
    string[] errors = [];
    foreach (var tag in movieV1BackOfficeUpdateDto.Tags)
    {
      var foundedTag = await _tagRepository.FindById(tag);

      if (foundedTag == null)
      {
        errors.Append($"Tag with id {tag} Not Found");
      }

      var movieTag = new MovieTags
      {
        Tag = foundedTag,
        Movie = foundedMovie,
      };

      movieTags[i++] = movieTag;
    }

    if (errors.Length > 0)
    {
      return new Response<object>(
          error: errors[0],
          message: "Update Movie Failed"
      ).GetFormated(statusCode: StatusCodes.Status404NotFound);
    }

    await _tagRepository.DeleteMovieTagsByMovieId((long)foundedMovie.Id!);

    foundedMovie.Title = movieV1BackOfficeUpdateDto.Title!;
    foundedMovie.Overview = movieV1BackOfficeUpdateDto.Overview!;
    foundedMovie.PlayUntil = movieV1BackOfficeUpdateDto.PlayUntil;
    foundedMovie.MovieTags = movieTags;
    foundedMovie.UpdatedAt = DateTime.Now;

    if (movieV1BackOfficeUpdateDto.Poster != null)
    {
      var copyedFile = await CopyPosterFile(movieV1BackOfficeUpdateDto.Poster);
      foundedMovie.Poster = copyedFile.FilePath;
    }

    var deployedFilePath = GetDeployedPosterPath(foundedMovie, request);

    await _movieRepository.Update(foundedMovie);

    return new Response<MovieUpdateResult>(
        data: MovieUpdateResult.MapJson(foundedMovie, deployedFilePath),
        message: "Update Movie Success"
    ).GetFormated(statusCode: StatusCodes.Status200OK); ;
  }
}
