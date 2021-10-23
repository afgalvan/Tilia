using System.Windows.Media;

namespace Presentation.Utils
{
    public class ColorsUtil
    {
        private readonly BrushConverter _brushConverter;

        public ColorsUtil(BrushConverter brushConverter)
        {
            _brushConverter = brushConverter;
        }

        public Brush FromHex(string hexCodeColor)
        {
            return (Brush)_brushConverter.ConvertFrom(hexCodeColor);
        }
    }
}
