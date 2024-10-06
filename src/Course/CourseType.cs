using PillarResource;

namespace CourseResource;

public class AddCourseInput
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required CourseStatus Status { get; set; }

    public required string Language { get; set; }

    public required int Duration { get; set; }

    public required DurationUnit DurationUnit { get; set; }

    public ICollection<Pillar>? Pillars;

}
