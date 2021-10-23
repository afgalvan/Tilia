using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation.Utils
{
    public class SelectionUtil
    {
        public static void RestorePanelButtonsBackground(Panel panel, Brush defaultColor)
        {
            panel.Children.OfType<Button>()
                .ToList().ForEach(button => button.Background = defaultColor);
        }

        public static void RestoreElementsForeground(IEnumerable<TextBlock> textBlocks,
            Brush defaultColor)
        {
            textBlocks.ToList().ForEach(textBlock => textBlock.Foreground = defaultColor);
        }

        public static void RestoreElementsForeground(IEnumerable<Control> controls,
            Brush defaultColor)
        {
            controls.ToList().ForEach(control => control.Foreground = defaultColor);
        }
    }
}
