using CourseResource;
using Microsoft.EntityFrameworkCore;
using PillarResource;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<CoreDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IPillarService, PillarService>();

        services.AddAuthorization();

        // Set up GraphQL
        services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<CourseQuery>()
            .AddTypeExtension<CourseMutation>()
            .AddTypeExtension<PillarQuery>()
            .AddTypeExtension<PillarMutation>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts(); // Apply HSTS only in production
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        // Use endpoint routing to map GraphQL
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);

        startup.ConfigureServices(builder.Services);
        var app = builder.Build();

        startup.Configure(app, builder.Environment);
        app.Run();
    }
}
