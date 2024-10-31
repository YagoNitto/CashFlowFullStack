using MudBlazor;
using MudBlazor.Utilities;

namespace Dima.Web;

public static class Configuration
{
    public const string HttpClientName = "dima";
    public static string BackendUrl { get; set; } = "http://localhost:5030";
    
    public static MudTheme Theme = new()
    {
        Typography = new Typography
        {
            Default = new Default()
            {
                FontFamily = ["Raleway", "serif"]
            }
        },
        PaletteLight =
        {
            Primary = new MudColor("#1efa2d"),
            PrimaryContrastText = new MudColor("#000000"),
            Secondary = Colors.LightGreen.Darken3,
            Background = Colors.Gray.Lighten4,
            AppbarBackground = new MudColor("#1efa2d"),
            TextPrimary = Colors.Shades.Black,
            AppbarText = Colors.Shades.Black,
            DrawerText = Colors.Shades.White,
            DrawerBackground = Colors.Green.Darken4
        },
        PaletteDark =
        {
            Primary = Colors.LightGreen.Accent3,
            PrimaryContrastText = new MudColor("#000000"),
            Secondary = Colors.LightGreen.Darken3,
            AppbarBackground = Colors.LightGreen.Accent3,
            AppbarText = Colors.Shades.Black
        }
    };
}