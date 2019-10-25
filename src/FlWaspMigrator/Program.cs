using Autofac;
using FlWaspMigrator.Support;

namespace FlWaspMigrator
{
    static class Program
    {
        static void Main(string[] args)
        {
            BuildContainer(args).Resolve<IApp>().Run(new CommandLine(args));
        }

        private static IContainer BuildContainer(string[] args)
        {
            var container = new ContainerBuilder();

            container.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.IsClass && !t.IsAbstract)
                .AsImplementedInterfaces()
                .SingleInstance();

            return container.Build();
        }
    }
}