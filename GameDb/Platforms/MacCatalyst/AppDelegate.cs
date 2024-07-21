using System.Diagnostics.CodeAnalysis;

using Foundation;
using Microsoft.Maui;

namespace Michaelvsk.GameDb.Platforms.MacCatalyst;

[Register("AppDelegate")]
[ExcludeFromCodeCoverage]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
