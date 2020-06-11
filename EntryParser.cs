using System.Collections.Generic;
using System.Linq;

namespace MaterialInventoryImport
{
    internal class EntryParser : IEntryParser
    {
        public EntryInfoDto Parse(string inputLine)
        {
            var parts = inputLine.Split(';');

            return new EntryInfoDto()
            {
                MaterialName = parts[0],
                MaterialId = parts[1],
                WarehouseStock = GetWarehousesStock(parts[2])
            };
        }

        private Dictionary<string, int> GetWarehousesStock(string warehousesStockInput)
        {
            var warehouses = warehousesStockInput.Split('|');
            return warehouses
                .Select(wi => wi.Split(','))
                .ToDictionary(k => k[0], v => int.Parse(v[1]));
        }
    }
}