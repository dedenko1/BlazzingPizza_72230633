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

            // Tambahkan DbContext
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "pizza.db");
            builder.Services.AddDbContext<PizzaStoreContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));

            // Tambahkan service lokal
            builder.Services.AddScoped<SpecialsService>();


            // Register the pizzas service
            builder.Services.AddSingleton<PizzaService>();

            // Add device-specific services used by the MyBlazorHybridApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
