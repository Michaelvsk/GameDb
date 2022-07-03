using System.Diagnostics.CodeAnalysis;

using Foundation;

namespace Michaelvsk.GameDb.Platforms.iOS;

[Register("AppDelegate")]
[ExcludeFromCodeCoverage]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
