using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class GenrateTopUp:BaseEntities
	{
		public string RefNo { get; set; } //Agent+Expire+จำนวนเงิน+CreateDate
		public bool IsUsed { get; set; }
	}
}
