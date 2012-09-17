using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using SharedResources.Utilities;
using SharedResources.Model;

namespace SharedResources.Controller
{
    public class UserController
    {
        /// <summary>
        /// Logs in a user and returns whether or not a user was successfully logged in
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <param name="password">The user's password (not encrypted)</param>
        public bool Login(string username, string password)
        {
            if (DataStructure.Users != null && DataStructure.Users.Count > 0)
            {
                // TODO: Add MD5 hashing to login routine.
                var user = DataStructure.Users.Where(u => u.UserName == username && u.Password == u.Password).First();

            }

            return false;
        }

        /// <summary>
        /// Attempts to register a user. Returns whether or not the user was registered.
        /// If a user was not registered, there can be two reasons:
        /// - The username is already taken
        /// </summary>
        /// <param name="user">The user object to register</param>
        /// <exception cref="ArgumentException">The User-object was not valid</exception>
        public bool RegisterUser(User user)
        {

            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        private bool isValid(User user)
        {
            throw new NotImplementedException();
        }
    }
}
