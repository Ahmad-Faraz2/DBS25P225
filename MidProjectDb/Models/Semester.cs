using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    class Semester
    {
        public int SemesterId { get; set; }
        public string Term { get; set; }
        public int Year { get; set; }
        public string DisplayTerm => $"{Term} {Year}";
    }
}
