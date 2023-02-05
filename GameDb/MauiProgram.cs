using System.Diagnostics.CodeAnalysis;

using CommunityToolkit.Maui;

using Michaelvsk.GameDb.Core.Services;
using Michaelvsk.GameDb.DAL.Repositories;
using Michaelvsk.GameDb.Pages;
using Michaelvsk.GameDb.ViewModels;

namespace Michaelvsk.GameDb;

[ExcludeFromCodeCoverage]
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.Services.AddTransient<GameList>();
        builder.Services.AddTransient<GameListViewModel>();
        builder.Services.AddTransient<GameDetailPage>();
        builder.Services.AddTransient<GameItemViewModel>();
        builder.Services.AddSingleton<IGameRepository, GameRepositoryStatic>();
        builder.Services.AddSingleton<ICoverRepository, CoverRepositoryInMemory>();
        builder.Services.AddSingleton<IGameService, GameService>();

        return builder.Build();
    }
}
