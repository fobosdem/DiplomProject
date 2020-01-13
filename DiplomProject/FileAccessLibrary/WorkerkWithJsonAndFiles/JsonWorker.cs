using FileAccessLibrary.Entities;
using System.IO;

namespace FileAccessLibrary.WorkerkWithJsonAndFiles
{
	public class JsonWorker
	{
		public Chat Chat { get; set; }

		public JsonWorker(Chat chat)
		{
			Chat = chat;
		}

		public void Create(Chat chat)
		{
			
		}
		public void AddMessage(Message newMessage)
		{
			this.Chat.Messages.Add(newMessage);
			//should add save to json
		}
		public void DeleteMessage(Message newMessage)
		{

		}
		public void UpdateMessage(Message newMessage)
		{

		}

	}
}
