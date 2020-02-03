using FileAccessLibrary.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileAccessLibrary.WorkerkWithJsonAndFiles
{
	public class JsonWorker
	{
		private int _chatId { get; set; }
		//private StreamWriter _fileStream;

		public JsonWorker(int chatId)
		{
			//_fileStream = new StreamWriter($@"C:\TestDir\{chatId}.txt", false, System.Text.Encoding.Default);
			//JObject obj = new JObject(
			//	new JProperty("Id", $@"{chat.Id}"),
			//	new JProperty("Messages", new JArray())
			//	);
			//SaveToFile(obj.ToString(Newtonsoft.Json.Formatting.None));
			_chatId = chatId;
			if (!File.Exists($@"C:\TestDir\{chatId}.txt"))
			{
				Create(new JsonChat() { Id = chatId, Messages = new List<Message>() });
			}
		}

		public void Create(JsonChat chat)
		{
			JObject obj = CreateJson(chat);
			SaveToFile(obj.ToString(Formatting.None));
		}
		public List<Message> GetMessages()
		{
			string date = ReadFromFile();

			JsonChat jsonChat = JsonConvert.DeserializeObject<JsonChat>(date);

			return jsonChat.Messages;
		}
		public void AddMessage(Message newMessage)
		{
			string date = ReadFromFile();
			JsonChat jsonChat = JsonConvert.DeserializeObject<JsonChat>(date);
			jsonChat.Messages.Add(newMessage);
			JObject obj = CreateJson(jsonChat);
			SaveToFile(obj.ToString(Formatting.None));
		}
		public void DeleteMessage(Message newMessage)
		{

		}
		public void UpdateMessage(Message newMessage)
		{

		}

		private void SaveToFile (string dataasstring)
		{
			using (StreamWriter file = new StreamWriter($@"C:\TestDir\{_chatId}.txt", false, System.Text.Encoding.Default))
			{
				file.WriteLine(dataasstring);
			};
		}
		private string ReadFromFile()
		{
			using (StreamReader file = new StreamReader($@"C:\TestDir\{_chatId}.txt", System.Text.Encoding.Default))
			{
				return file.ReadLine();
			};
		}
		private JObject CreateJson(JsonChat chat)
		{
			JArray messages = new JArray();
			//chat.Messages.Add(new Message() {Text = "asdfasdfasd", UserName = "USERNAME" });
			//chat.Messages.Add(new Message() {Text = "MESSAGE 2", UserName = "USERNAME 2" });

			chat.Messages.ForEach(m => messages.Add(new JObject(
				//new JProperty("Id", $@"{m.Id}"),
				new JProperty("UserName", $@"{m.UserName}"),
				new JProperty("Text", $@"{m.Text}")
				)));
			JObject obj = new JObject(
				new JProperty("Id", $@"{chat.Id}"),
				new JProperty("Messages", messages
				));

			return obj;
		}
	}
}
