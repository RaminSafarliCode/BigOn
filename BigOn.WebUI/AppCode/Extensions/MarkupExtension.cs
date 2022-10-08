using System.Text.RegularExpressions;

namespace BigOn.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string ToPlainText(this string text)
        {
            text = Regex.Replace(text, "<[^>]*>", "");
            return text;
        }
    }
}
