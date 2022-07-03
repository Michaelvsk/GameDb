using System.Diagnostics.CodeAnalysis;
using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Michaelvsk.GameDb.Platforms.Tizen;

[ExcludeFromCodeCoverage]
class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
