using MiniStudio.Domain;

namespace MiniStudio.Application;

public interface IAssistantRepository
{
    Task AddAsync(Assistant assistant, CancellationToken ct);
    Task<Assistant?> GetByIdAsync(Guid id, CancellationToken ct);
}