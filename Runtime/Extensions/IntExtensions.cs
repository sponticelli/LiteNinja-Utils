using UnityEngine;

namespace LiteNinja.Utils.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns if the value is in the defined range of values, including @from and @to
        /// </summary>
        public static bool IsInRangeInclusive(this int self, int from, int to)
        {
            return self >= from && self <= to;
        }

        /// <summary>
        /// Returns if the value is in the defined range of values, excluding @from and @to
        /// </summary>
        public static bool IsInRangeExclusive(this int self, int from, int to)
        {
            return self > from && self < to;
        }

        public static int Inverse(this int self)
        {
            return self * -1;
        }

        public static bool ContainBits(this int self, int target)
        {
            return (self & target) == target;
        }

        public static bool IntersectBits(this int self1, int self2)
        {
            return (self1 & self2) != 0;
        }

        public static void RemoveBits(this ref int self, int target)
        {
            self &= ~target;
        }

        public static void SetBit0(this ref int self, int bit)
        {
            self &= (~(1 << bit));
        }

        public static void SetBit0(this ref uint self, int bit)
        {
            self &= (~(1u << bit));
        }

        public static void SetBit1(this ref int self, int bit)
        {
            self |= (1 << bit);
        }

        public static void SetBit1(this ref uint self, int bit)
        {
            self |= (1u << bit);
        }

        public static void SetBit(this ref int self, int bit, bool is1)
        {
            if (is1)
            {
                self.SetBit1(bit);
            }
            else
            {
                self.SetBit0(bit);
            }
        }

        public static void SetBit(this ref uint self, int bit, bool is1)
        {
            if (is1) self.SetBit1(bit);
            else self.SetBit0(bit);
        }

        public static void ReverseBit(this ref int self, int bit)
        {
            self ^= (1 << bit);
        }

        public static void ReverseBit(this ref uint self, int bit)
        {
            self ^= (1u << bit);
        }

        public static bool GetBit(this int self, int bit)
        {
            return (self & (1 << bit)) != 0;
        }

        public static bool GetBit(this uint self, int bit)
        {
            return (self & (1u << bit)) != 0;
        }

        public static int WithRandomSign(this int value, float negativeProbability = 0.5f)
        {
            return Random.value < negativeProbability ? -value : value;
        }

        public static int ToGoldenRatioProportion(this int self)
        {
            return Mathf.RoundToInt(1.618033988749894848f * self);
        }
    }
}