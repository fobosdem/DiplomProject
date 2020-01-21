using AutoMapper;
using BLLibrary.BLModels;
using ChatMVC.Models.ModelsToView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatMVC.Mapping
{
	public class MVCMapper : Profile
	{
		public MVCMapper()
		{
			CreateMap<User, UserBL>().ReverseMap();
			//CreateMap<ChatBL, Chat>().ReverseMap();
		}
	}
}