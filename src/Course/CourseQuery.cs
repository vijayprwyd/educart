namespace CourseResource;

public class CourseQuery
{
    public Course GetCourse() =>
        new Course
        {
            Name = "C# in depth.",
            Description = "Description",
            Status = CourseStatus.Active,
            Duration=3,
            DurationUnit = DurationUnit.Hours,
            CreatedAt=DateTime.Now,
            UpdatedAt=DateTime.Now,
            Language="English",
        };
}

