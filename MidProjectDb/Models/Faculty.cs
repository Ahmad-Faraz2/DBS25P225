using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int? DesignationId { get; set; }
        public string ResearchInterests { get; set; }
        public int? TotalTeachingHours { get; set; }
        public int? UserId { get; set; }
    }
}
