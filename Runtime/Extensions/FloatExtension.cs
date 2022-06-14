using System;
using UnityEngine;

namespace com.liteninja.utils
{
    public static class FloatExtension
    {
        public static bool ApproxEquals(this float self, float f2)
        {
            return Mathf.Approximately(self, f2);
        }

        /// <summary>
        /// Returns if the value is in the defined range of values, including @from and @to
        /// </summary>
        public static bool IsInRangeInclusive(this float self, float from, float to)
        {
            return self >= from && self <= to;
        }

        /// <summary>
        /// Returns if the value is in the defined range of values, excluding @from and @to
        /// </summary>
        public static bool IsInRangeExclusive(this float self, float from, float to)
        {
            return self > from && self < to;
        }

        /// <summary>
        /// Clamps a value between a minimum and a maximum angle value (in degrees)
        /// </summary>
        public static float ClampAngle(this float self, float min, float max)
        {
            return Mathf.Clamp(NormalizeAngle(self), min, max);
        }

        /// <summary>
        /// Normalizes and angle value (in degrees), making it be between the value ranges of 0 and 360.
        /// This means that the value 365 will be changed to 5, and the value -5 will be changed to 355
        /// </summary>
        public static float NormalizeAngle(this float self)
        {
            self %= 360;
            if (self < -360f) self += 360f;
            if (self > 360f) self -= 360f;
            return self;
        }

        /// <summary>
        /// Converts an angle in degrees to radians
        /// </summary>
        public static float Deg2Rad(this float self)
        {
            return self * Mathf.PI / 180;
        }

        /// <summary>
        /// Converts an angle in radians to degrees
        /// </summary>
        public static float Rad2Deg(this float self)
        {
            return self * 180 / Mathf.PI;
        }

        /// <summary>
        /// Returns the value raised to power @exponent.
        /// </summary>
        public static float Pow(this float self, float exponent)
        {
            return Mathf.Pow(self, exponent);
        }


        /// <summary>
        /// Remap a value from one range to another.
        /// </summary>
        public static float Remap(this float self,
            float sourceMin, float sourceMax,
            float targetMin, float targetMax)
        {
            return targetMin + (self - sourceMin) * (targetMax - targetMin) / (sourceMax - sourceMin);
        }

        public static float Normalize(this float self, float min, float max)
        {
            return (self - min) / (max - min);
        }

        public static float Inverse(this float self)
        {
            return self * -1;
        }
        
        
        public static float Complement(this float self)
        {
            return 1.0f - self;
        }
    }
}