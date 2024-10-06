using System.ComponentModel.DataAnnotations;
using PillarResource;

namespace CourseResource;

public enum DurationUnit
{
    Minutes = 1,
    Hours = 2,
    Days = 3
}

public enum CourseStatus
{
    Draft = 0,
    Active = 1,
    Archived = 2,
}


public class Course {
    [Key]
    public Guid Id {get; set;}
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required CourseStatus Status { get; set; }

    public required DateTime CreatedAt {get; set;}

    public required DateTime UpdatedAt {get; set;}

    public required string Language {get; set;}

    public required int Duration {get; set;}

    public required DurationUnit DurationUnit {get; set;}

    public ICollection<Pillar>? Pillars;

}