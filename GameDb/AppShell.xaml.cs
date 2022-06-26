using Michaelvsk.GameDb.Pages;

namespace Michaelvsk.GameDb;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(GameDetailPage), typeof(GameDetailPage));
    }
}
