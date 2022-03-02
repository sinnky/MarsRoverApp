using System;
using System.ComponentModel.DataAnnotations;

namespace Helpers
{
    public static class EnumHelper<T>
    {
        /// <summary>
        /// Get Enum Display Name Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (!(fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] descriptionAttributes)) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
