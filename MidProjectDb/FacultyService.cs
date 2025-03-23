using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyService
    {
        private FacultyDataAccess facultyDataAccess = new FacultyDataAccess();

        public List<Faculty> GetAllFaculty()
        {
            return facultyDataAccess.GetAllFaculty();
        }

        public bool SaveFaculty(Faculty faculty)
        {
            return facultyDataAccess.InsertFaculty(faculty);
        }

        public bool UpdateFaculty(Faculty faculty)
        {
            return facultyDataAccess.UpdateFaculty(faculty);
        }

        public bool DeleteFaculty(int facultyId)
        {
            return facultyDataAccess.DeleteFaculty(facultyId);
        }
    }
}
