using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccessLibrary.Entities
{
	public class Chat
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreatorNick { get; set; }
		public IList<Message> Messages { get; set; }
	}
}
