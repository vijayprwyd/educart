using Microsoft.EntityFrameworkCore;

namespace CourseResource;

public class CourseService
{
    //GetCourseByIdAsync AddCourseAsync DeleteCourseAsync UpdateCourseAsync

    private readonly CoreDbContext _context;

    public CourseService(CoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }
}