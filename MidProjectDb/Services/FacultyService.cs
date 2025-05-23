﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidProjectDb
{
    public class FacultyService
    {
        private FacultyDataAccess facultyDataAccess = new FacultyDataAccess();

        public List<Faculty> GetAllFaculty()
        {
            return facultyDataAccess.GetAllFaculty();
        }

        public bool SaveFaculty(Faculty faculty)
        {
            return facultyDataAccess.InsertFaculty(faculty);
        }

        public bool UpdateFaculty(Faculty faculty)
        {
            return facultyDataAccess.UpdateFaculty(faculty);
        }

        public bool DeleteFaculty(int facultyId)
        {
            return facultyDataAccess.DeleteFaculty(facultyId);
        }
        public Faculty GetFacultyById(int facultyId)
        {
            return facultyDataAccess.GetFacultyById(facultyId);
        }
        public bool LinkFacultyRecord(string email, int userId)
        {
            return facultyDataAccess.UpdateFacultyUserIdByEmail(email, userId);
        }

        public Faculty GetFacultyByEmail(string email)
        {
            return facultyDataAccess.GetFacultyByEmail(email);
        }
    }
}
