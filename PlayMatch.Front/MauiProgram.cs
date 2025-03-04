using Microsoft.Extensions.Logging;
using PlayMatch.Front.Services;
using PlayMatch.Core.Data;
using PlayMatch.Front.Mappers;
using PlayMatch.Front.Components.Pages;

namespace PlayMatch.Front
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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "playmatch.db3");


            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<TimeService>();
            builder.Services.AddScoped<GerenciarPartidaService>();
            builder.Services.AddScoped<JogadorService>();
            builder.Services.AddScoped<TimeService>();
            builder.Services.AddScoped<PartidaService>();
            builder.Services.AddScoped<GolService>();
            builder.Services.AddScoped<Jogadores>();
            builder.Services.AddSingleton(new PlayMatchDbContext(dbPath));
            builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(SQLiteRepository<>));
            return builder.Build();
        }
    }
}
