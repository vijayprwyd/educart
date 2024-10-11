namespace CourseResource;

[ExtendObjectType("Query")]
public class CourseQuery : ICourseQuery
{
    ICourseService _courseService;

    public CourseQuery(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<Course> GetCourse(Guid id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    public async Task<List<Course>> GetCourses()
    {
        return await _courseService.GetCoursesAsync();
    }
}
