using System;
using System.IO;
using System.Linq;
using FlWaspMigrator.Support;

namespace FlWaspMigrator.Core
{
    public class WaspPresetConverter : IWaspPresetConverter
    {
        private readonly IFstDataPacketConverter _fstDataPacketConverter;
        private readonly IStaticData _staticData;
        private readonly IFstPresetStreamer _fstPresetStreamer;

        public WaspPresetConverter(
            IFstDataPacketConverter fstDataPacketConverter,
            IStaticData staticData,
            IFstPresetStreamer fstPresetStreamer)
        {
            _fstDataPacketConverter = fstDataPacketConverter;
            _staticData = staticData;
            _fstPresetStreamer = fstPresetStreamer;
        }

        public WaspPreset DecodeFlWasp(FstPreset preset)
        {
            var packet = _fstDataPacketConverter.Decode(preset.Packets.Single(p => p.Id == "FLdt"));
            var offset = 73 + packet.PluginData[55];
            var buffer = new byte[164];
            packet.PluginData.AsSpan(offset, buffer.Length).CopyTo(buffer);

            return new WaspPreset
            {
                Data = buffer
            };
        }

        public FstPreset EncodeVstWasp(WaspPreset preset)
        {
            var waspVstFst = _fstPresetStreamer.Read(new MemoryStream(_staticData.GetWaspVstFst()));
            var dataPacket = waspVstFst.Packets.Single(p => p.Id == "FLdt");
            var waspVstDataPacket = _fstDataPacketConverter.Decode(dataPacket);
            var offset = waspVstDataPacket.PluginDataOffset + 1121;
            preset.Data.AsSpan().CopyTo(dataPacket.Data.AsSpan(offset + 0x40));
            return waspVstFst;
        }
    }
}