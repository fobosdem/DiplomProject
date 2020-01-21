using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLibrary.BLModels;
using DataBaseLibrary.Repository;
using BLLibrary.Mapping;
using AutoMapper;
using DataBaseLibrary.Entities;

namespace BLLibrary.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepository;
		private readonly IMapper _mapper;
		public UserService()
		{
			_userRepository = new UserRepository();
			_mapper = new Mapper (new MapperConfiguration(cfg => cfg.AddProfile(new BlMapping())));
		}
		public void Create(UserBL user)
		{
			_userRepository.Create(Map(user));
		}
		public UserBL GetUserByName(string name, bool includeChats)
		{
			return Map(_userRepository.FindByName(name, includeChats));
		}
		public IList<UserBL> Get(bool includes)
		{
			var users = Map(_userRepository.Get(includes).ToList());
			return users;
		}
		internal UserBL Map(User user)
		{
			return _mapper.Map<UserBL>(user);
		}
		internal User Map(UserBL user)
		{
			return _mapper.Map<User>(user);

		}
		internal List<UserBL> Map(List<User> users)
		{
			return _mapper.Map<List<UserBL>>(users);
		}
		internal List<User> Map(List<UserBL> users)
		{
			return _mapper.Map<List<User>>(users);
		}
	}
}
