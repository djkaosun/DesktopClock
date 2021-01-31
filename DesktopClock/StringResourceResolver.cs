using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock
{
    internal static class StringResourceResolver
    {
        internal static Uri Resolve(CultureInfo culture)
        {
            switch (culture.Name)
            {
                case "ja-JP":
                    return new Uri(@"StringResource." + culture.Name + @".xaml", UriKind.Relative);
                default:
                    return new Uri(@"StringResource.xaml", UriKind.Relative);
            }
        }
    }
}
