using dot_dotnet_test_api.Helpers;
using dot_dotnet_test_api.Repositories;
using dot_dotnet_test_api.Types;
using dot_dotnet_test_api.API.Version1.Dtos;
using Microsoft.AspNetCore.Mvc;
using dot_dotnet_test_api.Dtos;
using dot_dotnet_test_api.Models;

namespace dot_dotnet_test_api.API.Version1.Services;

public class MovieService(
  IConfiguration configuration,
  MovieRepository movieRepository,
  StudioRepository studioRepository,
  MovieScheduleRepository movieScheduleRepository,
  TagRepository tagRepository,
  FileHelper fileHelper,
  ILogger<MovieService> logger
)
{
  private readonly IConfiguration _configuration = configuration;
  private readonly MovieRepository _movieRepository = movieRepository;
  private readonly StudioRepository _studioRepository = studioRepository;
  private readonly MovieScheduleRepository _movieScheduleRepository = movieScheduleRepository;
  private readonly TagRepository _tagRepository = tagRepository;
  private readonly FileHelper _fileHelper = fileHelper;
  private readonly ILogger<MovieService> _logger = logger;

  private static string GetDeployedPosterPath(Movie movie, HttpRequest request)
  {
    var baseUri = $"{request.Scheme}://{request.Host}";

    var deployedFilePath = $"{baseUri}/images/poster/{movie.Poster!.Split("/")[^1]}";
    return deployedFilePath;
  }

  private static List<Movie> MapPosterPath(List<Movie> movieList, HttpRequest request)
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

  private static List<BestSellerMovie> MapPosterPath(List<BestSellerMovie> movieList, HttpRequest request)
  {
    List<BestSellerMovie> mappedResult = movieList;

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
    var movieCount = await _movieRepository.CountAll();
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

  public async Task<ContentResult> GetBestSellerMovieList(DateOnlyRangeDto dateOnlyRangeDto, HttpRequest request) {
    var page = dateOnlyRangeDto.Page;
    var perPage = dateOnlyRangeDto.PerPage;
    var movieCount = await _movieRepository.CountBestSellerList(
      startDate: (DateOnly) dateOnlyRangeDto.StartDate!,
      endDate: (DateOnly) dateOnlyRangeDto.EndDate!
    );
    var totalPage = (int) Math.Ceiling((double)movieCount / perPage);

    if (page > totalPage)
    {
      return new Response<object>(
          message: "Get Back Office Best Seller Movies Failed",
          error: "page is out of range"
      ).GetFormated(StatusCodes.Status400BadRequest);
    }

    var movieList = await _movieRepository.FindBestSeller(
      (DateOnly) dateOnlyRangeDto.StartDate!,
      (DateOnly) dateOnlyRangeDto.EndDate!,
      page,
      perPage
    );
    movieList = MapPosterPath(movieList, request);

    return new PaginationResponse<BestSellerMovieListResult[]>(
      items: movieList.Select(BestSellerMovieListResult.MapJson).ToArray(),
      message: "Get Back Office Best Seller Movies Success",
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

    var totalPage = (int)Math.Ceiling((double)movieCount / perPage);
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
    long movieId, MovieBackOfficeUpdateDto movieBackOfficeUpdateDto, HttpRequest request
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

    long[]? tagIds = movieBackOfficeUpdateDto.Tags;

    if (tagIds != null)
    {
      var foundTags = await _tagRepository.FindByIds([.. tagIds]);
      var foundTagsDict = foundTags.ToDictionary(tag => (long)tag.Id!);

      var errors = new List<string>();
      var movieTags = new List<MovieTags>();

      foreach (var tagId in tagIds)
      {
        if (!foundTagsDict.TryGetValue(tagId, out var foundedTag))
        {
          errors.Add($"Tag with id {tagId} Not Found");
        }
        else
        {
          movieTags.Add(new MovieTags
          {
            Tag = foundedTag,
            Movie = foundedMovie,
          });
        }
      }

      if (errors.Count != 0)
      {
        return new Response<object>(
            error: string.Join(", ", errors),
            message: "Update Movie Failed"
        ).GetFormated(statusCode: StatusCodes.Status404NotFound);
      }
      await _tagRepository.DeleteMovieTagsByMovieId((long)foundedMovie.Id!);
      foundedMovie.MovieTags = movieTags;
    }

    foundedMovie.Title = movieBackOfficeUpdateDto.Title!;
    foundedMovie.Overview = movieBackOfficeUpdateDto.Overview!;
    foundedMovie.PlayUntil = movieBackOfficeUpdateDto.PlayUntil;
    foundedMovie.UpdatedAt = DateTime.Now;

    if (movieBackOfficeUpdateDto.Poster != null)
    {
      var copyedFile = await FileHelper.CopyFile(
        file: movieBackOfficeUpdateDto.Poster,
        path: "./files/images/poster",
        prefix: "movie"
      );
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
