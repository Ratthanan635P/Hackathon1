using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class UserOTP
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateBy { get; set; }
		public string Email { get; set; }
		public string OTP { get; set; }//password
		public DateTime ExpireDate { get; set; }

	}
}
