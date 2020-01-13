namespace FileAccessLibrary.Entities
{
	public class Message
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; }
		
		//override equals for deleting messages
		//public override bool Equals(object obj)
		//{
		//	return base.Equals(obj);
		//}
	}
}
