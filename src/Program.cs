
using CourseResource;
using Microsoft.EntityFrameworkCore;

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
            .AddQueryType<CourseQuery>();  // Add your GraphQL query types here

        services.AddAuthorization();

        // Ensure to use Configuration here
        services.AddDbContext<CoreDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
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
            endpoints.MapGraphQL(); // Correctly mapping the GraphQL endpoint
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