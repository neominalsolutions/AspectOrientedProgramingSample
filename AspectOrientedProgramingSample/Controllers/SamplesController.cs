using AspectOrientedProgramingSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspectOrientedProgramingSample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SamplesController : ControllerBase
  {
    private readonly ISampleService _sampleService;

    public SamplesController(ISampleService sampleService)
    {
      _sampleService = sampleService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
      await _sampleService.ExecuteAsync(token);

      return Ok();
    }
  }
}
