using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class ConsumableService
    {
        public List<Consumable> GetAllConsumables()
        {
            return new List<Consumable>
            {
                new Consumable { ConsumableId = 1, ItemName = "Board Markers" },
                new Consumable { ConsumableId = 2, ItemName = "Stationery" },
                new Consumable { ConsumableId = 3, ItemName = "Consumables" },
                new Consumable { ConsumableId = 4, ItemName = "Lab Space" }
            };
        }
    }
}
