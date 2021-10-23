using System.Windows.Media;

namespace Presentation.Utils
{
    public class ColorUtil
    {
        private readonly BrushConverter _brushConverter;

        public ColorUtil(BrushConverter brushConverter)
        {
            _brushConverter = brushConverter;
        }

        public Brush FromHex(string hexCodeColor)
        {
            return (Brush)_brushConverter.ConvertFrom(hexCodeColor);
        }
    }
}
