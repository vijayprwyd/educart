namespace CourseResource;

[ExtendObjectType("Mutation")]
public class CourseMutation : ICourseMutation
{
    public async Task<Course> AddCourse(
        AddCourseInput input,
        [Service] ICourseService courseService
    )
    {
        return await courseService.AddCourseAsync(input);
    }

    public async Task<Course> UpdateCourse(
        Guid id,
        UpdateCourseInput input,
        [Service] ICourseService courseService
    )
    {
        return await courseService.UpdateCourseAsync(id, input);
    }

    public async Task DeleteCourse(Guid id, [Service] ICourseService courseService)
    {
        await courseService.DeleteCourseAsync(id);
    }
}
