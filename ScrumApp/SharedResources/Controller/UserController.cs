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
                if (user != null)
                {
                    DataStructure.CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Attempts to register a user. Returns whether or not the user name was registered. 
        /// The only possibility for this to return false is if the username is already registered.
        /// </summary>
        /// <param name="user">The user object to register</param>
        /// <exception cref="ArgumentException">The User-object was not valid</exception>
        public bool RegisterUser(User user)
        {
            if (user.IsValid())
            {
                // Checks if the username is taken
                if (DataStructure.Users.Where(u => u.UserName == user.UserName).First() != null)
                {
                    return false;
                }
                else
                {
                    DataStructure.Users.Add(user);
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("User-object is not valid.");
            }
        }

        /// <summary>
        /// Attempts to remove a user. Looks the user up, and deletes it (if present).
        /// </summary>
        /// <param name="user">The user to delete</param>
        /// <param name="username">The username of the user to delete</param>
        public void RemoveUser(User user = null, string username = null)
        {
            if (user == null && username == null) return;

            if (user != null)
            {
                DataStructure.Users.Remove(user);
            }
            else if (username != null)
            {
                User tmpUser = DataStructure.Users.Find(u => u.UserName == username);
                if (tmpUser != null)
                {
                    DataStructure.Users.Remove(tmpUser);
                }
            }
        }

        /// <summary>
        /// Attempts to update a user.
        /// </summary>
        /// <param name="userToUpdate">The username of the User-object to update.</param>
        /// <param name="user">The updated User-object</param>
        /// <returns>True if user was found, otherwise false</returns>
        public bool UpdateUser(string userToUpdate, User user)
        {
            if (userToUpdate == null || user == null || !user.IsValid())
            {
                return false;
            }

            var tmpUser = DataStructure.Users.Find(u => u.UserName == userToUpdate);

            if (tmpUser != null)
            {
                DataStructure.Users.Remove(tmpUser);
                DataStructure.Users.Add(user);
                return true;
            }
            return false;    
        }
    }
}
