using System.Windows.Media;

namespace Presentation.Utils
{
    public class ColorPalette
    {
        private static readonly ColorsUtil ColorsUtil = new(new BrushConverter());

        public static Brush Main => ColorsUtil.FromHex("#FF6AB9B4");
        public static Brush Gray => ColorsUtil.FromHex("#FF99A3C4");
    }
}
