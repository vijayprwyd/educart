using Microsoft.EntityFrameworkCore;

namespace CourseResource;


public class CourseService
{
    private readonly CoreDbContext _dbContext;

    public CourseService(CoreDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

    public async Task<Course> AddCourseAsync(AddCourseInput addCourseInput)
    {
        try
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Name = addCourseInput.Name,
                Description = addCourseInput.Description,
                Duration = addCourseInput.Duration,
                DurationUnit = addCourseInput.DurationUnit,
                Language = addCourseInput.Language,
                Status = addCourseInput.Status,
                Pillars = addCourseInput.PillarIds != null ? _dbContext.Pillars.Where(p => addCourseInput.PillarIds.Contains(p.Id)).ToList() : null,
            };

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return course;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Course> UpdateCourseAsync(Guid id, UpdateCourseInput updateCourseInput)
    {
        var course = _dbContext.Courses.FirstOrDefault(Course => Course.Id == id);
        if (course == null) throw new Exception("Course id cannot be null");

        if (!string.IsNullOrEmpty(updateCourseInput.Name)) course.Name = updateCourseInput.Name;
        if (!string.IsNullOrEmpty(updateCourseInput.Description)) course.Description = updateCourseInput.Description;
        if (!string.IsNullOrEmpty(updateCourseInput.Language)) course.Language = updateCourseInput.Language;
        if (!string.IsNullOrEmpty(updateCourseInput.Language)) course.Language = updateCourseInput.Language;

        if (updateCourseInput.Duration.HasValue) course.Duration = updateCourseInput.Duration.Value;
        if (updateCourseInput.DurationUnit.HasValue) course.DurationUnit = updateCourseInput.DurationUnit.Value;
        if (updateCourseInput.Status.HasValue) course.Status = updateCourseInput.Status.Value;
        if(updateCourseInput.PillarIds != null) _dbContext.Pillars.Where(p => updateCourseInput.PillarIds.Contains(p.Id)).ToList();

        course.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return course;
    }
}