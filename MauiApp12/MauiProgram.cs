using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Maui.BottomSheet;

namespace MauiApp12
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiBottomSheet()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddTransient<BottomSheetVMViewModel>();

            builder.Services.AddTransient<IBottomSheet, BottomSheetVM>();

            return builder.Build();
        }
    }
}
