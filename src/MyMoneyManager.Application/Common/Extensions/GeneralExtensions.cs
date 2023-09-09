using System.ComponentModel;

namespace MyMoneyManager.Application.Common.Extensions;
public static class GeneralExtensions
{
    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());

        if (fi == null)
        {
            return string.Empty;
        }

        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}
