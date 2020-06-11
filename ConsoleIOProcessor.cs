using MaterialInventoryImport.Model;
using System.Collections.Generic;
using System.Linq;

namespace MaterialInventoryImport
{
    internal class ConsoleIOProcessor : IInputProcessor
    {
        private readonly IConsole _console;
        private readonly IEntryParser _entryParser;
        private readonly IWarehouseConsoleFormatter _warehouseConsoleFormatter;
        private ICollection<Warehouse> _warehouses = new List<Warehouse>();

        public ConsoleIOProcessor(IConsole console, IEntryParser entryParser, IWarehouseConsoleFormatter warehouseConsoleFormatter)
        {
            _console = console;
            _entryParser = entryParser;
            _warehouseConsoleFormatter = warehouseConsoleFormatter;
        }

        public void Process()
        {
            ParseConsoleInput();
            PrintConsoleOut();
        }

        private void ParseConsoleInput()
        {
            string line;
            while ((line = _console.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                    continue;
                ParseLine(line);
            }
        }

        private void PrintConsoleOut()
        {
            foreach (var warehouse in _warehouses.OrderByDescending(x => x.Total).ThenByDescending(x => x.Name))
            {
                _warehouseConsoleFormatter.Print(warehouse);
                _console.WriteLine();
            }
        }

        private void ParseLine(string line)
        {
            var lineInfo = _entryParser.Parse(line);
            var stock = new Material() { Id = lineInfo.MaterialId };
            foreach (var warehouseStock in lineInfo.WarehouseStock)
            {
                var warehouse = GetWarehouse(warehouseStock.Key);
                warehouse.AddMaterial(stock, warehouseStock.Value);
            }
        }

        private Warehouse GetWarehouse(string warehouseName)
        {
            var warehouse = _warehouses.FirstOrDefault(w => w.Name == warehouseName);
            if (warehouse == null)
            {
                warehouse = Warehouse.Build(warehouseName);
                _warehouses.Add(warehouse);
            }

            return warehouse;
        }
    }
}