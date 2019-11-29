using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Domain.Entities
{
	public class AccountEWallet
	{
		// PK ID 
		public string Id { get; set; }
		public double Balance { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public int UpdateBy { get; set; }
		public bool IsDelete { get; set; }
		public ICollection<Transaction> TransactionReceive { get; set; }
		public ICollection<Transaction> TransactionSender { get; set; }
	}
}
