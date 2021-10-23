using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation.Utils
{
    public class SelectionUtil
    {
        private readonly ColorUtil _colorUtil;

        public SelectionUtil(ColorUtil colorUtil)
        {
            _colorUtil = colorUtil;
        }

        public void RestorePanelButtonsBackground(Panel panel, string hexCodeColor)
        {
            Brush defaultColor = _colorUtil.FromHex(hexCodeColor);
            RestorePanelButtonsBackground(panel, defaultColor);
        }

        public void RestorePanelButtonsBackground(Panel panel, Brush defaultColor)
        {
            panel.Children.OfType<Button>()
                .ToList().ForEach(button => button.Background = defaultColor);
        }

        public void RestoreElementsForeground(IEnumerable<TextBlock> textBlocks,
            string hexCodeColor)
        {
            Brush defaultColor = _colorUtil.FromHex(hexCodeColor);
            textBlocks.ToList().ForEach(textBlock => textBlock.Foreground = defaultColor);
        }

        public void RestoreElementsForeground(IEnumerable<Control> controls,
            string hexCodeColor)
        {
            Brush defaultColor = _colorUtil.FromHex(hexCodeColor);
            controls.ToList().ForEach(control => control.Foreground = defaultColor);
        }
    }
}
