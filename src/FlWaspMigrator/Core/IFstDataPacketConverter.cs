namespace FlWaspMigrator.Core
{
    public interface IFstDataPacketConverter
    {
        FstDataPacket Decode(FstPacket packet);
    }
}