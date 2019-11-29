using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Dtos
{
	public class TopUpDto
	{
		public string RefNo { get; set; }
		public DateTime ExpireDate { get; set; }
		public double Money { get; set; }
	}
}
