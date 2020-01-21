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
        private readonly string _loginedUserName;

        public ChatsController()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MVCMapper())));
            _userService = new UserService();
            _chatService = new ChatService();
            _mainService = new MainService();
            _loginedUserName = User.Identity.Name;
        }
        // GET: Chats
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddChat()
        {
            List<User> usersList = _mapper.Map<List<User>>(_userService.Get(false).Where(u => u.Name != _loginedUserName));
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
    }
}