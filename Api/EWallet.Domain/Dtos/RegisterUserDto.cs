using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Dtos
{
	public class RegisterUserDto
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
