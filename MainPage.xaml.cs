using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MauiAppWithMudBlazor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("CustomBlazorWebViewMapper", (handler, view) =>
            {
#if WINDOWS
            //Workaround for WinUI splash screen
            if (AppInfo.Current.RequestedTheme == AppTheme.Dark)
            {
                handler.PlatformView.DefaultBackgroundColor = Microsoft.UI.Colors.Black;
            }
#endif

#if IOS || MACCATALYST
                handler.PlatformView.ScrollView.Bounces = false;

                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Opaque = false;
#endif

#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);

                handler.PlatformView.OverScrollMode = Android.Views.OverScrollMode.Never;

                handler.PlatformView.VerticalScrollBarEnabled = false;
                handler.PlatformView.HorizontalScrollBarEnabled = false;

                handler.PlatformView.ScrollbarFadingEnabled = true;

               
#endif
            });

            
        }
    }
}
