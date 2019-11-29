using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models
{
	public class BaseModel
	{
		public string StatusCode { get; set; }
		public string ErrorMessage { get; set; }
	}
}
