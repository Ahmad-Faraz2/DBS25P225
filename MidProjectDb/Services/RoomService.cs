using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class RoomService
    {
        private RoomDataAccess dataAccess = new RoomDataAccess();

        public List<Room> GetAllRooms()
        {
            return dataAccess.GetAllRooms();
        }
    }
}
