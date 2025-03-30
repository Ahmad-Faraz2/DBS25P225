using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyRequestService
    {
        private FacultyRequestDataAccess dataAccess = new FacultyRequestDataAccess();

        public bool SubmitRequest(FacultyRequest request)
        {
            return dataAccess.InsertRequest(request);
        }

        public List<FacultyRequest> GetRequestsForFaculty(int facultyId)
        {
            return dataAccess.GetRequestsForFaculty(facultyId);
        }
        public bool UpdateRequestStatus(int requestId, int newStatusId)
        {
            return dataAccess.UpdateRequestStatus(requestId, newStatusId);
        }
        public List<FacultyRequest> GetAllRequests()
        {
            return dataAccess.GetAllRequests();
        }
    }
}
