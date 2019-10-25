namespace FlWaspMigrator.Core
{
    public class FstDataPacket
    {
        public string Version { get; set; }
        public string PluginId { get; set; }
        public byte[] PluginData { get; set; }
        public int PluginDataOffset { get; set; }
    }
}