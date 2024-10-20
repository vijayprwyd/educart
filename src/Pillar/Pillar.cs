using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseResource;

namespace PillarResource;

public class Pillar
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("created_at")]
    public required DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    public ICollection<Course>? Courses { get; set; }
}
