using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models.Commands
{
	public class TransationsModel
	{
		public double Money { get; set;}
		public string SenderId {get;set;}
		public string Receive { get; set; }
	}
}
