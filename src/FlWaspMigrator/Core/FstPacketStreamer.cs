using System.IO;

namespace FlWaspMigrator.Core
{
    public class FstPacketStreamer : IFstPacketStreamer
    {
        public FstPacket Read(Stream stream)
        {
            var id = new byte[4];
            if (stream.Read(id, 0, 4) < 4)
                return null;

            if (id[0] != 0x46 || id[1] != 0x4C)
                return null;
            
            var reader = new BinaryReader(stream);
            var length = reader.ReadInt32();
            var data = reader.ReadBytes(length);
            
            return new FstPacket
            {
                Id = Encoders.Ascii.GetString(id),
                Data = data
            };
        }

        public int Write(Stream stream, FstPacket packet)
        {
            var writer = new BinaryWriter(stream);
            var id = Encoders.Ascii.GetBytes(packet.Id);
            writer.Write(id);
            writer.Write(packet.Data.Length);
            writer.Write(packet.Data);
            return id.Length + packet.Data.Length + 4;
        }
    }
}