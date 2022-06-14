namespace com.liteninja.utils
{
    public static class ShortExtensions
    {
        public static void SetBit0(this ref short self, int bit)
        {
            self = (short)(self & (~(1 << bit)));
        }

        public static void SetBit0(this ref ushort self, int bit)
        {
            self = (ushort)(self & (~(1u << bit)));
        }

        public static void SetBit1(this ref short self, int bit)
        {
            self = (short)((ushort)self | (1u << bit));
        }

        public static void SetBit1(this ref ushort self, int bit)
        {
            self = (ushort)(self | (1u << bit));
        }

        public static void SetBit(this ref short self, int bit, bool is1)
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

        public static void SetBit(this ref ushort self, int bit, bool is1)
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

        public static void ReverseBit(this ref short self, int bit)
        {
            self = (short)(self ^ (1 << bit));
        }

        public static void ReverseBit(this ref ushort self, int bit)
        {
            self = (ushort)(self ^ (1u << bit));
        }

        public static bool GetBit(this short self, int bit)
        {
            return (self & (1 << bit)) != 0;
        }

        public static bool GetBit(this ushort self, int bit)
        {
            return (self & (1u << bit)) != 0;
        }
    }
}