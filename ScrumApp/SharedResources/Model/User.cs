using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedResources.Utilities;
using System.Runtime.Serialization;

namespace SharedResources.Model
{
    [DataContract]
    public class User : ModelBase
    {
        #region Properties
 
        private string _userName;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
                onPropertyChanged("GravatarImageUrl");
            }
        }

        private string _password;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        public string GravatarImageUrl
        {
            get
            {
                return "http://www.gravatar.com/avatar/" + MiscUtility.ComputeMD5(this._email) + "?s=250";
            }
        }

        public string PermissionLevelString
        {
            get
            {
                switch (AccessLevel)
                {
                    case PermissionLevel.AdminOnly: return "Administrator";
                        
                    case PermissionLevel.Open: return "Open";
                        
                    default: return "User";
                        
                }
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
