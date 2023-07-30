﻿using InsuranceApp.Services;

namespace InsuranceApp;

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
				fonts.AddFont("Nexa-ExtraLight.ttf", "NexaLight");
                fonts.AddFont("Nexa-Heavy.ttf", "NexaHeavy");
            });
		builder.Services.AddSingleton<ILoginRepository, LoginService>();
		builder.Services.AddSingleton<MainPage>();
		return builder.Build();
	}
}
