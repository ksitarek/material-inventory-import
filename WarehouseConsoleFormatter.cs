using MaterialInventoryImport.Model;
using System.Linq;

namespace MaterialInventoryImport
{
    internal class WarehouseConsoleFormatter : IWarehouseConsoleFormatter
    {
        private Warehouse _warehouse;
        private readonly IConsole _console;

        public WarehouseConsoleFormatter(IConsole console)
        {
            _console = console;
        }

        public void Print(Warehouse warehouse)
        {
            _warehouse = warehouse;
            PrintHeader();
            PrintStock();
        }

        private void PrintStock()
        {
            foreach (var material in _warehouse.MaterialStock.OrderBy(m => m.Key.Id))
            {
                _console.WriteLine($"{material.Key.Id}: {material.Value}");
            }
        }

        private void PrintHeader()
        {
            _console.WriteLine($"{_warehouse.Name} (total {_warehouse.Total})");
        }
    }
}