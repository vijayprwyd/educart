using Microsoft.EntityFrameworkCore;
using PillarResource;

namespace CourseResource;

public class CourseService : ICourseService
{
    private readonly CoreDbContext _dbContext;

    public CourseService(CoreDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Course> GetCourseByIdAsync(Guid courseId)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            throw new InvalidOperationException("Course not found");
        return course;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

    public async Task<Course> AddCourseAsync(AddCourseInput input)
    {
        var course = new Course
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Name = input.Name,
            Description = input.Description,
            Duration = input.Duration,
            DurationUnit = input.DurationUnit,
            Language = input.Language,
            Status = input.Status,
            Pillars =
                input.PillarIds != null
                    ? _dbContext.Pillars.Where(p => input.PillarIds.Contains(p.Id)).ToList()
                    : null,
        };
        await _dbContext.Courses.AddAsync(course);
        await _dbContext.SaveChangesAsync();

        return course;
    }

    public async Task<Course> UpdateCourseAsync(Guid id, UpdateCourseInput updateCourseInput)
    {
        var course = await _dbContext
            .Courses.Include(c => c.Pillars)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null)
            throw new InvalidOperationException("Course not found");

        if (!string.IsNullOrEmpty(updateCourseInput.Name))
            course.Name = updateCourseInput.Name;
        if (!string.IsNullOrEmpty(updateCourseInput.Description))
            course.Description = updateCourseInput.Description;
        if (!string.IsNullOrEmpty(updateCourseInput.Language))
            course.Language = updateCourseInput.Language;

        if (updateCourseInput.Duration.HasValue)
            course.Duration = updateCourseInput.Duration.Value;
        if (updateCourseInput.DurationUnit.HasValue)
            course.DurationUnit = updateCourseInput.DurationUnit.Value;
        if (updateCourseInput.Status.HasValue)
            course.Status = updateCourseInput.Status.Value;
        if (updateCourseInput.PillarIds != null)
        {
            if (course.Pillars != null)
                course.Pillars.Clear();

            var pillarsToAdd = await _dbContext
                .Pillars.Where(p => updateCourseInput.PillarIds.Contains(p.Id))
                .ToListAsync();

            var pillars = new List<Pillar>();
            foreach (var pillar in pillarsToAdd)
            {
                if (course.Pillars == null || !course.Pillars.Any(p => p.Id == pillar.Id))
                {
                    pillars.Add(pillar);
                }
            }
            if (pillars.Count > 0)
                course.Pillars = pillars;
        }

        course.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return course;
    }

    public async Task DeleteCourseAsync(Guid courseId)
    {
        var course = await GetCourseByIdAsync(courseId);
        _dbContext.Courses.Remove(course);
        await _dbContext.SaveChangesAsync();
    }
}
