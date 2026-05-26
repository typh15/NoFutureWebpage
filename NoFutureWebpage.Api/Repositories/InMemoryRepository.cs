class InMemoryRepository : ISampleRepository
{

    private readonly List<SampleModel> samples =
    [
        new SampleModel(
            1,
            "A1",
            "Value1"
        ),
        new SampleModel(
            2,
            "B2",
            "Value2"
        ),
        new SampleModel(
            3,
            "C3",
            "Value3"
        ),
        new SampleModel(
            4,
            "D4",
            "Value4"
        )
    ];


    public Task<List<SampleModel>> GetSamplesAsync()
    {
        return Task.FromResult(samples.ToList());
    }

    public Task<SampleModel?> GetSampleByIdAsync(int id)
    {
        var sample = samples.FirstOrDefault(a => a.Id == id);
        return Task.FromResult(sample);
    }

    public Task AddSampleAsync(SampleModel sample)
    {
        var id = samples.Count > 0 ? samples.Max(a => a.Id) + 1 : 1;
        var NewSample = new SampleModel(
            id,
            sample.Name,
            sample.Value
        );
        samples.Add(NewSample);
        return Task.CompletedTask;
    }

    public Task<bool> UpdateSampleAsync(SampleModel sample)
    {
        var existing = samples.FirstOrDefault(a => a.Id == sample.Id);
        if (existing != null)
        {
            existing.Name = sample.Name;
            existing.Value = sample.Value;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> DeleteSampleAsync(int id)
    {
        var sample = samples.FirstOrDefault(a => a.Id == id);
        if (sample != null)
        {
            samples.Remove(sample);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}