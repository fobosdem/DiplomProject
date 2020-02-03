using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLibrary.Entities
{
	public class User
	{
		public int Id { get; set; }
		[StringLength(450)]
		[Index(IsUnique = true)]
		public string Name { get; set; }
		public string NickName { get; set; }
		public IList<Chat> Chats { get; set; }
		public User()
		{
			Chats = new List<Chat>();
		}
	}
}
