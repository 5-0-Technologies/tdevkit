using System.Linq;

namespace SDK
{
    public abstract class DevkitConnector
    {
        protected string UrlCombine(params string[] items)
        {
            if (items?.Any() != true)
            {
                return string.Empty;
            }

            return string.Join("/", items.Where(u => !string.IsNullOrWhiteSpace(u)).Select(u => u.Trim('/', '\\')));
        }
    }
}
