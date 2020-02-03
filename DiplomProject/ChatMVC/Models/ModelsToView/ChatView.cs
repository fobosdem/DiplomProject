using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Models.ModelsToView
{
	public class ChatView
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		public string Name { get; set; }
		[HiddenInput(DisplayValue = false)]
		public List<MessageView> Messages { get; set; }
	}
}