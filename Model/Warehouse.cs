using System.Collections.Generic;

namespace MaterialInventoryImport.Model
{
    public class Warehouse
    {
        public string Name { get; private set; }

        public int Total { get; private set; }

        public IReadOnlyDictionary<Material, int> MaterialStock => _stock;

        private Dictionary<Material, int> _stock = new Dictionary<Material, int>();

        public void AddMaterial(Material material, int amount)
        {
            _stock.Add(material, amount);
            Total += amount;
        }

        public static Warehouse Build(string name) => new Warehouse() { Name = name };
    }
}