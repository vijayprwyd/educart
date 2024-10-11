namespace CourseResource;

public class CourseQuery : ICourseQuery
{
    CourseService _courseService;

    public CourseQuery(CourseService courseService)
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
