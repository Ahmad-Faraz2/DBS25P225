using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class CourseAssignmentService
    {
        private CourseAssignmentDataAccess dataAccess = new CourseAssignmentDataAccess();

        public bool AssignCourse(FacultyCourseAssignment assignment)
        {
            return dataAccess.InsertAssignment(assignment);
        }

        public bool UpdateAssignment(FacultyCourseAssignment assignment)
        {
            return dataAccess.UpdateAssignment(assignment);
        }

        public List<FacultyCourseAssignment> GetAllAssignments()
        {
            return dataAccess.GetAllAssignments();
        }
        public List<FacultyCourseAssignment> GetAssignmentsForFaculty(int facultyId)
        {
            List<FacultyCourseAssignment> allAssignments = dataAccess.GetAllAssignments();
            return allAssignments.Where(a => a.FacultyId == facultyId).ToList();
        }
    }
}
