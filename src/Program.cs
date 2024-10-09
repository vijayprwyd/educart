
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
        services
            .AddGraphQLServer()
            .AddQueryType<CourseQuery>()
            .AddMutationType<CourseMutation>()
            .AddMutationType<PillarMutation>();
        services.AddAuthorization();

        services.AddDbContext<CoreDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<CourseService>();
        services.AddScoped<PillarService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios.
            app.UseHsts();
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
