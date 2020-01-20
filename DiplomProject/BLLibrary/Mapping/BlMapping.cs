﻿using AutoMapper;
using BLLibrary.BLModels;
using DataBaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLibrary.Mapping
{
	public class BlMapping : Profile
	{
		public BlMapping()
		{
			CreateMap<UserBL, User>().ReverseMap();
			CreateMap<ChatBL, Chat>().ReverseMap();
		}
	}
}