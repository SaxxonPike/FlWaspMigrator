using System.IO;

namespace FlWaspMigrator.Support
{
    public interface IFileSystem
    {
        Stream OpenRead(string fileName);
        Stream OpenWrite(string fileName);
    }
}