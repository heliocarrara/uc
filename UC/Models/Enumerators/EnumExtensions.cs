using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UC.Models.Enumerators
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum e)
        {
            System.Reflection.FieldInfo fi = e.GetType().GetField(e.ToString());

            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);

            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }

            return e.ToString();
        }
    }
}