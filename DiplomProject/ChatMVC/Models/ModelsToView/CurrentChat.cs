using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Models.ModelsToView
{
	public class CurrentChat
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		public List<MessageView> Messages{get; set;}
		public string NewMessage { get; set; }
	}
}