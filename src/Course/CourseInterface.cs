using CourseResource;

public interface ICourseService
{
    public Task<List<Course>> GetCoursesAsync();
    public Task<Course> GetCourseByIdAsync(Guid id);
    public Task<Course> AddCourseAsync(AddCourseInput input);
    public Task<Course> UpdateCourseAsync(Guid id, UpdateCourseInput updateCourseInput);
    public Task DeleteCourseAsync(Guid id);
}

public interface ICourseQuery
{
    public Task<Course> GetCourse(Guid id);
    public Task<List<Course>> GetCourses();
}

public interface ICourseMutation
{
    public Task<Course> AddCourse(AddCourseInput input, [Service] ICourseService courseService);
    public Task<Course> UpdateCourse(
        Guid id,
        UpdateCourseInput updateCourseInput,
        [Service] ICourseService courseService
    );
    public Task DeleteCourse(Guid id, [Service] ICourseService courseService);
}
