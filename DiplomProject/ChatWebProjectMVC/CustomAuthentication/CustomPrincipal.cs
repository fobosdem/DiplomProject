using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ChatWebProjectMVC.CustomAuthentication
{
	public class CustomPrincipal : IPrincipal
    {
        #region Identity Properties  

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        #endregion

        public IIdentity Identity
        {
            get; private set;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

    }
}