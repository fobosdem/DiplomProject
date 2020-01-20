using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLibrary.BLModels;

namespace BLLibrary.Services
{
	// first test account:
	// Login: AdminTest@test.com
	// Password: Admin111/
	public class MainService
	{
		public UserService _userService;
		public ChatService _chatService;

		public MainService()
		{
			_userService = new UserService();
			_chatService = new ChatService();
		}
		public void CreatingNewUser(string userName, string nickName = null)
		{
			ChatBL chat = new ChatBL() { Name = userName, Users = new List<UserBL>() };
			UserBL user = new UserBL() { Chats = new List<ChatBL>() };
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
			ChatBL newChat = new ChatBL() { Name = $"{String.Join(", ", userNames.ToArray())}", Users = new List<UserBL>() };
			foreach (string user in userNames)
			{
				newChat.Users.Add(_userService.GetUserByName(user));
			}
			//creating new chat file on server for this chat
			_chatService.Create(newChat);
		}
	}
}
