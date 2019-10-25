using System.IO;
using FlWaspMigrator.Core;
using FlWaspMigrator.Support;

namespace FlWaspMigrator
{
    public class App : IApp
    {
        private readonly IFileSystem _fileSystem;
        private readonly IStaticData _staticData;
        private readonly IFstPresetStreamer _fstPresetStreamer;
        private readonly IWaspPresetConverter _waspPresetConverter;

        public App(
            IFileSystem fileSystem,
            IStaticData staticData,
            IFstPresetStreamer fstPresetStreamer,
            IWaspPresetConverter waspPresetConverter)
        {
            _fileSystem = fileSystem;
            _staticData = staticData;
            _fstPresetStreamer = fstPresetStreamer;
            _waspPresetConverter = waspPresetConverter;
        }
        
        public void Run(ICommandLine args)
        {
            var files = args.GetFiles();

            foreach (var inFileName in files)
            {
                var outFileName = Path.Combine(
                    Path.GetDirectoryName(inFileName),
                    $"{Path.GetFileNameWithoutExtension(inFileName)} (converted).fst");
                
                using (var inStream = _fileSystem.OpenRead(inFileName))
                using (var outStream = _fileSystem.OpenWrite(outFileName))
                {
                    var inFlWasp = _fstPresetStreamer.Read(inStream);
                    var preset = _waspPresetConverter.DecodeFlWasp(inFlWasp);
                    var outVstWasp = _waspPresetConverter.EncodeVstWasp(preset);
                    _fstPresetStreamer.Write(outStream, outVstWasp);
                    outStream.Flush();
                }
            }
        }
    }
}