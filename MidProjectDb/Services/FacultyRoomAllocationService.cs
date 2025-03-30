using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRoomAllocationService
    {
        private FacultyRoomAllocationDataAccess dataAccess = new FacultyRoomAllocationDataAccess();

        public bool AssignRoom(FacultyRoomAllocation allocation)
        {
            return dataAccess.InsertAllocation(allocation);
        }

        public List<FacultyRoomAllocation> GetAllAllocations()
        {
            return dataAccess.GetAllAllocations();
        }
    }
}
