using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlWaspMigrator.Core
{
    public class FstPresetStreamer : IFstPresetStreamer
    {
        private readonly IFstPacketStreamer _fstPacketStreamer;

        public FstPresetStreamer(IFstPacketStreamer fstPacketStreamer)
        {
            _fstPacketStreamer = fstPacketStreamer;
        }

        public FstPreset Read(Stream stream)
        {
            var result = new FstPreset {Packets = new List<FstPacket>()};

            while (true)
            {
                var packet = _fstPacketStreamer.Read(stream);
                if (packet == null)
                    break;

                result.Packets.Add(packet);
            }

            return result;
        }

        public int Write(Stream stream, FstPreset preset)
        {
            return preset.Packets.Sum(packet => _fstPacketStreamer.Write(stream, packet));
        }
    }
}