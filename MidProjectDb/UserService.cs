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
            return userDataAccess.ValidateUser(username, password);
        }
        public User AuthenticateUserAndGetUser(string username, string password)
        {
            return userDataAccess.GetUserByCredentials(username, password);
        }

        public bool RegisterUser(User user)
        {
            return userDataAccess.InsertUser(user);
        }
    }
}
