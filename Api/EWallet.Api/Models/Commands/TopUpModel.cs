﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models.Commands
{
	public class TopUpModel
	{
		public string RefNo { get; set; }
		public string SenderId { get; set; }
		public string Receive { get; set; }
	}
}
