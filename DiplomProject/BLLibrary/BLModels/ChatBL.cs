﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLibrary.BLModels
{
	public class ChatBL
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<UserBL> Users { get; set; }
	}
}
