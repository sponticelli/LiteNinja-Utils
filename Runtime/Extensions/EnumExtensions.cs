using System;
using System.Linq;
using UnityEngine;

namespace com.liteninja.utils
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the next value. If the actual value is the last, it will return the first one (circular) 
        /// </summary>
        public static T Next<T>(this T enumValue) where T : Enum
        {
            var array = (T[])Enum.GetValues(typeof(T));
            var i = Array.IndexOf(array, enumValue) + 1;
            return (i >= array.Length) ? array[0] : array[i];
        }

        /// <summary>
        /// Returns the previous value. If the actual value is the first, it will return the last one (circular) 
        /// </summary>
        public static T Previous<T>(this T enumValue) where T : Enum
        {
            var array = (T[])Enum.GetValues(typeof(T));
            var i = Array.IndexOf(array, enumValue) - 1;
            return (i < 0) ? array[^1] : array[i];
        }


        /// <summary>
        /// Returns the integer value.
        /// </summary>
        public static int ToInt<T>(this T enumValue) where T : Enum
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue));

            if (!typeof(int).IsAssignableFrom(Enum.GetUnderlyingType(typeof(T))))
                throw new ArgumentException("Underlying type of enum value isn't int.");

            return (int)(object)enumValue;
        }

        public static string GetInspectorName<T>(this T enumValue) where T : Enum
        {
            if (enumValue == null)
                throw new ArgumentNullException(nameof(enumValue));

            // Get the attributes of the enum value.
            var enumType = typeof(T);
            var attributes = enumType.GetMember(enumValue.ToString())
                .First(info => info.DeclaringType == enumType)
                .GetCustomAttributes(typeof(InspectorNameAttribute), false);

            if (attributes.Length == 0)
                throw new InvalidOperationException($"No attributes where found on the enum value {enumValue}.");

            // Return the display name stored by the first inspector name found on the enum value.
            return attributes.Cast<InspectorNameAttribute>().First().displayName;
        }
    }
}