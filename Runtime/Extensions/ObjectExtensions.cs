using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace com.liteninja.utils
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///  Checks if the obj equals to all elements of objects array.
        /// </summary>
        public static bool EqualsToAll(this object self, params object[] objects) => objects.All(o => o.Equals(self));

        /// <summary>
        ///  Checks if the value equals to at least one of elements of values array.
        /// </summary>
        public static bool EqualsToAny(this object self, params object[] objects) => objects.Any(o => o.Equals(self));

        public static string ToString(this object anObject, string aFormat)
        {
            return ToString(anObject, aFormat, null);
        }

        public static string ToString(this object anObject, string aFormat, IFormatProvider formatProvider)
        {
            var sb = new StringBuilder();
            var type = anObject.GetType();
            var reg = new Regex(@"({)([^}]+)(})", RegexOptions.IgnoreCase);
            var mc = reg.Matches(aFormat);
            var startIndex = 0;
            foreach (Match m in mc)
            {
                var g = m.Groups[2]; 
                var length = g.Index - startIndex - 1;
                sb.Append(aFormat.Substring(startIndex, length));

                var toGet = string.Empty;
                var toFormat = string.Empty;
                var formatIndex = g.Value.IndexOf(":"); 
                if (formatIndex == -1) 
                {
                    toGet = g.Value;
                }
                else 
                {
                    toGet = g.Value.Substring(0, formatIndex);
                    toFormat = g.Value.Substring(formatIndex + 1);
                }
                
                var retrievedProperty = type.GetProperty(toGet);
                Type retrievedType = null;
                object retrievedObject = null;
                if (retrievedProperty != null)
                {
                    retrievedType = retrievedProperty.PropertyType;
                    retrievedObject = retrievedProperty.GetValue(anObject, null);
                }
                else 
                {
                    var retrievedField = type.GetField(toGet);
                    if (retrievedField != null)
                    {
                        retrievedType = retrievedField.FieldType;
                        retrievedObject = retrievedField.GetValue(anObject);
                    }
                }

                if (retrievedType != null)
                {
                    string result;
                    if (toFormat == string.Empty)
                    {
                        result = retrievedType.InvokeMember("ToString",
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                            , null, retrievedObject, null) as string;
                    }
                    else
                    {
                        result = retrievedType.InvokeMember("ToString",
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase
                            , null, retrievedObject, new object[] { toFormat, formatProvider }) as string;
                    }

                    sb.Append(result);
                }
                else
                {
                    sb.Append("{");
                    sb.Append(g.Value);
                    sb.Append("}");
                }

                startIndex = g.Index + g.Length + 1;
            }

            if (startIndex < aFormat.Length)
            {
                sb.Append(aFormat.Substring(startIndex));
            }

            return sb.ToString();
        }
    }
}