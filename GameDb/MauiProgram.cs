using Michaelvsk.GameDb.Core.Repositories;
using Michaelvsk.GameDb.Models.DataAccess;
using Michaelvsk.GameDb.Pages;
using Michaelvsk.GameDb.ViewModels;

namespace Michaelvsk.GameDb;

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


        builder.Services.AddTransient<GameList>();
        builder.Services.AddTransient<GameListViewModel>();
        builder.Services.AddTransient<GameDetailPage>();
        builder.Services.AddTransient<GameItemViewModel>();
        builder.Services.AddScoped<IGameRepository, GameRepositoryStatic>();

        return builder.Build();
    }
}
