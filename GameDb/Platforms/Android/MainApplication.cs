using System.Diagnostics.CodeAnalysis;

using Android.App;
using Android.Runtime;

namespace Michaelvsk.GameDb.Platforms.Android;

[Application]
[ExcludeFromCodeCoverage]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
