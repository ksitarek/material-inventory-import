using System.Collections.Generic;

namespace MaterialInventoryImport
{
    internal class EntryInfoDto
    {
        public string MaterialName { get; set; }
        public string MaterialId { get; set; }
        public Dictionary<string, int> WarehouseStock = new Dictionary<string, int>();
    }
}