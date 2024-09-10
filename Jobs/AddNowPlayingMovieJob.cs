using System.Text.Json;
using System.Text.Json.Nodes;
using dot_dotnet_test_api.Contexts;
using dot_dotnet_test_api.Models;
using dot_dotnet_test_api.Types;
using Newtonsoft.Json;
using NuGet.Protocol;
using Quartz;
using RestSharp;
using EFCore.BulkExtensions;


namespace dot_dotnet_test_api.Jobs
{
  public class AddNowPlayingMovieJob : IJob
  {
    private readonly SQLServerContext _DbContext;
    private readonly ILogger<AddNowPlayingMovieJob> _logger;

    public AddNowPlayingMovieJob(SQLServerContext DbContext, ILogger<AddNowPlayingMovieJob> logger) {
      _DbContext = DbContext;
      _logger = logger;
    }

    public async Task Execute(IJobExecutionContext context)
    {
      _logger.LogInformation("Job started");
      JobDataMap dataMap = context.JobDetail.JobDataMap;
      var tokenkey = dataMap.GetString("apikey");

      var options = new RestClientOptions("https://api.themoviedb.org/3/movie/now_playing?language=en-US&page=1");
      var client = new RestClient(options);
      var request = new RestRequest("");
      request.AddHeader("accept", "application/json");
      request.AddHeader("Authorization", $"Bearer {tokenkey}");
      var response = await client.GetAsync(request);
      var data = JsonConvert.DeserializeObject<ITMDBNowPlaying>(response!.Content!);
      var movieList = data.Results;

      _DbContext.BulkInsertOrUpdateAsync<MovieV1>(movieList);

      _logger.LogInformation("{0}", data.Results[0].BackdropPath);
      _logger.LogInformation("Job Finish");
    }
  }
};
