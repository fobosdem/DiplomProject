using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLibrary.BLModels;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repository;
using FileAccessLibrary.WorkerkWithJsonAndFiles;
using FileAccessLibrary.Entities;
using AutoMapper;
using BLLibrary.Mapping;

namespace BLLibrary.Services
{
	// first test account:
	// Login: AdminTest@test.com
	// 2nd login: TestAdmin2@gmail.com
	// Password: Admin111/
	public class MainService
	{
		public UserRepository _userService;
		public ChatRepository _chatService;
		private readonly IMapper _mapper;


		public MainService()
		{
			_userService = new UserRepository();
			_chatService = new ChatRepository();
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new BlMapping())));

		}
		public void CreatingNewUser(string userName, string nickName = null)
		{
			Chat chat = new Chat() { Name = "Garbage", Users = new List<User>() };
			User user = new User() { Chats = new List<Chat>() };
			if (nickName == null)
			{
				user.Name = userName;
				user.NickName = userName;
			}
			else
			{
				user.Name = userName;
				user.NickName = nickName;
			}
			user.Chats.Add(chat);
			//creating new chat file on server for this chat
			_userService.Create(user);
		}
		public int CreateNewChatBetweenUsers(IList<string> userNames)
		{
			Chat newChat = new Chat() { Name = $"{String.Join(", ", userNames.ToArray())}", Users = new List<User>() };

			foreach (string user in userNames)
			{
				newChat.Users.Add(_userService.FindByName(user, false));
			}
			//creating new chat file on server for this chat
			int idChat = _chatService.Create(newChat);
			
			JsonWorker jsonWorker = new JsonWorker(idChat);
			return idChat;
		}
		public void SendMessage(string message, int chatId, string userName)
		{
			JsonWorker jsonWorker = new JsonWorker(chatId);
			jsonWorker.AddMessage(new Message() { Text = message, UserName = userName});
		}
		public List<MessageBl> GetAllMessagesByChat(int chatId)
		{
			JsonWorker jsonWorker = new JsonWorker(chatId);
			List<MessageBl> allMessages = _mapper.Map<List<MessageBl>>(jsonWorker.GetMessages());
			return allMessages;
		}
	}
}
