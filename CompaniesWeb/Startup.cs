using CompaniesWeb.Services;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddTransient<CompaniesApiService>();
        services.AddHttpClient();
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        else {
            var url = Configuration.GetValue<string>("AppSettings:CompaniesUrl");
            var url2 = Configuration["AppSettings:CompaniesUrl"];
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
