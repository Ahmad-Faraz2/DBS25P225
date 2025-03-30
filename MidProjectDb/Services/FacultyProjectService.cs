using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class FacultyProjectService
    {
        private FacultyProjectDataAccess dataAccess = new FacultyProjectDataAccess();

        public bool AssignProject(FacultyProject project)
        {
            return dataAccess.InsertFacultyProject(project);
        }

        public List<FacultyProject> GetAllProjects()
        {
            return dataAccess.GetAllFacultyProjects();
        }
        public List<FacultyProject> GetProjectsForFaculty(int facultyId)
        {
            List<FacultyProject> allProjects = GetAllProjects();
            return allProjects.Where(p => p.FacultyId == facultyId).ToList();
        }
    }
}
