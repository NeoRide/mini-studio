using MiniStudio.Domain;

namespace MiniStudio.Application.Tests;

public class FakeAssistantRepository : IAssistantRepository
{
    public List<Assistant> Saved { get; } = [];

    public Task AddAsync(Assistant assistant, CancellationToken ct)
    {
        Saved.Add(assistant);
        return Task.CompletedTask;
    }

    public Task<Assistant?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return Task.FromResult(Saved.FirstOrDefault(a => a.Id == id));
    }
}
