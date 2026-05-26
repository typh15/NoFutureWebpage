
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class SampleController : ControllerBase
{
    private readonly ISampleRepository repository;

    public SampleController(ISampleRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet("/samples")]
    public async Task<List<SampleModel>> GetSamples()
    {
        return await repository.GetSamplesAsync();
    }

    [HttpGet("/samples/{id}")]
    public async Task<SampleModel?> GetSampleById(int id)
    {
        return await repository.GetSampleByIdAsync(id);
    }

    [HttpPost("/samples")]
    public async Task<IActionResult> AddSampleAsync([FromBody] CreateSampleModelRequest request)
    {
        var sampleRequest = new SampleModel(
            0,
            request.Name,
            request.Value
        );

        await repository.AddSampleAsync(sampleRequest);
        return Ok();
    }
    

    [HttpPut("/samples/{id}")]
    public async Task<bool> UpdateSample(UpdateSampleModelRequest request)
    {
        var sample = new SampleModel(
            request.Id,
            request.Name,
            request.Value
        );
        
        return await repository.UpdateSampleAsync(sample);
    }

    [HttpDelete("/samples/{id}")]
    public async Task<bool> DeleteSample(int id)
    {
        return await repository.DeleteSampleAsync(id);
    }
}