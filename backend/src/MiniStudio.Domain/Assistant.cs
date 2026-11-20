namespace MiniStudio.Domain;

public class Assistant
{
    public Guid Id { get; private set;}
    public string Name { get; private set;}
    public string Model { get; private set;}
    public DateTime CreatedAt { get; private set;}

    private Assistant(Guid id, string name, string model, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Model = model;
        CreatedAt = createdAt;
    }

    public static Assistant Create(string name, string model)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        return new Assistant(Guid.NewGuid(), name, model, DateTime.UtcNow);
    }
}