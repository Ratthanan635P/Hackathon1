using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models
{
	public class DataModel
	{
			public string RefNo { get; set; }
			public DateTime ExpireDate { get; set; }
			public double Money { get; set; }
	}
}
