namespace PillarResource;
public class AddPillarInput {
    public Guid id {get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}

    public required DateTime CreatedAt {get; set;}

    public required DateTime UpdatedAt {get; set;}
}

public class UpdatePillarInput {
    public required string Name {get; set;}
    public required string Description {get; set;}

    public required DateTime UpdatedAt {get; set;}
}