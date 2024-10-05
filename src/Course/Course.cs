using System.ComponentModel.DataAnnotations;

namespace CourseResource;

public enum DurationUnit
{
    Minutes = 1,
    Hours = 2,
    Days = 3
}

public class Course {
    [Key]
    public Guid Id {get; set;}
    public required string Title { get; set; }
    public required Guid AuthorId { get; set; }
    public int Duration { get; set; }
    public DurationUnit DurationUnit { get; set; }

    public double PriceInRupees;
}