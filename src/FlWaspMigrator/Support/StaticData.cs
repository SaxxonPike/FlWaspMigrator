using System.IO;
using System.Reflection;

namespace FlWaspMigrator.Support
{
    public class StaticData : IStaticData
    {
        private string GetStaticDataPath() => 
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data");

        public byte[] GetWaspFlFst() => 
            File.ReadAllBytes(Path.Combine(GetStaticDataPath(), "wasp-fl.fst"));

        public byte[] GetWaspVstFst() =>
            File.ReadAllBytes(Path.Combine(GetStaticDataPath(), "wasp-vst.fst"));
    }
}