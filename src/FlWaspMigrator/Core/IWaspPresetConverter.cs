namespace FlWaspMigrator.Core
{
    public interface IWaspPresetConverter
    {
        WaspPreset DecodeFlWasp(FstPreset preset);
        FstPreset EncodeVstWasp(WaspPreset preset);
    }
}