using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Maui.TouchEffect.Hosting;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace AppTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                .UseMauiTouchEffect()
                .UseMauiApp<App>()
               
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Objektiv Mk1 XBold.ttf", "Objektiv Mk1 XBold");
                    fonts.AddFont("Objektiv Mk1 Light.ttf", "Objektiv Mk1 Light");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "Solid6");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "Regular6");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "Brands6");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
