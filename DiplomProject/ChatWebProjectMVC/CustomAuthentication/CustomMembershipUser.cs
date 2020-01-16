using ChatWebProjectMVC.AuthenticationDBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ChatWebProjectMVC.CustomAuthentication
{
	public class CustomMembershipUser : MembershipUser
    {
        #region User Properties  

        public int UserId { get; set; }
        public string NickName { get; set; }

        #endregion

        public CustomMembershipUser(User user) : base("CustomMembership", user.UserName, user.UserId, user.NickName, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.UserId;
            NickName = user.NickName;
        }
    }
}