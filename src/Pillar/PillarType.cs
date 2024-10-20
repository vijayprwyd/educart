namespace PillarResource;

public class AddPillarInput
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public class UpdatePillarInput
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public required DateTime UpdatedAt { get; set; }
}
