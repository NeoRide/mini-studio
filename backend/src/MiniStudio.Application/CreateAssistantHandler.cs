using MiniStudio.Domain;

namespace MiniStudio.Application;

public class CreateAssistantHandler(IAssistantRepository assistantRepository)
{
    
    public async Task<Guid> HandleAsync(string name, string model, CancellationToken ct)
    {
        Assistant assistant = Assistant.Create(name, model);
        await assistantRepository.AddAsync(assistant, ct);
        return assistant.Id;
    }
}   