namespace CourseResource;

public class CourseQuery
{
    public Course GetCourse() =>
        new Course
        {
            Title = "C# in depth.",
            AuthorId = new Guid(),
            PriceInRupees = 400,
            Duration = 3,
            DurationUnit = DurationUnit.Hours,
        };
}

