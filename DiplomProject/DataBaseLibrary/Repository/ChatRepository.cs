using DataBaseLibrary.Context;
using DataBaseLibrary.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLibrary.Repository
{
	public class ChatRepository
	{
		EntitiesContext _context;

		public ChatRepository()
		{
			_context = new EntitiesContext();
		}
		public void Create(Chat chat)
		{
			List<User> usersUpdate = new List<User>();
			foreach(var userFromBL in chat.Users)
			{
				usersUpdate.Add(_context.Users.Find(userFromBL.Id));
			}
			chat.Users = usersUpdate;
			_context.Chats.Add(chat);
			_context.SaveChanges();
		}
		public Chat FindById(int id, bool includes)
		{
			if (includes)
			{
				return _context.Chats.Include(c => c.Users).First(c => c.Id == id);
			}
			else
			{
				return _context.Chats.Find(id);
			}
		}
		public Chat FindByName(string name)
		{
			return _context.Chats.Include(c => c.Users).First(c => c.Name == name);
		}

		public IList<Chat> GetAll(bool includes)
		{
			if (includes)
			{
				return _context.Chats.Include(c => c.Users).ToList();
			}
			else
			{
				return _context.Chats.ToList();
			}
		}
		public void Remove(int id)
		{
			var chat = FindById(id, false);
			_context.Chats.Remove(chat);
			_context.SaveChanges();
		}
		public void Update()
		{

		}
	}
}
