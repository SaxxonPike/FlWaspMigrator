using System.IO;

namespace FlWaspMigrator.Core
{
    public interface IFstPacketStreamer
    {
        FstPacket Read(Stream stream);
        int Write(Stream stream, FstPacket packet);
    }
}