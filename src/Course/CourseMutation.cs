namespace CourseResource;

public class CourseMutation : ICourseMutation
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

    public async Task<Course> UpdateCourse(Guid id, UpdateCourseInput input)
    {
        return await _courseService.UpdateCourseAsync(id, input);
    }

    public async Task DeleteCourse(Guid id)
    {
        await _courseService.DeleteCourseAsync(id);
    }
}
