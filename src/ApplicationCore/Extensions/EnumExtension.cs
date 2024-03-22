using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var displayAttribute = value.GetType()
                                        .GetMember(value.ToString())[0]
                                        .GetCustomAttributes(typeof(DisplayAttribute), false)
                                        .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
