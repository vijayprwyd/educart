using CourseResource;

namespace PillarResource;
public class Pillar {
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}

    public required DateTime CreatedAt {get; set;}

    public required DateTime UpdatedAt {get; set;}

    public ICollection<Course>? Courses { get; set; }
}