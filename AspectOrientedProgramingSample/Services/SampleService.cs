using AspectOrientedProgramingSample.Aspects;

namespace AspectOrientedProgramingSample.Services
{
  public class SampleService : ISampleService
  {
    private readonly ILogger<SampleService> _logger;

    public SampleService(ILogger<SampleService> logger)
    {
      _logger = logger;
    }

    //[BenchMark]
    public async Task ExecuteAsync(CancellationToken token)
    {
      _logger.LogInformation("Method Body");

      await Task.Delay(5000);

      if(token.IsCancellationRequested)
      {
        _logger.LogInformation("İstek İptal edildi");
      }

      token.ThrowIfCancellationRequested();

    }
  }
}
