using EWallet.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class Transaction:BaseEntities
	{
		public string RefNo { get; set; } //Agent+Expire+จำนวนเงิน
	
		public AccountEWallet Sender { get; set; }
		public Enums.Transactions SenderTransaction { get; set; }
		
		public AccountEWallet Receive { get; set; }
		public Enums.Transactions ReceiveTransaction { get; set; }
		public double Money { get; set; }
	}
}
