namespace MiniStudio.Domain.Tests;

public class AssistantTest
{
    [Fact]
    public void Create_WithValidData_ReturnsAssistant()
    {
        var before = DateTime.UtcNow;
        var assistant = Assistant.Create("Claude", "claude-sonnet-5-5");
        var after = DateTime.UtcNow;
        
        Assert.Equal("Claude", assistant.Name);
        Assert.Equal("claude-sonnet-5-5", assistant.Model);
        Assert.InRange(assistant.CreatedAt, before, after);
        Assert.NotEqual(Guid.Empty, assistant.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithBlankName_Throws(string? name)
    {
        Assert.ThrowsAny<ArgumentException>(() => Assistant.Create(name!, "claude-sonnet-5-5"));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithBlankModel_Throws(string? model)
    {
        Assert.ThrowsAny<ArgumentException>(() => Assistant.Create("claude", model!));
    }
}
