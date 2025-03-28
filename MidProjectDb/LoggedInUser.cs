using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public static class LoggedInUser
    {
        public static int UserId { get; private set; }
        public static int RoleId { get; private set; }
        public static int? FacultyId { get; private set; }

        public static void SetUser(int userId, int roleId, int? facultyId = null)
        {
            UserId = userId;
            RoleId = roleId;
            FacultyId = facultyId;
        }
    }
}
