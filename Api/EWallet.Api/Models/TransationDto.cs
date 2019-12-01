using EWallet.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Api.Models
{
	public class TransationDto
	{
		public string RefNo { get; set; } //Agent+Expire+จำนวนเงิน
		public int Id { get; set; }
		public string Sender { get; set; }
		public Enums.Transactions SenderTransaction { get; set; }
		public string Receive { get; set; }
		public Enums.Transactions ReceiveTransaction { get; set; }
		public double Money { get; set; }
		public DateTime CreateDate { get; set; }
	}

}
