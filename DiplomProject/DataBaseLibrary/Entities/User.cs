using System.Collections.Generic;

namespace DataBaseLibrary.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string NickName { get; set; }
		public IList<Chat> Chats { get; set; }
	}
}
