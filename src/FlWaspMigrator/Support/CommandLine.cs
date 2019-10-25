using System.Linq;

namespace FlWaspMigrator.Support
{
    public class CommandLine : ICommandLine
    {
        private readonly string[] _args;

        public CommandLine(string[] args)
        {
            _args = args;
        }

        public string[] GetFiles()
        {
            return _args.ToArray();
        }
    }
}