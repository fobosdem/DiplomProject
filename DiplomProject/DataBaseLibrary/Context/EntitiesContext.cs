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
		public EntitiesContext() : base("server=DESKTOP-R04KCA7;Initial Catalog=ChatProject;Integrated Security=True")
		{

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
						.HasMany(u => u.Chats)
						.WithMany(r => r.Users);
		}
		public DbSet<Chat> Chats { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
