using AutoMapper;
using BLLibrary.BLModels;
using BLLibrary.Mapping;
using DataBaseLibrary.Entities;
using DataBaseLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLibrary.Services
{
	public class ChatService
	{
		private readonly ChatRepository _chatRepository;
		private readonly IMapper _mapper;
		public ChatService()
		{
			_chatRepository = new ChatRepository();
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new BlMapping())));
		}
		public void Create(ChatBL chat)
		{
			_chatRepository.Create(Map(chat));
		}
		public List<ChatBL> GetAll()
		{
			return Map(_chatRepository.GetAll(false).ToList());
		}

		internal ChatBL Map(Chat chat)
		{
			return _mapper.Map<ChatBL>(chat);
		}
		internal Chat Map(ChatBL chat)
		{
			return _mapper.Map<Chat>(chat);

		}
		internal List<ChatBL> Map(List<Chat> chat)
		{
			return _mapper.Map<List<ChatBL>>(chat);
		}
		internal List<Chat> Map(List<ChatBL> chat)
		{
			return _mapper.Map<List<Chat>>(chat);

		}
	}
}
