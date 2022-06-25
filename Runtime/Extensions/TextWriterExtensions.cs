using System.IO;

namespace LiteNinja.Utils.Extensions
{
    public static class TextWriterExtensions
    {
        public static void WriteLineLF(this TextWriter self, object value)
        {
            self.Write(value);
            self.Write("\n");
        }
        
        public static void WriteLineLF(this TextWriter self, string format, params object[] args)
        {
            self.Write(format, args);
            self.Write("\n");
        }
        
        
    }
}