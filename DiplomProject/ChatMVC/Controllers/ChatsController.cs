using AutoMapper;
using BLLibrary.Services;
using ChatMVC.Mapping;
using ChatMVC.Models.ModelsToView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Controllers
{
	[Authorize]
	public class ChatsController : Controller
	{
		private readonly IMapper _mapper;
		private readonly UserService _userService;
		private readonly ChatService _chatService;
		private readonly MainService _mainService;
		//private readonly string _loginedUserName;

		public ChatsController()
		{
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MVCMapper())));
			_userService = new UserService();
			_chatService = new ChatService();
			_mainService = new MainService();
			// _loginedUserName = User.Identity.Name;
		}
		// GET: Chats
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public ActionResult AddChat()
		{
			List<User> usersList = _mapper.Map<List<User>>(_userService.Get(true).Where(u => u.Name != User.Identity.Name));
			List<User> users = new List<User>();
			foreach (var user in usersList)
			{
				if (!user.Chats.Any(c => c.Name.Contains(User.Identity.Name)))
				{
					users.Add(user);
				}
			}
			return View(users);
		}
		[HttpPost]
		public ActionResult AddChat(FormCollection form)
		{
			if (form["Users"].Any())
			{
				string name1 = form["Users"].ToString();
				List<ChatView> UserChats = _mapper.Map<User>(_userService.Get(true).First(u => u.Name == User.Identity.Name)).Chats;
				foreach (var chat in UserChats)
				{
					if (chat.Name.Contains(name1))
					{
						return Redirect("addchat");
					}
				}
				List<string> users = new List<string>() { name1, User.Identity.Name.ToString() };
				_mainService.CreateNewChatBetweenUsers(users);
			}
			return Redirect("ChatWithUser");
		}
		[HttpGet]
		public ActionResult ChatsList()
		{
			User user = _mapper.Map<User>(_userService.Get(true).First(u => u.Name == User.Identity.Name));
			return View(user.Chats);
		}
		[HttpGet]
		public ActionResult ChatWithUser(int id = 0)
		{
			CurrentChat currentChat = null;
			if (id != 0)
			{
				List<MessageView> messages = _mapper.Map<List<MessageView>>(_mainService.GetAllMessagesByChat(id));
				currentChat = new CurrentChat() { Id = id, Messages = messages, NewMessage = "" };
			}

			ViewBag.Text = User.Identity.Name;

			List<ChatView> chatsToView = _mapper.Map<User>(_userService.Get(true).First(u => u.Name == User.Identity.Name)).Chats;

			for (int i = 0; i < chatsToView.Count(); i++)
			{
				if (chatsToView[i].Name == User.Identity.Name)
				{
					chatsToView[i].Name = "Избранное";
				}
				else
				{
					chatsToView[i].Name = chatsToView[i].Name.Split(',').First(name => !name.Contains(User.Identity.Name)).Trim().Split('@').First();
				}

			}

			MessagesPlusChatView messagesPlusChatView = new MessagesPlusChatView() { currentChat = currentChat, chatViews = chatsToView };

			return View(messagesPlusChatView);
		}
		[HttpPost]
		public ActionResult ChatWithUser(int id, string message)
		{
			_mainService.SendMessage(message, id, User.Identity.Name);

			return ChatWithUser(id);
		}
		//public ActionResult SendMessage(string newMessage)
		//{
		//	_mainService.SendMessage(newMessage, _currentChatId, User.Identity.Name);
		//	return View("ChatWithUser");
		//}
	}
}