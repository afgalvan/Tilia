using System.Windows.Controls;

namespace Presentation.Utils
{
    public class ContentAreaUtil
    {
        public ContentAreaUtil()
        {
        }

        public void DisplayContentInArea(ContentControl contentArea, UserControl userControl)
        {
            contentArea.Content = userControl;
        }
    }
}
