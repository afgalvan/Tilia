using System.Linq;

namespace Presentation.Utils
{
    public static class Ensure
    {
        public static bool AreAllFieldsCompleted(params string[] fieldsText)
        {
            return !fieldsText.Any(string.IsNullOrEmpty);
        }
    }
}
