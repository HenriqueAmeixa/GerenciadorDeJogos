using Microsoft.Extensions.Logging;
using PlayMatch.Front.Services;
using PlayMatch.Core.Data;
using PlayMatch.Front.Mappers;
using PlayMatch.Front.Components.Pages;
using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Data.Repositories;

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
            builder.Services.AddScoped<SelecaoJogadoresService>();
            builder.Services.AddScoped<GolService>();
            builder.Services.AddScoped<ConfiguracaoService>();
            builder.Services.AddScoped(typeof(IConfiguracaoRepository), typeof(ConfiguracaoRepository));
            builder.Services.AddScoped(typeof(IGolRepository), typeof(GolRepository));
            builder.Services.AddScoped(typeof(IAssistenciaRepository), typeof(AssistenciaRepository));
            builder.Services.AddScoped(typeof(ITimeJogadorRepository), typeof(TimeJogadorRepository));
            builder.Services.AddSingleton(new PlayMatchDbContext(dbPath));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(SQLiteRepository<>));
            return builder.Build();
        }
    }
}
