using System.IO;

namespace FlWaspMigrator.Core
{
    public interface IFstPresetStreamer
    {
        FstPreset Read(Stream stream);
        int Write(Stream stream, FstPreset preset);
    }
}