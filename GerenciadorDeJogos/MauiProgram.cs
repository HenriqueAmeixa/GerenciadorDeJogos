using GerenciadorDeJogos.Services;
using GerenciadorDeJogos.ViewModels;
using GerenciadorDeJogos.Views.Pages;
using Microsoft.Extensions.Logging;
using PlayMatch.Core.Data;

namespace GerenciadorDeJogos;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "playmatch.db3");

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<GerenciarPartidaViewModel>();
        builder.Services.AddSingleton<GerenciarPartidaPage>();
		builder.Services.AddSingleton<SelecaoJogadoresPage>();
		builder.Services.AddSingleton<SorteioTimesPage>();
		builder.Services.AddSingleton<SorteioTimesViewModel>();
        builder.Services.AddSingleton<JogadorService>();
		builder.Services.AddSingleton<TimeService>();
        builder.Services.AddSingleton<PartidaService>();
		builder.Services.AddSingleton<GolService>();
        builder.Services.AddSingleton<GerenciarJogadoresViewModel>();
        builder.Services.AddSingleton(new PlayMatchDbContext(dbPath));
        builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(SQLiteRepository<>));
        builder.Services.AddSingleton<GerenciarJogadoresPage>();
        return builder.Build();
	}
}
