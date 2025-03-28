using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class CourseService
    {
        private CourseDataAccess courseDataAccess = new CourseDataAccess();

        public List<Course> GetAllCourses()
        {
            return courseDataAccess.GetAllCourses();
        }
    }
}
