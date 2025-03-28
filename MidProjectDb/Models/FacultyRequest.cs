using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRequest
    {
        public int RequestId { get; set; }
        public int FacultyId { get; set; } 
        public int ItemId { get; set; }   
        public int Quantity { get; set; }     
        public int StatusId { get; set; }    
        public System.DateTime RequestDate { get; set; } 
    }
}
