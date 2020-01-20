﻿using DataBaseLibrary.Context;
using DataBaseLibrary.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DataBaseLibrary.Repository
{
    class UserRepository
    {
        EntitiesContext _context;

        public UserRepository()
        {
            _context = new EntitiesContext();
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }
        public User FindByName(string name)
        {
            return _context.Users.Include(u => u.Chats).First(u => u.Name == name);
        }
        public IList<User> Get(bool includes)
        {
            if (includes)
            {
                return _context.Users.Include(u => u.Chats).ToList();
            }
            else
            {
                return _context.Users.ToList();
            }
        }
        public void Remove(int id)
        {
            var user = FindById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Update()
        {

        }
    }
}
