using Microsoft.Extensions.Logging;
using MyBlazorHybridApp.Services;
using MyBlazorHybridApp.Shared.Data;
using MyBlazorHybridApp.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace MyBlazorHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddDbContext<PizzaStoreContext>(options =>
                options.UseSqlite($"Data Source=pizza.db"));

            builder.Services.AddScoped<OrderState>();

            builder.Services.AddScoped<SpecialsService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddSingleton<PizzaService>();

            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
                db.Database.EnsureCreated();
                SeedData.Initialize(db);    
            }

            return app;
        }
    }
}
