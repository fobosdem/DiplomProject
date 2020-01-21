using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLibrary.BLModels;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repository;

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

		public MainService()
		{
			_userService = new UserRepository();
			_chatService = new ChatRepository();
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
		public void CreateNewChatBetweenUsers(IList<string> userNames)
		{
			Chat newChat = new Chat() { Name = $"{String.Join(", ", userNames.ToArray())}", Users = new List<User>() };

			foreach (string user in userNames)
			{
				newChat.Users.Add(_userService.FindByName(user, false));
			}
			//creating new chat file on server for this chat
			_chatService.Create(newChat);
		}
	}
}
