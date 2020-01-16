using ChatWebProjectMVC.AuthenticationDBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWebProjectMVC.CustomAuthentication
{
	public class CustomSerializeModel
	{
		public int UserId { get; set; }
		public string NickName { get; set; }
	}
}