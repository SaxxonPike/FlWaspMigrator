using System.IO;

namespace FlWaspMigrator.Core
{
    public class FstDataPacketConverter : IFstDataPacketConverter
    {
        public FstDataPacket Decode(FstPacket packet)
        {
            var reader = new BinaryReader(new MemoryStream(packet.Data));

            reader.ReadByte();
            
            var versionLength = reader.ReadByte();
            var version = Encoders.Ascii.GetString(reader.ReadBytes(versionLength - 1));
            reader.ReadByte();

            reader.ReadBytes(3);

            var pluginIdLength = reader.ReadByte();
            var pluginId = Encoders.Utf16.GetString(reader.ReadBytes(pluginIdLength - 2));
            reader.ReadBytes(2);

            var dataOffset = (int) reader.BaseStream.Position;
            var data = reader.ReadBytes(packet.Data.Length - (int) reader.BaseStream.Position);
            
            return new FstDataPacket
            {
                Version = version,
                PluginId = pluginId,
                PluginData = data,
                PluginDataOffset = dataOffset
            };
        }
    }
}