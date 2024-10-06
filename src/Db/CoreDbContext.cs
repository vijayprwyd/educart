using CourseResource;
using Microsoft.EntityFrameworkCore;
using PillarResource;

public class CoreDbContext : DbContext
{

    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {

    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Pillar> Pillars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Pillars)
            .WithMany(p => p.Courses)
            .UsingEntity<Dictionary<string, object>>(
            "CoursePillar", // Name of the join table
            j => j.HasOne<Pillar>().WithMany().HasForeignKey("PillarId"),
            j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId")
        ).ToTable("course_pillar"); ;

        modelBuilder.Entity<Course>().ToTable("course");
        modelBuilder.Entity<Pillar>().ToTable("pillar");

    }
}