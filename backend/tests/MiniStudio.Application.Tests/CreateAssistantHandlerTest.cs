namespace MiniStudio.Application.Tests;

public class CreateAssistantHandlerTest
{
    private readonly FakeAssistantRepository _repository = new();
    private readonly CreateAssistantHandler _handler;

    public CreateAssistantHandlerTest()
    {
        _handler = new CreateAssistantHandler(_repository);
    }

    [Fact]
    public async Task HandleAsync_WithValidData_SavesAssistantAndReturnsItsId()
    {
        var id = await _handler.HandleAsync("Claude", "claude-sonnet-5-5", CancellationToken.None);

        var saved = Assert.Single(_repository.Saved);
        Assert.Equal(id, saved.Id);
        Assert.Equal("Claude", saved.Name);
        Assert.Equal("claude-sonnet-5-5", saved.Model);
    }

    [Fact]
    public async Task HandleAsync_WithBlankName_ThrowsAndSavesNothing()
    {
        await Assert.ThrowsAnyAsync<ArgumentException>(
            () => _handler.HandleAsync("", "claude-sonnet-5-5", CancellationToken.None));

        Assert.Empty(_repository.Saved);
    }
}
