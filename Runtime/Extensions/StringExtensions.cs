using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using static System.Int64;
using static System.String;

namespace com.liteninja.utils
{
    public static class StringExtensions
    {
        public static string Colored(this string self, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{self}</color>";
        }
        
        /// <summary>
        ///  Checks if a string is null
        /// </summary>
        public static bool IsNull(this string self)
        {
            return self == null;
        }

        /// <summary>
        ///     Checks if a string is null or empty
        /// </summary>
        /// <param name="self">string to evaluate</param>
        /// <returns>true if string is null or is empty else false</returns>
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static bool IsNullOrWhiteSpace(this string self)
        {
            return self == null || self.All(char.IsWhiteSpace);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string self)
        {
            return string.IsNullOrEmpty(self) ||
                   ReferenceEquals(self, null) ||
                   string.IsNullOrEmpty(self.Trim());
        }

        public static string RemoveWhitespace(this string self)
        {
            return Concat(self.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Checks if string length is a certain minimum number of characters, does not ignore leading and trailing
        /// white-space.
        /// null strings will always evaluate to false.
        /// </summary>
        public static bool IsMinLength(this string self, int minCharLength)
        {
            return self != null && self.Length >= minCharLength;
        }

        /// <summary>
        /// Checks if string length is consists of specified allowable maximum char length. does not ignore leading and
        /// trailing white-space.
        /// null strings will always evaluate to false.
        /// </summary>
        public static bool IsMaxLength(this string self, int maxCharLength)
        {
            return self != null && self.Length <= maxCharLength;
        }

        /// <summary>
        /// Checks if string length satisfies minimum and maximum allowable char length. does not ignore leading and
        /// trailing white-space
        /// </summary>
        public static bool IsLength(this string self, int minCharLength, int maxCharLength)
        {
            return self != null && self.Length >= minCharLength && self.Length <= minCharLength;
        }

        /// <summary>
        ///  Gets the number of characters in string checks if string is null
        /// </summary>
        public static int? GetLength(string self)
        {
            return self?.Length;
        }


        /// <summary>
        /// Checks if the String contains only Unicode letters.
        /// </summary>
        public static bool IsAlpha(this string self)
        {
            return !IsNullOrEmpty(self) && self.Trim().Replace(" ", "").All(char.IsLetter);
        }

        /// <summary>
        /// Checks if the String contains only Unicode letters, digits.
        /// </summary>
        public static bool IsAlphaNumeric(this string self)
        {
            return !IsNullOrEmpty(self) && self.Trim().Replace(" ", "").All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// Count number of occurrences in string
        /// </summary>
        public static int CountOccurrences(this string self, string stringToMatch)
        {
            return Regex.Matches(self, stringToMatch, RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        /// Convert a string to its equivalent byte array
        /// </summary>
        public static byte[] ToBytes(this string self)
        {
            var bytes = new byte[self.Length * sizeof(char)];
            Buffer.BlockCopy(self.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Reverse string
        /// </summary>
        public static string Reverse(this string self)
        {
            var chars = new char[self.Length];
            for (int i = self.Length - 1, j = 0; i >= 0; --i, ++j)
            {
                chars[j] = self[i];
            }

            self = new string(chars);
            return self;
        }

        /// <summary>
        ///  Truncate String and append ... at end
        /// </summary>
        public static string Truncate(this string self, int maxLength)
        {
            if (IsNullOrEmpty(self) || maxLength <= 0)
            {
                return Empty;
            }

            if (self.Length > maxLength)
            {
                return self.Substring(0, maxLength) + "...";
            }

            return self;
        }

        public static int IndexOfNonWhiteSpace(this string self, int startIndex = 0)
        {
            for (; startIndex < self.Length; startIndex++)
            {
                if (!char.IsWhiteSpace(self, startIndex)) return startIndex;
            }

            return -1;
        }

        public static int LastIndexOfNonWhiteSpace(this string self, int startIndex)
        {
            for (; startIndex >= 0; startIndex--)
            {
                if (!char.IsWhiteSpace(self, startIndex)) return startIndex;
            }

            return -1;
        }

        public static int LastIndexOfNonWhiteSpace(this string self)
        {
            return LastIndexOfNonWhiteSpace(self, self.Length - 1);
        }

        /// <summary>
        /// Validate email address
        /// </summary>
        public static bool IsEmailAddress(this string self)
        {
            const string pattern =
                "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.Match(self, pattern).Success;
        }

        /// <summary>
        /// Read in a sequence of words from standard input and capitalize each one
        /// (make first letter uppercase; make rest lowercase).
        /// </summary>
        public static string Capitalize(this string self)
        {
            if (self.Length == 0)
            {
                return self;
            }

            return self.Substring(0, 1).ToUpper() + self.Substring(1).ToLower();
        }

        #region Prefix / Suffix

        /// <summary>
        /// Check if a string does not start with prefix
        /// </summary>
        public static bool DoesNotStartWith(this string val, string prefix)
        {
            return val == null || prefix == null || !val.StartsWith(prefix, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Check if a string does not end with prefix
        /// </summary>
        public static bool DoesNotEndWith(this string val, string suffix)
        {
            return val == null || suffix == null || !val.EndsWith(suffix, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Extracts the left part of the input string limited with the length parameter
        /// </summary>
        public static string Left(this string val, int length)
        {
            if (IsNullOrEmpty(val))
            {
                throw new ArgumentNullException(nameof(val));
            }

            if (length < 0 || length > val.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length),
                    "length cannot be higher than total string length or less than 0");
            }

            return val.Substring(0, length);
        }

        /// <summary>
        /// Extracts the right part of the input string limited with the length parameter
        /// </summary>
        public static string Right(this string val, int length)
        {
            if (IsNullOrEmpty(val))
            {
                throw new ArgumentNullException(nameof(val));
            }

            if (length < 0 || length > val.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length),
                    "length cannot be higher than total string length or less than 0");
            }

            return val.Substring(val.Length - length);
        }


        /// <summary>
        ///  Gets first character in string
        /// </summary>
        public static string FirstCharacter(this string val)
        {
            return !IsNullOrEmpty(val)
                ? val.Length >= 1
                    ? val.Substring(0, 1)
                    : val
                : null;
        }

        /// <summary>
        /// Gets last character in string
        /// </summary>
        public static string LastCharacter(this string val)
        {
            return !IsNullOrEmpty(val)
                ? val.Length >= 1
                    ? val.Substring(val.Length - 1, 1)
                    : val
                : null;
        }

        /// <summary>
        /// Check a String ends with another string ignoring the case.
        /// </summary>
        public static bool EndsWithIgnoreCase(this string val, string suffix)
        {
            if (val == null)
            {
                throw new ArgumentNullException(nameof(val), "val parameter is null");
            }

            if (suffix == null)
            {
                throw new ArgumentNullException(nameof(suffix), "suffix parameter is null");
            }

            return val.Length >= suffix.Length &&
                   val.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Check a String starts with another string ignoring the case.
        /// </summary>
        public static bool StartsWithIgnoreCase(this string val, string prefix)
        {
            if (val == null)
            {
                throw new ArgumentNullException(nameof(val), "val parameter is null");
            }

            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix), "prefix parameter is null");
            }

            return val.Length >= prefix.Length && val.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        ///  Removes the first part of the string, if no match found return original string
        /// </summary>
        public static string RemovePrefix(this string val, string prefix, bool ignoreCase = true)
        {
            if (!IsNullOrEmpty(val) && (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
            {
                return val.Substring(prefix.Length, val.Length - prefix.Length);
            }

            return val;
        }

        /// <summary>
        ///  Removes the end part of the string, if no match found return original string
        /// </summary>
        public static string RemoveSuffix(this string val, string suffix, bool ignoreCase = true)
        {
            if (!IsNullOrEmpty(val) && (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
            {
                return val.Substring(0, val.Length - suffix.Length);
            }

            return null;
        }

        /// <summary>
        ///  Appends the suffix to the end of the string if the string does not already end in the suffix.
        /// </summary>
        public static string AppendSuffixIfMissing(this string val, string suffix, bool ignoreCase = true)
        {
            if (IsNullOrEmpty(val) || (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
            {
                return val;
            }

            return val + suffix;
        }

        /// <summary>
        ///  Appends the prefix to the start of the string if the string does not already start with prefix.
        /// </summary>
        public static string AppendPrefixIfMissing(this string val, string prefix, bool ignoreCase = true)
        {
            if (IsNullOrEmpty(val) || (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
            {
                return val;
            }

            return prefix + val;
        }

        #endregion

        /// <summary>
        /// Converts string to its Enum type
        /// Checks of string is a member of type T enum before converting if fails returns default enum
        /// </summary>
        public static T ToEnum<T>(this string self, T defaultValue = default(T)) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type T Must of type Enum");
            }

            var isParsed = Enum.TryParse(self, true, out T result);
            return isParsed ? result : defaultValue;
        }

        /// <summary>
        /// returns a default String self if given self is null or empty
        /// </summary>
        public static string GetDefaultIfNullOrEmpty(this string self, string defaultValue)
        {
            if (IsNullOrEmpty(self)) return defaultValue;
            self = self.Trim();
            return self.Length > 0 ? self : defaultValue;
        }

        /// <summary>
        /// Gets empty String if passed self is of type Null/Nothing
        /// </summary>
        public static string GetEmptyStringIfNull(this string self)
        {
            return self != null ? self.Trim() : "";
        }

        /// <summary>
        /// Checks if a string is null and returns String if not Empty else returns null/Nothing
        /// </summary>
        public static string GetNullIfEmptyString(this string self)
        {
            if (self == null || self.Length <= 0)
            {
                return null;
            }

            self = self.Trim();
            return self.Length > 0 ? self : null;
        }

        /// <summary>
        /// Divide a character string by the specified number of characters.
        /// </summary>
        public static IEnumerable<string> SubstringAtCount(this string self, int count)
        {
            var result = new List<string>();
            var length = (int)Math.Ceiling((double)self.Length / count);

            for (var i = 0; i < length; i++)
            {
                var start = count * i;
                if (self.Length <= start)
                {
                    break;
                }

                result.Add(self.Length < start + count ? self.Substring(start) : self.Substring(start, count));
            }

            return result;
        }

        public static string[] Split(this string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize))
                .ToArray();
        }

        #region Boolean

        /// <summary>
        /// Converts string to its boolean equivalent
        /// </summary>
        public static bool ToBoolean(this string self)
        {
            if (IsNullOrEmpty(self) || IsNullOrWhiteSpace(self))
            {
                throw new ArgumentException("self");
            }

            var val = self.ToLower().Trim();
            switch (val)
            {
                case "false":
                case "f":
                case "no":
                case "n":
                    return false;
                case "true":
                case "t":
                case "yes":
                case "y":
                    return true;
                default:
                    throw new ArgumentException("Invalid boolean");
            }
        }

        #endregion

        #region Integer

        /// <summary>
        /// checks if a string is a valid int32 self
        /// </summary>
        public static bool IsInt32(this string self)
        {
            int retNum;
            var isNum = int.TryParse(self, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>
        ///  Converts the string representation of a number to its 32-bit signed integer equivalent
        /// </summary>
        public static int ToInt32(this string self)
        {
            int.TryParse(self, out var number);
            return number;
        }

        /// <summary>
        /// checks if a string is a valid int64 self
        /// </summary>
        public static bool IsInt64(this string self)
        {
            long retNum;
            var isNum = TryParse(self, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>
        ///  Converts the string representation of a number to its 64-bit signed integer equivalent
        /// </summary>
        public static long ToInt64(this string self)
        {
            TryParse(self, out var number);
            return number;
        }

        #endregion

        #region Float / Double

        /// <summary>
        /// checks if a string is a valid double self
        /// </summary>
        public static bool IsDouble(this string self)
        {
            double retNum;
            var isNum = double.TryParse(self, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>
        /// checks if a string is a valid double self
        /// </summary>
        public static bool IsFloat(this string self)
        {
            float retNum;
            var isNum = float.TryParse(self, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>
        ///  Converts the string representation of a number to its float equivalent
        /// </summary>
        public static float ToFloat(this string self)
        {
            float.TryParse(self, out var number);
            return number;
        }

        /// <summary>
        ///  Converts the string representation of a number to its float equivalent
        /// </summary>
        public static double ToDouble(this string self)
        {
            double.TryParse(self, out var number);
            return number;
        }

        #endregion

        public static T Cast<T>(this string self)
        {
            var selfType = typeof(T);

            if (!selfType.IsPrimitive && !selfType.IsEnum) 
                throw new NotSupportedException("This method only supports primitive types and Enums.");

            if (selfType.IsPrimitive)
            {
                if (selfType != typeof(bool)) return (T)Convert.ChangeType(self, selfType);
                if (int.TryParse(self, out var intInput))
                {
                    return (T)Convert.ChangeType(intInput, selfType);
                }

                return (T)Convert.ChangeType(self, selfType);
            }
            
            try
            {
                return (T)Enum.Parse(selfType, self);
            }
            catch
            {
                if (!int.TryParse(self, out var intInput)) throw;
                var allValues = Enum.GetValues(selfType);

                if (intInput < 0 || intInput > allValues.Length - 1)
                {
                    throw new IndexOutOfRangeException(
                        "The 'input' is out of the range of the target enum's array of values.");
                }

                return (T)allValues.GetValue(intInput);
            }
        }
        
        public static Color32 ToColor(this string hexColor)
        {
            ColorUtility.TryParseHtmlString(hexColor, out var color);
            return color;
        }

        #region Time

        /// <summary>
        ///  Checks if date with dateFormat is parsable to DateTime
        /// </summary>
        public static bool IsDateTime(this string self, string dateFormat)
        {
            // ReSharper disable once RedundantAssignment
            var dateVal = default(DateTime);
            return DateTime.TryParseExact(self, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dateVal);
        }

        #endregion

        #region Encrypt

        public static string MD5(this string self)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var stringBuilder = new StringBuilder();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(self));
            foreach (var t in hash)
            {
                stringBuilder.Append(t.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        ///  Encrypt a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        public static string Encrypt(this string self, string key)
        {
            var cspParameter = new CspParameters { KeyContainerName = key };
            var rsaServiceProvider = new RSACryptoServiceProvider(cspParameter) { PersistKeyInCsp = true };
            var bytes = rsaServiceProvider.Encrypt(Encoding.UTF8.GetBytes(self), true);
            return BitConverter.ToString(bytes);
        }


        /// <summary>
        /// Decrypt a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        public static string Decrypt(this string self, string key)
        {
            var cspParams = new CspParameters { KeyContainerName = key };
            var rsaServiceProvider = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
            var decryptArray = self.Split(new[] { "-" }, StringSplitOptions.None);
            var decryptByteArray = Array.ConvertAll(decryptArray,
                (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));
            var bytes = rsaServiceProvider.Decrypt(decryptByteArray, true);
            var result = Encoding.UTF8.GetString(bytes);
            return result;
        }

        #endregion
    }
}