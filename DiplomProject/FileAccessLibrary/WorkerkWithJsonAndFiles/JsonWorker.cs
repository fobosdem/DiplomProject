using FileAccessLibrary.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccessLibrary.WorkerkWithJsonAndFiles
{
	public  class JsonWorker
	{
		private FileStream fileStream;

		public JsonWorker(Chat chat)
		{
			fileStream = new FileStream($@"{chat.Id}\chat.json", FileMode.OpenOrCreate);
		}

		public void Create(Chat chat)
		{
			
		}
		public void AddMessage(Message newMessage)
		{

		}
		public void DeleteMessage(Message newMessage)
		{

		}
		public void UpdateMessage(Message newMessage)
		{

		}

	}
}
