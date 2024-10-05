using CourseResource;
using Microsoft.EntityFrameworkCore;

public class CoreDbContext : DbContext{

    public CoreDbContext(DbContextOptions<CoreDbContext> options): base(options)
    {

    }
    public DbSet<Course> Courses {get; set; }

}