using System.Windows.Media;

namespace Presentation.Utils
{
    public static class ColorPalette
    {
        private static readonly ColorsUtil ColorsUtil = new(new BrushConverter());

        public static Brush PrimaryColor => ColorsUtil.FromHex("#FF6AB9B4");
        public static Brush Gray => ColorsUtil.FromHex("#FF99A3C4");
    }
}
