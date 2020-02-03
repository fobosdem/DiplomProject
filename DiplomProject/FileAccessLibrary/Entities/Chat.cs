using System;
using System.Collections.Generic;

namespace FileAccessLibrary.Entities
{
	public class JsonChat
	{
		public int Id { get; set; }
		public List<Message> Messages { get; set; }
	}
}
