﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLibrary.BLModels
{
	public class UserBL
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string NickName { get; set; }
		public IList<ChatBL> Chats { get; set; }
	}
}