namespace OSBookReviewMAUI;

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
            })
        .ConfigureEssentials(essentials =>
         {
             essentials.UseVersionTracking();
#if WINDOWS
					essentials.UseMapServiceToken("RJHqIE53Onrqons5CNOx~FrDr3XhjDTyEXEjng-CRoA~Aj69MhNManYUKxo6QcwZ0wmXBtyva0zwuHB04rFYAPf7qqGJ5cHb03RCDw1jIW8l");
#endif
             essentials.AddAppAction("app_info", "App Info", icon: "app_info_action_icon");
             essentials.AddAppAction("battery_info", "Battery Info");
         });

        return builder.Build();
    }
}
