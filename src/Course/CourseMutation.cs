namespace CourseResource;

public class CourseMutation
{
    private readonly CourseService _courseService;

    public CourseMutation(CourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<Course> AddCourse(AddCourseInput input)
    {
        return await _courseService.AddCourseAsync(input);
    }
}

