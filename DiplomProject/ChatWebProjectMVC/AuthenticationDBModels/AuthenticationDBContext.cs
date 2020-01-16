using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatWebProjectMVC.AuthenticationDBModels
{
    public class AuthenticationDBContext : DbContext
    {
        public AuthenticationDBContext()
           : base("DBLoginConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
                //.HasMany(u => u.Chats)
                //.WithMany(r => r.Users)
                //.Map(m =>
                //{
                //    m.ToTable("UserChats");
                //    m.MapLeftKey("UserId");
                //    m.MapRightKey("ChatId");
                //})
        }

        public DbSet<User> Users { get; set; }
    }
}