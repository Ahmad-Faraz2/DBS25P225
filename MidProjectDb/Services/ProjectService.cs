using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class ProjectService
    {
        private ProjectDataAccess dataAccess = new ProjectDataAccess();

        public List<Project> GetAllProjects()
        {
            return dataAccess.GetAllProjects();
        }
    }
}
