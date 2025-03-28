using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRequestService
    {
        private FacultyRequestDataAccess requestDataAccess = new FacultyRequestDataAccess();

        public bool SubmitRequest(FacultyRequest request)
        {
            return requestDataAccess.InsertRequest(request);
        }

        public List<FacultyRequest> GetRequestsForFaculty(int facultyId)
        {
            return requestDataAccess.GetRequestsByFaculty(facultyId);
        }
    }
}
