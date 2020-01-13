using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccessLibrary.Entities
{
	public class Message
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; }
	}
}
