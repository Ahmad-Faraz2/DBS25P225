using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class SemesterService
    {
        private SemesterDataAccess semesterDataAccess = new SemesterDataAccess();

        public List<Semester> GetAllSemesters()
        {
            return semesterDataAccess.GetAllSemesters();
        }
    }
}
