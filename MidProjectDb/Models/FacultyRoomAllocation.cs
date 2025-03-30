using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRoomAllocation
    {
        public int AllocationId { get; set; }
        public int FacultyId { get; set; }
        public int RoomId { get; set; }
        public int ReservedHours { get; set; }
        public int SemesterId { get; set; }

        public string RoomName { get; set; }
    }
}
