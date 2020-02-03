using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models.ModelsToView
{
	public class User
	{

		public string Name { get; set; }
		public string NickName { get; set; }
		public List<ChatView> Chats { get; set; }
	}
}