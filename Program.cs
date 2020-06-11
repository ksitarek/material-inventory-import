using Microsoft.Extensions.DependencyInjection;

namespace MaterialInventoryImport
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IConsole, ConsoleWrapper>()
                .AddTransient<IEntryParser, EntryParser>()
                .AddTransient<IInputProcessor, ConsoleIOProcessor>()
                .AddTransient<IWarehouseConsoleFormatter, WarehouseConsoleFormatter>()
                .BuildServiceProvider();

            var processor = serviceProvider.GetService<IInputProcessor>();
            processor.Process();
        }
    }
}