using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatMVC.Controllers
{
    public class ChatsController : Controller
    {
        // GET: Chats
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddChat()
        {

            return View();
        }
    }
}