using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWebProjectMVC.AuthenticationDBModels
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}