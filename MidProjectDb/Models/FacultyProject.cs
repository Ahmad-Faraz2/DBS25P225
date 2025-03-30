using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class FacultyProject
    {
        public int FacultyProjectId { get; set; }
        public int FacultyId { get; set; }
        public int ProjectId { get; set; }
        public int SemesterId { get; set; }
        public int SupervisionHours { get; set; }

        public string ProjectTitle { get; set; }
        public string DisplayTerm { get; set; }
    }
}
