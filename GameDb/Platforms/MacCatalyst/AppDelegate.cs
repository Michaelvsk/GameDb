using System.Diagnostics.CodeAnalysis;

using Foundation;

namespace Michaelvsk.GameDb.Platforms.MacCatalyst;

[Register("AppDelegate")]
[ExcludeFromCodeCoverage]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
