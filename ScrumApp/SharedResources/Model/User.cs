using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;

namespace SharedResources.Model
{
    public class User : ModelBase
    {

        #region Properties

        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                onPropertyChanged("UserName");
            }
        }

        private string _realName;
        public string RealName
        {
            get
            {
                return _realName;
            }
            set
            {
                _realName = value;
                onPropertyChanged("RealName");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                onPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                onPropertyChanged("Password");
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                onPropertyChanged("PhoneNumber");
            }
        }

        private PermissionLevel _accessLevel;
        public PermissionLevel AccessLevel
        {
            get
            {
                return _accessLevel;
            }
            set
            {
                _accessLevel = value;
                onPropertyChanged("AccessLevel");
            }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Checks whether the user object is properly filled out or not
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return (this.Email != null && this.Email.Length > 0 &&
                    this.Password != null && this.Password.Length > 0 &&
                    this.PhoneNumber != null && this.PhoneNumber.Length > 4 &&
                    this.RealName != null && this.RealName.Length > 0 &&
                    this.UserName != null && this.UserName.Length > 0);
        }

        #endregion
    }
}
