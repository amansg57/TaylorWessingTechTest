using CompaniesAPI.Repositories;
using CompaniesAPI.Services;
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
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<CompaniesDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("CompaniesDb"));
        });

        services.AddTransient<ICompanyRepository, CompanyRepository>();
        services.AddTransient<CompaniesService>();
        services.AddTransient<CompaniesMapper>();
        services.AddTransient<CompaniesHouseApiClient>();
        services.AddHttpClient();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
