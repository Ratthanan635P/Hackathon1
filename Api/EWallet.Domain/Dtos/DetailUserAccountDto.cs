using EWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Dtos
{
	public class DetailUserAccountDto
	{
		public byte[] ImageBackground { get; set; }
		public string FristName { get; set; }
		public string LastName { get; set; }
		public DateTime BrithDate { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public AccountEWallet AccountEWallet { get; set; }
	}
}
