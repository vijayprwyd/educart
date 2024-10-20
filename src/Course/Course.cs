using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PillarResource;

namespace CourseResource;

public enum DurationUnit
{
    Minutes = 1,
    Hours = 2,
    Days = 3,
}

public enum CourseStatus
{
    Draft = 0,
    Active = 1,
    Archived = 2,
}

public class Course
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("status")]
    public required CourseStatus Status { get; set; }

    [Column("created_at")]
    public required DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    [Column("language")]
    public required string Language { get; set; }

    [Column("duration")]
    public required int Duration { get; set; }

    [Column("duration_unit")]
    public required DurationUnit DurationUnit { get; set; }

    public ICollection<Pillar>? Pillars { get; set; }
}
