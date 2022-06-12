using System.IO;

namespace com.liteninja.utils
{
    public static class TextWriterExtensions
    {
        public static void WriteLineLF(this TextWriter self, object value)
        {
            self.Write(value);
            self.Write("\n");
        }
    }
}