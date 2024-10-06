using Microsoft.EntityFrameworkCore;

namespace CourseResource;

public class CourseService
{
    private readonly CoreDbContext _context;

    public CourseService(CoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> AddCourseAsync(AddCourseInput addCourseInput)
    {
        try
        {
            var course = new Course
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Name = addCourseInput.Name,
                Description = addCourseInput.Description,
                Duration = addCourseInput.Duration,
                DurationUnit = addCourseInput.DurationUnit,
                Language = addCourseInput.Language,
                Status = addCourseInput.Status,
                Pillars = addCourseInput.Pillars,
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}