using System.Text;

namespace FlWaspMigrator.Core
{
    internal static class Encoders
    {
        public static readonly Encoding Ascii = new ASCIIEncoding();
        public static readonly Encoding Utf16 = new UnicodeEncoding();
    }
}