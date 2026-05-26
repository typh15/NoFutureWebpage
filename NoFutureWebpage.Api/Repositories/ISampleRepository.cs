public interface ISampleRepository
{
    Task<List<SampleModel>> GetSamplesAsync();
    Task<SampleModel?> GetSampleByIdAsync(int id);
    Task AddSampleAsync(SampleModel sample);
    Task<bool> UpdateSampleAsync(SampleModel sample);
    Task<bool> DeleteSampleAsync(int id);
}