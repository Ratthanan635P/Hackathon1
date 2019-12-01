using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models
{
	public class DataAgrentModel
	{
		public int Id { get; set; }
		public string NameShop { get; set; }
		// FK AccountID 
		//public AccountEWallet AccountEWallet { get; set; }
	}
}
