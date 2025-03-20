using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MidProjectDb
{
    public class UserService
    {
        private UserDataAccess userDataAccess = new UserDataAccess();

        public bool AuthenticateUser(string username, string password)
        {
            // Here you could add additional business logic if necessary
            return userDataAccess.ValidateUser(username, password);
        }
    }
}
