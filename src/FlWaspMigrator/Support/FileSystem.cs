using System.IO;

namespace FlWaspMigrator.Support
{
    public class FileSystem : IFileSystem
    {
        public Stream OpenRead(string fileName) => File.OpenRead(fileName);
        public Stream OpenWrite(string fileName) => File.OpenWrite(fileName);
    }
}