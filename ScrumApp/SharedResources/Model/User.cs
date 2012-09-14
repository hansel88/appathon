﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Model
{
    public class User : ModelBase
    {
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
                return " " + _realName;
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
    }
}
