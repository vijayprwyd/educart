namespace CourseResource;

[ExtendObjectType("Query")]
public class CourseQuery : ICourseQuery
{
    public async Task<Course> GetCourse(Guid id, [Service] ICourseService courseService)
    {
        return await courseService.GetCourseByIdAsync(id);
    }

    public async Task<List<Course>> GetCourses([Service] ICourseService courseService)
    {
        return await courseService.GetCoursesAsync();
    }
}
