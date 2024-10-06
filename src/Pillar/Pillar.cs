using CourseResource;

namespace PillarResource;
public class Pillar {
    public Guid id {get; set;}
    public required string name {get; set;}
    public required string description {get; set;}

    public required DateTime createdAt {get; set;}

    public required DateTime updatedAt {get; set;}

    public ICollection<Course>? Courses { get; set; }
}