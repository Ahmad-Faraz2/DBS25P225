using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class Consumable
    {
        public int ConsumableId { get; set; } 
        public string ItemName { get; set; }

        public override string ToString() => ItemName;
    }
}
