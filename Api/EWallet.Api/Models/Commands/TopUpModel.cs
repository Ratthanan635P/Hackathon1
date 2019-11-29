using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models.Commands
{
	public class TopUpModel
	{
		public double Money { get; set;}
		public string AgrentId {get;set;}
	}
}
