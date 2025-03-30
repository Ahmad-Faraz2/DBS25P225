using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class FacultyCourseAssignment
    {
        public int FacultyCourseId { get; set; }
        public int FacultyId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int SemesterId { get; set; }
        public string DisplayTerm { get; set; }
    }
}
