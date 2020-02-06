using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Models.ModelsToView
{
	public class MessagesPlusChatView
	{
		public CurrentChat currentChat { get; set; }
		public List<ChatView> chatViews { get; set; }
	}
}