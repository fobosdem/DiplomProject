using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Models.ModelsToView
{
	public class MessageView
	{
		public string Text { get; set; }
		[HiddenInput(DisplayValue = false)]
		public string UserName { get; set; }
	}
}