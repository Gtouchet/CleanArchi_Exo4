using System.ComponentModel;
using System.Reflection;

namespace CleanCalculator;

public static class Utils
{
    public static string GetEnumDescription(Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[]? attributes = fi!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }
        return value.ToString();
    }
}
