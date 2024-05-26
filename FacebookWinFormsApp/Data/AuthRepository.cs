﻿using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Data
{
    internal class AuthRepository
    {
        public static LoginResult LoginResult { get; set; }
        private long AppId { get; set; }    
        private string[] RequiredPermissions { get; set; }


        private string AccessToken { get; set; }


        public AuthRepository(long i_appId, string[] i_requiredPermissions)
        {
            AppId = i_appId;
            RequiredPermissions = i_requiredPermissions;
        }

        public static void Login()
        {
            //ahushluki       
            LoginResult = FacebookWrapper.FacebookService.Connect("EAAMsl7nPw7gBO2Nij36I44LTHQBpXTBKDf8ZAhMMWU8fcMAbdZB81FEZCMmMZA7kc0w3NIkEBrOnS4jM9furY5NgM63VDCHOeGDdXnaOfLx2W9pYkOLzXyU7nDTjU1wan0lqm6yoPLLoJDsbn4l2yiZBOVN2ZCn8FojO1vF8rY9l9rI1ZCAc3IuqUbTngZDZD");
            //amit
            //LoginResult = FacebookWrapper.FacebookService.Connect("EAAMsl7nPw7gBO4jpM9PU96CpuZCZCbI5RGJZCzOYXZAsBADCKUjnPSsZCPR7h3fLqnG0zdAfke8ACQAKaJVx4jg7QEGtbPDCqRzdgvxcgnlEGWYo29OUfJAVEslGadzpuZC9Po5ITbwPtsqZBWJUs4YWAOgiMvIyp9zSADjb6f90ZB3rB1vYygj9D4TIVAZDZD");
            //LoginResult = FacebookWrapper.FacebookService.Login(m_AppId.ToString(), m_RequiredPermissions);    
        }

        public static void Logout()
        {
            LoginResult = null;          
        }
    }
}