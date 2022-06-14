using System;

namespace com.liteninja.utils
{
    public static class DateTimeExtensions
    {
        #region Unix timestamp
        public static DateTime ConvertFromUnixTimestamp(this double self)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(self);
        }

        public static double ConvertToUnixTimestamp(this DateTime self)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = self.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        #endregion
    }
}