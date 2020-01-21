using System.Collections.Generic;

namespace DataBaseLibrary.Entities
{
	public class Chat
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<User> Users { get; set; }
		public Chat()
		{
			Users = new List<User>();
		}
	}
}
