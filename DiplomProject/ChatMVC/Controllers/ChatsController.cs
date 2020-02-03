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
		private int _currentChatId { get; set; }
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
			List<User> usersList = _mapper.Map<List<User>>(_userService.Get(false).Where(u => u.Name != User.Identity.Name));
			return View(usersList);
		}
		[HttpPost]
		public ActionResult AddChat(FormCollection form)
		{
			string name1 = form["Users"].ToString();
			List<string> users = new List<string>() { name1, User.Identity.Name.ToString() };
			_mainService.CreateNewChatBetweenUsers(users);
			return Redirect("addchat");
		}
		[HttpGet]
		public ActionResult ChatsList()
		{
			User user = _mapper.Map<User>(_userService.Get(true).First(u => u.Name == User.Identity.Name));
			return View(user.Chats);
		}
		[HttpGet]
		public ActionResult ChatWithUser(int id)
		{
			_currentChatId = id;
			List<MessageView> messages = _mapper.Map<List<MessageView>>(_mainService.GetAllMessagesByChat(id));
			CurrentChat currentChat = new CurrentChat() { Id = id, Messages = messages, NewMessage = "" };
			return View(currentChat);
		}
		[HttpPost]
		public ActionResult ChatWithUser(CurrentChat currentChat)
		{
			_mainService.SendMessage(currentChat.NewMessage, currentChat.Id, User.Identity.Name);
			List<MessageView> messages = _mapper.Map<List<MessageView>>(_mainService.GetAllMessagesByChat(currentChat.Id));
			currentChat.Messages = messages;
			//return Redirect($@"ChatWithUser/{currentChat.Id}");
			currentChat.NewMessage = "";
			return View(currentChat);
		}
		//public ActionResult SendMessage(string newMessage)
		//{
		//	_mainService.SendMessage(newMessage, _currentChatId, User.Identity.Name);
		//	return View("ChatWithUser");
		//}
	}
}