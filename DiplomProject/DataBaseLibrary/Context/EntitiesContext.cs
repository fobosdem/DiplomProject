using DataBaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Context
{
	public class EntitiesContext : DbContext
	{
		public DbSet<Chat> Chats { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
