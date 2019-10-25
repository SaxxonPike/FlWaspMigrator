using FlWaspMigrator.Support;

namespace FlWaspMigrator
{
    public interface IApp
    {
        void Run(ICommandLine args);
    }
}