using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class ConsumableService
    {
        private ConsumableDataAccess dataAccess = new ConsumableDataAccess();

        public List<Consumable> GetAllConsumables()
        {
            return dataAccess.GetAllConsumables();
        }

        public bool InsertConsumable(Consumable consumable)
        {
            return dataAccess.InsertConsumable(consumable);
        }

        public bool UpdateConsumable(Consumable consumable)
        {
            return dataAccess.UpdateConsumable(consumable);
        }

        public bool DeleteConsumable(int consumableId)
        {
            return dataAccess.DeleteConsumable(consumableId);
        }
    }
}
