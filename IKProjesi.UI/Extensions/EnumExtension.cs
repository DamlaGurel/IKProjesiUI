using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IKProjesi.UI.Extensions
{
	public static class EnumExtension
	{
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            if (memberInfo != null)
            {
                var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    return displayAttribute.GetName();
                }
            }
            return enumValue.ToString();
        }

        public static int ConvertToInt<T>(T enumValue) where T : Enum
        {
            return Convert.ToInt32(enumValue);
        }
    }
}

