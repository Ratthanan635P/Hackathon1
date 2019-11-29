using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models.Commands
{
	public class RegisterModel
	{
		public byte[] ImageBackground { get; set; }
		public string FristName { get; set; }
		public string LastName { get; set; }
		public DateTime BrithDate { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
		public bool FingerPrintStattus { get; set; }
	}
}
